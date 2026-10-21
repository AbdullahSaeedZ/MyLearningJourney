# 01. Basic Navigation and Commands

In Linux, you interact with the system by issuing commands in the terminal instead of clicking icons.

---

## 1. Anatomy of a Command

Every command-line instruction follows this general pattern:

```bash
command  [options]  [arguments]
```

- **Command:** The utility or program you are executing (e.g., `ls`, `cd`, `rm`).
- **Options:** Modifiers that alter how the command behaves (e.g., `-l`, `--all`).
- **Arguments (Operands):** The target the command acts on, such as a file path, directory, or text string (e.g., `/var/log`).

---

## 2. Short Options (`-`) vs. Long Options (`--`)

In modern Linux tools, short and long options are often **interchangeable alternatives** designed for different use cases. You can use whichever you prefer:

* **Short form (`-`)** is designed for **speed and daily terminal typing**.
* **Long form (`--`)** is designed for **readability and scripts** so anyone reading the code understands what the flag does.

| Purpose | Short (Quick) | Long (Readable) | Notes |
| :--- | :--- | :--- | :--- |
| Show hidden files | `ls -a` | `ls --all` | Identical behavior |
| Readable file sizes | `ls -h` | `ls --human-readable` | Identical behavior |
| Display help | `ls -h` (in some tools) | `ls --help` | Check tool documentation |

### Rules for Using Them

1. **Grouping Short Options:** Multiple short options without arguments can be merged into a single `-`:
   ```bash
   # Both lines do the exact same thing:
   ls -l -a -h
   ls -lah
   ```

2. **Long Options Cannot Be Grouped:** Each long option must be written out separately:
   ```bash
   ls --all --human-readable
   ```

3. **Passing Values:** When an option requires an input parameter:
    * Short form: `-n 10`
    * Long form: `--lines=10` or `--lines 10`

> **Note:** Not *every* single short option has a long equivalent (and vice versa)—it depends on how the utility was programmed. Run `command --help` or `man command` to see available aliases.

---

## 3. Essential Navigation Commands

| Command | Purpose |
| :--- | :--- |
| **`pwd`** | Print current working directory path |
| **`ls`** | List files and folders in a directory |
| **`cd`** | Change directory (move somewhere else) |
| **`clear`** | Clean up the terminal screen |

---

## 4. `pwd` (Print Working Directory)
Prints the absolute path of your current location starting from the root directory (`/`).

```bash
pwd
# Output: /home/username
```

---

## 5. `ls` (List Directory Contents)
Lists files and folders in your current location or in a specified target path.

```bash
ls              # Lists visible files and folders in current directory
ls /var/log     # Lists contents of another directory without moving there
```

### Essential Options
- **`-l`** (Long listing): Shows file permissions, owner, size, and timestamp.
- **`-a`** / **`--all`**: Shows hidden files (files starting with a dot `.`).
- **`-h`** / **`--human-readable`**: Formats file sizes into KB, MB, or GB (used with `-l`).

```bash
ls -lah /var/log
```

---

## 6. `cd` (Change Directory)
Moves your active shell session to a different directory.

```bash
cd /var/log
```

### Absolute vs. Relative Paths
- **Absolute path:** Starts from root (`/`). Works from anywhere on the system.
  ```bash
  cd /etc/nginx
  ```
- **Relative path:** Starts from where you currently stand (no leading `/`).
  ```bash
  cd projects/backend
  ```

### Crucial Shortcuts
- **`cd`** or **`cd ~`** → Jump straight to your **Home directory** (`/home/username`).
- **`cd ..`** → Move **up one level** (to parent directory).
- **`cd ../..`** → Move **up two levels**.
- **`cd -`** → Jump back to the **previous directory** you were in (back button).
- **`.`** → Represents the **current directory**.

---

## 7. `clear` (Clean the Terminal)
Clears all output from the terminal screen buffer.

- Command: `clear`
- Shortcut: **`Ctrl + L`** *(faster, preferred)*

---

## Important Rules to Remember

1. **`/` vs. `~`:**
    * **`/`** is the **Root directory** of the entire OS.
    * **`~`** is your **User Home directory** (`/home/username`).
2. **Spaces in names:** Linux separates arguments with whitespace. Wrap names containing spaces in quotes:
   ```bash
   cd "My Folder"
   ```
3. **Tab Completion:** Type the start of a command or path and press **`Tab`** to auto-complete. Press **`Tab` twice** to list all available matches.