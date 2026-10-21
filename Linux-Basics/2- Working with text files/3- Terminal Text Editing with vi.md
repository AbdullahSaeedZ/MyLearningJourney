# Terminal Text Editing with vi

`vi` (short for **Visual**) is the standard, universal text editor across Unix and Linux systems. It was created in 1976 by Bill Joy as the full-screen visual interface for **`ex`**—which itself was an evolution of **`ed`**, the original Unix line editor where users could only edit text by typing line numbers and commands blindly.

On almost all modern Linux systems, typing `vi` actually runs **Vim** (**V**i **IM**proved), an extended version that retains complete backward compatibility.

---

## 1. What Does "Modal" Mean?

Most everyday text editors (like Notepad, VS Code, or Nano) are **modeless**:
* Every alphanumeric key you press writes that letter directly onto the screen.
* To perform actions like saving or copying, you hold down modifier keys (like `Ctrl` or `Alt`).

In contrast, `vi` is a **modal editor**:
* The editor operates in distinct states called **modes**.
* The exact same key on your keyboard performs completely different functions depending on the active mode.
* For example, pressing the letter **`d`** in one mode acts as a command to delete a line, while in another mode it simply prints the letter "d" on the screen.

Modal editors exist so you can navigate, edit, and manipulate code or configuration files at high speed entirely from the home row of your keyboard without reaching for a mouse or constantly pressing multi-key combinations (`Ctrl + Shift + ...`).

---

## 2. The 3 Primary Modes in vi

While modern Vim adds extra states (such as Visual mode for highlighting text), classic `vi` revolves around three core modes:

### 1. Command Mode (Normal Mode)
* **What it is:** The default landing mode whenever you open or launch a file.
* **What it does:** Keystrokes are treated as commands rather than text. You use this mode to move around, delete words or lines, copy, paste, and undo mistakes.
* **How to enter:** Press **`Esc`** at any time to return here from any other mode.

### 2. Insert Mode
* **What it is:** The actual text-writing mode.
* **What it does:** The editor behaves like a standard notepad. Typing keys inserts characters into the file at the cursor position.
* **How to enter:** From Command Mode, press **`i`** (insert before cursor) or **`a`** (append after cursor).

### 3. Last-Line Mode (Command-Line / Ex Mode)
* **What it is:** The administrative and file-management interface inherited directly from the original `ex` line editor.
* **What it does:** Used for system-level editor actions: saving to disk, quitting, reading other files, configuring editor settings, and running search-and-replace routines.
* **How to enter:** From Command Mode, type a colon (**`:`**). The cursor drops to the very bottom line of the terminal screen, waiting for your instruction.

---

## 3. The Basic Survival Cycle

1. **Open the file:**
   ```bash
   vi config.txt
   ```
   *(You begin in **Command Mode**).*

2. **Start typing:**
    * Press **`i`** to switch to **Insert Mode**.
    * Notice the indicator `-- INSERT --` appears at the bottom left.
    * Type your text.

3. **Stop typing and return to commands:**
    * Press **`Esc`**.
    * The `-- INSERT --` label disappears; you are back in **Command Mode**.

4. **Save and exit:**
    * Type **`:wq`** and press **Enter** (write changes and quit).
    * Or type **`:q!`** and press **Enter** to exit and discard all changes.

---

## 4. Essential Command Mode Actions

Ensure you press **`Esc`** first so you are in **Command Mode** before using these keys:

### Switching into Insert Mode
* **`i`:** Insert text before the cursor.
* **`a`:** Append text after the cursor.
* **`o`:** Open a new blank line below the current line and switch directly into Insert mode.

### Deleting and Editing
* **`x`:** Delete the single character under the cursor.
* **`dd`:** Delete (cut) the entire current line.
* **`u`:** Undo the last change.

### Copying and Pasting
* **`yy`:** Copy (yank) the entire current line into memory.
* **`p`:** Paste the copied or cut line directly below the cursor.

### Basic Search
* **`/pattern`:** Search forward for a specific word or pattern.
* **`n`:** Jump to the next occurrence of that pattern.

---

## 5. Last-Line Mode Operations (`:`)

From Command Mode, type `:` and then:

* **`:w`:** Write (save) the file to disk without exiting.
* **`:q`:** Quit the editor (fails if there are unsaved edits).
* **`:wq`:** Save changes and quit back to the shell.
* **`:q!`:** Force quit immediately, throwing away all unsaved modifications.

---

## Key Takeaways

* **Heritage:** `vi` was built as the full-screen visual mode for the older Unix line editor `ex`.
* **Modal Architecture:** Unlike modeless editors, `vi` separates typing text from issuing file and navigation commands.
* **The 3 Modes:**
    * **Command Mode:** Navigation, deleting, copying, pasting (default mode).
    * **Insert Mode:** Writing text directly (entered via `i`).
    * **Last-Line Mode:** Saving, quitting, and configuration (entered via `:`).
* **Reset Button:** Pressing **`Esc`** always brings you back to Command Mode.