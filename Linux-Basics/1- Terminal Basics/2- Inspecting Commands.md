# Inspecting Commands and Finding Help

When you run a command in the terminal, where does it actually come from, and where do you read its instruction manual?

To understand how Linux handles commands, you need to understand two things:
1. **The difference between built-in commands and external program files.**
2. **The official documentation tools (`man`, `help`, and `--help`).**

---

## 1. Where Commands Come From

Not every command works the same way under the hood. In Linux, commands generally fall into two categories:

### A. Shell Builtins
These are commands built directly inside the shell program itself (like Bash or Zsh).
* Because they live in memory inside the running shell, the system does not need to look for a file on your disk to execute them.
* Examples: `cd`, `exit`, `history`.

### B. External Binaries (Program Files on Disk)
An **external binary** is a standalone executable program—a compiled application that lives as an actual file stored on your storage drive.
* In Linux, system programs and utilities are stored in standard folders, most commonly **`/usr/bin/`** or **`/bin/`** (short for "user binaries").
* When you type `ls`, the shell runs the executable file sitting at `/usr/bin/ls`.

### C. Aliases
A nickname or shortcut you define for another command (e.g., shorthand `ls` automatically adding color flags).

---

## 2. Inspecting Commands with `type`

The `type` command tells you exactly what category a command belongs to:

```bash
abdullah@fedora:~$ type cd
cd is a shell builtin

abdullah@fedora:~$ type ls
ls is aliased to `ls --color=auto'
```

### Finding All Locations with `type -a`
The `-a` flag asks `type` to show **all** versions of that command found on your system:

```bash
abdullah@fedora:~$ type -a ls
ls is aliased to `ls --color=auto'
ls is /usr/bin/ls
ls is /bin/ls

abdullah@fedora:~$ type -a pwd
pwd is a shell builtin
pwd is /usr/bin/pwd
pwd is /bin/pwd
```

* **Line 1 (`ls is aliased...`):** Shows your active shortcut.
* **Lines 2 & 3 (`/usr/bin/ls`):** Shows the physical executable file on disk.

> **Note on `/bin` vs `/usr/bin`:**  
> On modern Linux systems, `/bin` is simply a shortcut (symbolic link) pointing to `/usr/bin`. They reference the same location.

---

## 3. How to Read Documentation

Linux includes built-in manuals so you never need to guess how a command works. There are three tools to use, depending on what kind of command it is:

### 1. `man` (The System Manual for External Programs)
`man` stands for **manual**. It is the standard viewer for documentation files installed on your system.

```bash
man ls
```
* **Navigation inside `man`:**
    * **`Space`** → Next page
    * **`b`** → Previous page
    * **`/word`** → Search for "word"
    * **`n`** → Next search result
    * **`q`** → Quit and exit back to the terminal

### 2. `help` (For Shell Builtins)
Because shell builtins (like `cd`) are part of the shell rather than separate disk files, they do not have standalone manual files for `man`. Instead, the shell provides its own tool called `help`:

```bash
help cd
help pwd
```
* Prints syntax and options directly into the terminal window.

### 3. `--help` (Quick Help Flag)
Most external commands accept a flag named `--help` (or `-h`) to quickly print their syntax and available options without opening a full manual viewer:

```bash
ls --help
mkdir --help
```

---

## 4. Why Does `man cd` Sometimes Fail?

If you run `man cd`, your terminal might print:
```bash
No manual entry for cd
```

This happens because:
1. `cd` is a **shell builtin**, not an external program file living in `/usr/bin/`.
2. Manual pages (`man`) are typically written for external executable files.
3. If an external tool has no manual, the developer who built the program simply did not write or package a `man` file for it.

> **Rule of Thumb:**
> * If `type` says it is a **shell builtin** → use **`help <command>`**.
> * If `type` points to a path like **`/usr/bin/...`** → use **`man <command>`** or **`<command> --help`**.