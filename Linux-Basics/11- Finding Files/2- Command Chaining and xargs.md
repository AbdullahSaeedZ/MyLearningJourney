# Command Chaining and xargs

While tools like `find` offer built-in execution flags (`-exec`), using them goes against the Unix philosophy of building small, single-purpose utilities that connect together. Linux workflows favor using pipes to pass discovery results to dedicated programs.

Among these programs, **`xargs`** is the standard utility for turning incoming text streams into discrete command arguments.

---

## 1. Why Not Use Built-In Execution?

Relying on built-in execution switches like `find -exec` introduces several practical issues:
1. **Violates the Unix Philosophy:** A search utility should search; execution should belong to dedicated tools.
2. **Awkward Syntax:** Flag-based execution requires cumbersome formatting (such as escaped semicolons `\;` or `+`).
3. **Loss of Composition:** You cannot easily slide intermediate filters (like `grep`, `sort`, or `head`) into the middle of an embedded flag.

Keeping search and execution separate preserves clean, modular shell pipelines.

---

## 2. Inline Evaluation: `$(...)`

Before using stream-processing tools, a common way to pass small sets of files directly into another command is **command substitution** (`$()`):

```bash
# Locate two specific log files and inspect them with a pager:
cat $(find /var/log -maxdepth 1 -name "*.log" | head -n 2) | less
```

The shell runs `$(find ... | head -n 2)` first, places the resulting paths inline as positional arguments to `cat`, and pipes the combined stream into `less`.

---

## 3. The `xargs` Utility

Commands like `grep` or `less` accept text directly from a pipe (`stdin`). However, filesystem management tools—like `mkdir`, `rm`, `cp`, and `touch`—do not read standard input. They require **command-line arguments** placed after the command name:

```bash
# This fails to create directories because mkdir does not read stdin:
echo "folder1 folder2" | mkdir
```

### Command Signature:
```text
xargs [options] [command [initial-arguments]]
```

### How `xargs` Works Internally:
1. **Reads from `stdin`:** It consumes standard output produced by the upstream piped command.
2. **Tokenizes by Delimiter:** It splits incoming text by a delimiter (defaulting to whitespace and newlines) into an array of discrete arguments:
   ```text
   "service_a\nservice_b\nservice_c" ──> ["service_a", "service_b", "service_c"]
   ```
3. **Passes to Command:** It supplies those array elements as positional arguments to the downstream command.

---

## 4. Parameter Placement with Placeholders: `xargs -I {}`

By default, `xargs` appends all array items to the end of the command in a single call.

When you want to run the command once per item and insert each value at a specific spot—or append text like file extensions—use the **`-I`** option with a placeholder token (commonly **`{}`**).

```text
 ┌─────────────────┐   Piped stdout   ┌──────────────────────────┐   Array items map to {}   ┌──────────────────────────┐
 │ upstream_cmd    │ ───────────────> │ xargs -I {} target_cmd   │ ────────────────────────> │ target_cmd {item_1}.ext  │
 │ (item1 \n item2)│                  │ splits stream into array │                           │ target_cmd {item_2}.ext  │
 └─────────────────┘                  └──────────────────────────┘                           └──────────────────────────┘
```

### Real-World Example: Creating Matching `.d` Directories
Suppose you have three service configuration files:

```bash
abdullah@fedora:~$ touch service_a service_b service_c
abdullah@fedora:~$ ls service_*
service_a  service_b  service_c
```

In Linux system administration, software frequently uses matching **`.d`** directories to store modular configurations (e.g., `/etc/sudoers.d` or `/etc/profile.d`).

To create a matching directory for each file ending in `.d`:

```bash
# Pipe the file list into xargs; each item replaces {} to run mkdir:
abdullah@fedora:~$ ls service_* | xargs -I {} mkdir {}.d
```

### Result:
```bash
abdullah@fedora:~$ ls -l
-rw-r--r--. 1 abdullah abdullah    0 Nov  8 18:00 service_a
drwxr-xr-x. 2 abdullah abdullah 4096 Nov  8 18:01 service_a.d/
-rw-r--r--. 1 abdullah abdullah    0 Nov  8 18:00 service_b
drwxr-xr-x. 2 abdullah abdullah 4096 Nov  8 18:01 service_b.d/
-rw-r--r--. 1 abdullah abdullah    0 Nov  8 18:00 service_c
drwxr-xr-x. 2 abdullah abdullah 4096 Nov  8 18:01 service_c.d/
```

### Execution Breakdown:
`xargs -I {}` iterated through the array of items and ran `mkdir` for each one:
1. `service_a` maps to `{}` $\rightarrow$ runs `mkdir service_a.d`
2. `service_b` maps to `{}` $\rightarrow$ runs `mkdir service_b.d`
3. `service_c` maps to `{}` $\rightarrow$ runs `mkdir service_c.d`

---

## 5. Summary Reference

```text
┌──────────────────────────────┬────────────────────────────────────────────────────────┐
│ Pattern / Syntax             │ Purpose and Internal Behavior                          │
├──────────────────────────────┼────────────────────────────────────────────────────────┤
│ $(command)                   │ Evaluates inner command and passes output as arguments.│
│ <stream> | xargs <cmd>       │ Converts delimited stream into an argument array.      │
│ xargs -I {} <cmd> {} <ext>   │ Maps each item in the array to the {} placeholder,     │
│                              │ executing the command once per entry.                  │
└──────────────────────────────┴────────────────────────────────────────────────────────┘
```

---

## Key Takeaways

- **Pipes vs. Arguments:** Piped commands write to `stdin`; file-management tools (like `mkdir`, `rm`) expect command-line arguments.
- **Array Tokenization:** `xargs` reads text streams, splits them by delimiters (whitespace/newlines), and prepares them as argument arrays.
- **Placeholder Mapping (`-I {}`):** Routes each item in the array to the exact location of `{}` in the target command, allowing custom extensions, prefixes, or target paths.