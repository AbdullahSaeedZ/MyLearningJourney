# What is a Shell and How Commands Run

In previous lessons, we established that the terminal emulator is just the display window that captures keypresses and renders text. The **Shell** is the program running inside that window waiting to process your commands.

---

## 1. The Role of the Shell

The shell is a **command language interpreter**. It acts as the bridge between human-readable text and the operating system kernel.

```text
+-----------------------+                      +-----------------------+
|   TERMINAL EMULATOR   |                      |         SHELL         |
|  (Renders the Window) | ──(Keystrokes / PTS)─> (Interprets Text Line) |
+-----------------------+                      +-----------┬-----------+
                                                           │
                                            (Requests Work │ via Syscalls)
                                                           ▼
                                               +-----------------------+
                                               |     LINUX KERNEL      |
                                               |   (Manages CPU/RAM)   |
                                               +-----------------------+
```

When you type a command and press Enter:
1. The terminal emulator sends those raw characters across the PTS to the shell.
2. The shell reads the line, figures out what you want to execute, and tells the kernel to run it.
3. The kernel executes the task on the hardware and returns the output to the shell, which hands it back to the terminal to draw on screen.

---

## 2. Common Shells in the Linux World

The shell is not hardcoded into Linux; it is an interchangeable user-space program. Over the years, several shells have evolved:

* **`sh` (Bourne Shell):** The original ancestor created in the late 1970s. Very simple, standardized, but lacks modern interactive conveniences.
* **`bash` (Bourne Again Shell):** The default standard on almost every Linux distribution (including Ubuntu and Fedora). It introduced command history, tab auto-completion, and rich scripting features.
* **`zsh` (Z Shell):** A feature-rich interactive shell known for advanced auto-completion, themes, and plugin support (default on macOS).
* **`fish` (Friendly Interactive Shell):** Designed with user experience in mind, offering autosuggestions out of the box with modern syntax.

### Checking Your Current Shell
You can verify which shell program is currently running your session:

```bash
echo $SHELL
```

Typical output:
```text
/bin/bash
```

---

## 3. How the Shell Runs Commands: Built-in vs. External

When you type a command, the shell has to find out *what* to run. Commands fall into two distinct categories:

```text
                             [ User Types Command ]
                                       │
                                       ▼
                       +───────────────────────────────+
                       |       Is it a BUILT-IN?       |
                       +───────────────┬───────────────+
                                       │
                     YES               │              NO
        ┌──────────────────────────────┘              └──────────────────────────────┐
        ▼                                                                            ▼
+──────────────────────────────+                             +───────────────────────────────+
|      SHELL BUILT-IN          |                             |       EXTERNAL BINARY         |
+──────────────────────────────+                             +───────────────────────────────+
| Run immediately inside the   |                             | The shell searches system     |
| shell process itself.        |                             | directories (/usr/bin) for an |
| (No file on disk needed)     |                             | executable file to launch.    |
+──────────────────────────────+                             +───────────────────────────────+
```

### A. Shell Built-ins
A **built-in** is a command programmed directly inside the shell code itself.
* Because it is already loaded into the shell's memory, running it is instant.
* Built-ins can modify the shell session itself (like changing your current folder).
* **Examples:**
    * `cd`: Changes the shell's active working directory. (An external program cannot change the working directory of the shell that launched it).
    * `exit`: Closes the current shell process.
    * `echo`: Prints text (often built-in for fast execution).

### B. External Programs (Binaries)
An **external command** is a standalone compiled executable program or script stored on your hard drive.
* If a command is not built into the shell, the shell searches standard system folders (such as `/bin` and `/usr/bin`) for a file matching that name.
* Once found, the shell asks the kernel to launch that file into a new running process.
* **Examples:**
    * `ls` (lives at `/usr/bin/ls`)
    * `cat` (lives at `/usr/bin/cat`)
    * `grep` (lives at `/usr/bin/grep`)

---

## 4. Identifying Command Types with `type`

Linux provides the `type` command to check whether a specific command is a built-in or an external disk binary:

```bash
type cd
```
Output:
```text
cd is a shell builtin
```

Now inspect an external tool:
```bash
type ls
```
Output:
```text
ls is /usr/bin/ls
```

* If the output says `shell builtin`, the shell executes it internally.
* If the output returns a path (like `/usr/bin/...`), it is a separate program stored on your disk.

---

## 5. Visual Division of Labor: Terminal vs. Shell Customization

> *If terminal emulators handle visuals and fonts, how can a shell like Zsh also have its own visual configurations while simply being a text interpreter?*

They customize two completely separate layers:

```text
+-------------------------------------------------------------------------+
| TERMINAL EMULATOR (Kitty, Alacritty, GNOME Terminal)                    |
|                                                                         |
|  The Canvas & Graphics Engine:                                          |
|  - Window padding, margins, and borders                                 |
|  - Background transparency and blur                                     |
|  - Font family (e.g., JetBrains Mono) and font size                     |
|  - The color palette definitions (what exact hex shade "Blue" is)       |
|                                                                         |
|   +-----------------------------------------------------------------+   |
|   | SHELL (Bash, Zsh with Oh-My-Zsh / Starship)                     |   |
|   |                                                                 |   |
|   | The Text Content & Metadata:                                    |   |
|   | - The prompt text structure ($ vs ➜ vs ~/project)               |   |
|   | - Git branch names and repo status (*main)                      |   |
|   | - Command execution duration (e.g., "took 1.2s")                |   |
|   | - Tells emulator: "Print this branch name in Blue color code"   |   |
|   +-----------------------------------------------------------------+   |
+-------------------------------------------------------------------------+
```

* **In General:** The **terminal emulator** is the canvas (renders raw pixels, handles window opacity, and draws font glyphs). The **shell** is the content generator (assembles the text string containing your current path, username, and Git state).
* **Zsh as an Example:** When configuring Zsh with Starship or Oh-My-Zsh, the shell is not drawing desktop windows or loading font files. It queries system status (e.g., current Git branch) and wraps that text inside standard color codes before passing the completed string to the emulator to draw.

---

## Key Takeaways

* **The Shell:** The command interpreter program that translates user text into kernel execution requests.
* **Shell Types:** Common shells include `sh` (the classic), `bash` (the standard), `zsh`, and `fish`.
* **Built-in Commands:** Embedded directly inside the shell process (e.g., `cd`, `exit`).
* **External Commands:** Standalone executable files stored on disk (e.g., `/usr/bin/ls`, `/usr/bin/cat`).
* **Inspection:** Run `echo $SHELL` to check your shell, and `type <command>` to check how a command runs.
* **Division of Roles:** The terminal emulator renders the graphical canvas (fonts, padding, opacity), while the shell determines the actual content and metadata (prompt structure, Git branches, working paths).