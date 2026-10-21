# Running Shell Commands Inside vi

In `vi`, you do not need to exit or switch terminal tabs to run Linux shell commands or insert their output directly into your document.

---

## 1. Why Is This Useful?

* **Zero Context Switching:** Check file paths, network status, or man pages without closing your active editor session.
* **Instant Automation:** Pull dynamic system data (timestamps, directory listings, command output) directly into your file instead of typing it manually.

---

## 2. The Two Core Methods

Both commands are run from **Last-Line Mode** (press `Esc`, then `:`).

### Method A: Run a Command and View It (`:!`)
Executes an external shell command, shows the result on the screen, then prompts you to press `Enter` to return to editing. **It does not touch your file content.**

```text
:!date
```
* **Use case:** Quick checks (e.g., `:!ls`, `:!pwd`, `:!whoami`).

---

### Method B: Read Command Output Into the File (`:r !` or `:.!`)
Runs an external command and pastes its output directly into your open file.

#### 1. Insert output below current line: `:r !<command>`
Reads the command's stdout and places it right after the cursor line:
```text
:r !date
```
* **Result:** Injects the current system timestamp into your file.

#### 2. Replace current line with output: `:.! <command>`
Runs the command and **overwrites** the line your cursor is currently on with the output:
```text
:.! date
```
* **Result:** Replaces the current line with the date string.

---

## 3. Quick Reference

* **`:!<cmd>`:** Run a shell command just to inspect the output on screen.
* **`:r !<cmd>`:** Paste shell command output *below* the current cursor line.
* **`:.! <cmd>`:** *Replace* the current line with the shell command output.