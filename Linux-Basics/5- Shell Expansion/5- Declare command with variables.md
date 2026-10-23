# Controlling Variable Attributes with the `declare` Built-in

In standard Bash, all bare variables are fundamentally treated as plain text strings. Even when you assign a numeric expression like `total=10+5`, the shell does not perform math—it simply stores the literal sequence of characters `"10+5"`.

With the **`declare`** built-in command, we can attach specific **attributes** to variables. These attributes assign a pseudo-type to the variable, changing how the shell evaluates data assigned to it. For example, adding the **`-i`** attribute tells the shell to treat the variable as an integer, forcing it to evaluate calculations automatically.

---

## 1. Inspecting Exported Variables: `declare -x`

Before exploring custom attributes, note that running `declare` alone or with inspect flags queries the shell's internal symbol table.

Running:
```bash
abdullah@fedora:~$ declare -x
```

Instructs Bash to output every variable currently marked with the export attribute (environment variables) formatted as executable shell assignments:

```text
declare -x HOME="/home/abdullah"
declare -x HOSTNAME="fedora"
declare -x LANG="en_US.UTF-8"
declare -x PATH="/usr/local/bin:/usr/bin:/bin:/usr/local/sbin:/usr/sbin"
declare -x SHELL="/bin/bash"
declare -x USER="abdullah"
```

Unlike external tools like `env`, `declare -x` is a shell built-in that displays precise shell formatting with proper quoting.

---

## 2. Setting Attributes on Variables

You assign attributes using `declare -<FLAG> NAME=value`.

### Common Attribute Flags:
```text
Flag    Attribute Enforced
────────────────────────────────────────────────────────────────────────
-i      Integer (Treats the variable as an integer; evaluates math automatically)
-r      Read-only (Locks the variable permanently; cannot be altered or unset)
-x      Export (Exports the variable into the environment for child processes)
-l      Lowercase (Automatically converts assigned text to lowercase)
-u      Uppercase (Automatically converts assigned text to uppercase)
-p      Print (Displays the current attributes and value of a variable)
```

---

## 3. How Attributes Change Variable Behavior

### A. The Integer Attribute (`-i`): Automatic Arithmetic Evaluation
Compare a standard text variable against an integer-attributed variable:

#### Bare Variable (Standard Text):
```bash
abdullah@fedora:~$ total=10+5
abdullah@fedora:~$ echo $total
10+5
```
Because standard variables are text, the shell treats `+` as an ordinary character.

#### With the Integer Attribute (`-i`):
```bash
abdullah@fedora:~$ declare -i total=10+5
abdullah@fedora:~$ echo $total
15
```
By adding the `-i` attribute, Bash automatically parses and evaluates the expression mathematically on assignment without requiring `$(( ... ))`.

If you assign a non-numeric string to an integer variable, Bash tries to resolve it as another variable name. If no such variable exists, it evaluates to `0`:
```bash
abdullah@fedora:~$ total="hello"
abdullah@fedora:~$ echo $total
0
```

---

### B. The Read-Only Attribute (`-r`): Locking Values
The `-r` attribute creates constant values that cannot be modified or cleared by later commands:

```bash
abdullah@fedora:~$ declare -r DB_HOST="127.0.0.1"
abdullah@fedora:~$ DB_HOST="192.168.1.1"
bash: DB_HOST: readonly variable
```

It also blocks deletion:
```bash
abdullah@fedora:~$ unset DB_HOST
bash: unset: DB_HOST: cannot unset: readonly variable
```

---

### C. The Export Attribute (`-x`): Declaring and Exporting Together
Instead of defining a variable first and calling `export` on the next line, you can assign the export attribute directly upon declaration:

```bash
abdullah@fedora:~$ declare -x PORT=8080
```
This is equivalent to `export PORT=8080` and ensures child processes receive a copy of this variable.

---

### D. Casing Attributes (`-u` and `-l`)
Attributes can enforce case formatting rules dynamically:

```bash
abdullah@fedora:~$ declare -u ENV_STATE="production"
abdullah@fedora:~$ echo $ENV_STATE
PRODUCTION

abdullah@fedora:~$ declare -l USERNAME="ADMINISTRATOR"
abdullah@fedora:~$ echo $USERNAME
administrator
```

---

## 4. Inspecting and Removing Attributes

### Viewing Assigned Attributes (`-p`)
To verify which attributes are active on a variable:
```bash
abdullah@fedora:~$ declare -p total
declare -i total="0"

abdullah@fedora:~$ declare -p DB_HOST
declare -r DB_HOST="127.0.0.1"
```

### Removing Attributes (The `+` Prefix)
To strip an attribute away from a variable, use a **plus sign (`+`)** instead of a minus sign:

```bash
abdullah@fedora:~$ declare +i total      # Removes the integer attribute
abdullah@fedora:~$ total=10+5
abdullah@fedora:~$ echo $total
10+5
```

*(Note: The read-only attribute `-r` cannot be stripped. Once applied, it stays locked until the shell session terminates.)*

---

## Key Takeaways

* **Bare Variables = Strings:** Regular Bash variables have no types; they treat everything as raw text.
* **Attributes via `declare`:** The `declare` command assigns constraints and behaviors that simulate data types.
* **The `-i` Flag:** Directs the shell to treat values assigned to the variable as numeric calculations rather than strings.
* **Safety with `-r`:** Locks down variables to prevent modifications or deletion (`unset`).
* **Toggling Attributes:** Use `-` to turn an attribute on, and `+` to turn an attribute off (except for `-r`).