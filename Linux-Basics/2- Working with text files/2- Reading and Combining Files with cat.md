# Reading and Combining Files with cat

The `cat` command is one of the most frequently used CLI utilities in Linux. While beginners often treat it simply as a tool to display text, its real power and actual name come from **conCATenation**—joining multiple data streams or files together.

---

## 1. What Does `cat` Mean?

`cat` is short for **concatenate** (to link things together in a chain).
* It takes one or more inputs, reads them sequentially, and writes them directly to standard output.
* If you pass one file, it simply prints that file.
* If you pass multiple files, it stitches them together into a continuous stream.

---

## 2. Basic File Viewing

To print the entire content of a file to your terminal screen:

```bash
cat notes.txt
```

### Limitations with Large Files
`cat` does not pause or paginate output. If a file contains 5,000 lines, `cat` will dump all 5,000 lines into your terminal at once, scrolling past your visible window. For large files, pagers like `less` or utilities like `head` and `tail` are preferred.

---

## 3. Useful Flags

### A. Number All Output Lines (`-n`)
Adds line numbers starting from 1 to every line, including blank lines:

```bash
cat -n notes.txt
```

### B. Number Only Non-Blank Lines (`-b`)
Numbers lines that contain text, ignoring empty lines:

```bash
cat -b notes.txt
```

### C. Show Line Ends (`-E` or `-A`)
Displays a `$` character at the end of each line, useful for spotting hidden trailing spaces or blank lines:

```bash
cat -E notes.txt
```

---

## 4. Concatenating Multiple Files

You can pass several files as arguments to `cat`. It will output them back-to-back in the exact order specified:

```bash
cat header.txt body.txt footer.txt
```

### Merging Files Using Redirection
By pairing `cat` with output redirection (`>`), you can merge multiple separate files into a single consolidated file:

```bash
cat part1.txt part2.txt part3.txt > complete_document.txt
```

> **Why not `echo` for merging?**  
> `echo` prints the literal text passed to it—it cannot open or read files on disk. Running `echo file1.txt file2.txt > merged.txt` will literally write the text `"file1.txt file2.txt"` into the new file, not the contents inside them.  
> `cat` reads the actual content inside the files before sending it to the destination.

---

## 5. Creating Quick Files Interactively

You can use `cat` combined with output redirection to type text directly into a file without opening a text editor:

```bash
cat > shopping_list.txt
```

1. Run the command above. The terminal will pause and wait for input.
2. Type your content line by line:
   ```text
   Apples
   Milk
   Bread
   ```
3. Press **`Ctrl + D`** on a new line to signal **EOF (End of File)**.
4. The shell closes the file and returns you to the normal prompt.

---

## Key Takeaways

* **Primary Purpose:** Concatenating (chaining) files and printing them to standard output.
* **Basic Reading:** `cat <filename>` dumps the full file directly to the terminal.
* **Line Numbering:** Use `-n` for all lines, or `-b` for non-empty lines only.
* **Merging Files:** Use `cat file1 file2 > merged_file` (not `echo`, which only prints literal text).
* **Interactive Writing:** Use `cat > filename` followed by `Ctrl + D` to create short files quickly without an editor.