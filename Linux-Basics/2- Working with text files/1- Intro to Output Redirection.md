# Intro to Output Redirection

In Linux, programs operate using data streams. By default, three standard streams exist:
* **Standard Input (`stdin`):** Where commands take data from (usually your keyboard).
* **Standard Output (`stdout`):** Where commands send regular results (usually your terminal screen).
* **Standard Error (`stderr`):** Where commands send error messages (also printed to your screen).

> **Note:** A complete deep dive into standard streams, file descriptors (`0`, `1`, `2`), and advanced piping (`|`) is covered in a dedicated upcoming lesson. This lesson focuses on the essentials: routing your standard output into files using redirection.

---

## 1. Where Does Command Output Go?

By default, the shell connects standard output directly to your terminal window:

```bash
echo "Hello, world"
# Output printed to terminal: Hello, world
```

With redirection operators, you can tell the shell to take that text stream and write it to a storage file on disk instead of printing it on the screen.

---

## 2. Overwrite Redirection (`>`)

The single greater-than sign (`>`) redirects standard output to a specified file.

* If the target file **does not exist**, the shell creates it automatically.
* If the target file **already exists**, the shell completely wipes its current content and replaces it with the new output.

```bash
echo "First line of text" > notes.txt
```

Verify what was written:
```bash
cat notes.txt
# Output: First line of text
```

### The Overwrite Danger
Running another command with `>` targeting the same file overwrites earlier data:

```bash
echo "Second line of text" > notes.txt
cat notes.txt
# Output: Second line of text
```
*(The original line "First line of text" is gone).*

---

## 3. Append Redirection (`>>`)

The double greater-than sign (`>>`) redirects output to a file without destroying existing content.

* If the target file **does not exist**, the shell creates it.
* If the target file **already exists**, the new output is appended directly to the end of the file on a new line.

```bash
echo "Line one" > log.txt
echo "Line two" >> log.txt
echo "Line three" >> log.txt
```

Verify the file:
```bash
cat log.txt
# Output:
# Line one
# Line two
# Line three
```

---

## 4. `touch` vs. Output Redirection

Both methods can create files from the command line, but they serve different intents:

* **`touch <filename>`**
    * Primary use: Updates file timestamps.
    * File creation: Creates an empty, 0-byte file if it does not exist.
    * Does not write any content into the file.

* **`echo "text" > <filename>`**
    * Primary use: Routes text output into a file.
    * File creation: Creates the file immediately populated with text.
    * Replaces existing content if the file is already present.

---

## 5. Redirecting Other Commands

Redirection works with any command that prints text to the screen, not just `echo`:

```bash
# Save system specifications to a file
uname -a > system_info.txt

# Append network details to the same file
ip a >> system_info.txt

# Save directory contents list to a text file
ls -lah /var/log > logs_list.txt
```

---

## Key Takeaways

* **Standard Output (`stdout`):** The default stream for command results, directed to the screen unless redirected.
* **`>` (Overwrite):** Creates a file or completely overwrites an existing file with command output.
* **`>>` (Append):** Creates a file or appends output to the bottom of an existing file without deleting prior data.
* **`touch`:** Best for quickly creating empty placeholder files.
* **Redirection (`>` / `>>`):** Best for saving command results or logging data directly into files.