# Spawning a Shell Inside a Shell: Subshells and Process Inheritance

Throughout this module, we examined shells as standalone user-space programs that interpret commands and launch child processes. Because a shell is simply an executable binary, you can run a shell program *inside* another shell.

This experiment demonstrates how process hierarchy works, how the prompt is formed, and why modern shells look and behave so differently from their historical predecessors.

---

## 1. Inspecting Installed Shells on the System

Linux maintains a system file listing all valid command interpreter shells installed on your machine: `/etc/shells`.

Inspect the file:
```bash
cat /etc/shells
```

Typical output:
```text
/bin/sh
/bin/bash
/usr/bin/sh
/usr/bin/bash
/bin/zsh
/usr/bin/zsh
```

Every path listed here points to an executable program located on disk.

---

## 2. Spawning a Shell as a Child Process

We will launch the legacy `sh` (the original Bourne Shell) from inside our current shell session. This demonstrates how a shell can run inside another shell as a child process, while giving us a direct look at an early Unix environment where colors, auto-completion, and modern prompt formatting did not exist.

Start in your normal terminal session (e.g., `bash` inside Kitty) and inspect your active processes:

```bash
ps -f
```
Output:
```text
UID          PID    PPID  C STIME TTY          TIME CMD
abdullah   18420   10240  0 10:15 pts/0    00:00:00 bash
abdullah   24105   18420  0 10:22 pts/0    00:00:00 ps -f
```

Now, launch the legacy Bourne shell by running its executable name:
```bash
sh
```

Notice what immediately happens on your screen:
* Your custom theme, Starship prompt, icons, Git branch names, and working directory path disappear.
* You are left with a single, unformatted character:
  ```text
  $ 
  ```

---

## 3. The Historical Reason: Why `sh` Looks So Bare

When you drop into `/bin/sh`, running common commands like `ls` reveals no colored text:
* Directory names, executable files, and regular text files all print in monochrome plain text.
* Tab auto-completion is either extremely limited or nonexistent.
* Arrow keys may print raw escape sequences (like `^[[A`) instead of navigating your command history.

### The Historical Context:
* When Stephen Bourne created `sh` at Bell Labs in the late 1970s, computers outputted text to **teleprinters** (paper rolls) and early physical cathode-ray tube terminals (such as the DEC VT52).
* Hardware lacked color support, memory was measured in kilobytes, and CPU cycles were scarce.
* Modern conveniences—like ANSI color escape codes, dynamic Git prompt parsing, and fuzzy tab completion—did not exist. The shell was designed strictly to parse textual commands and execute programs with minimal overhead.

---

## 4. Verifying the Process Tree: Shell Inside a Shell

While sitting inside the `sh` prompt, run `ps -f` again:

```bash
$ ps -f
```

Output:
```text
UID          PID    PPID  C STIME TTY          TIME CMD
abdullah   18420   10240  0 10:15 pts/0    00:00:00 bash
abdullah   28941   18420  0 10:40 pts/0    00:00:00 sh
abdullah   29102   28941  0 10:41 pts/0    00:00:00 ps -f
```

### Breaking Down the Inheritance:

```text
+-------------------------------------------------------------------------+
| Terminal Emulator (Kitty)               [ PID: 10240 ]                  |
|   │                                                                     |
|   ▼ (Spawns primary shell on /dev/pts/0)                                |
|   [ Bash ]                              [ PID: 18420, PPID: 10240 ]     |
|       │                                                                 |
|       ▼ User runs "sh" binary                                           |
|       [ sh ] (Child shell on /dev/pts/0)[ PID: 28941, PPID: 18420 ]     |
|           │                                                             |
|           ▼ User runs "ps -f"                                           |
|           [ ps -f ]                     [ PID: 29102, PPID: 28941 ]     |
+-------------------------------------------------------------------------+
```

1. **Both shells share the same PTS:** Notice the `TTY` column still reads `pts/0`. You have not switched terminal windows or opened a new pipe; you are executing programs inside the exact same terminal channel.
2. **Parent-Child Link:**
    * `bash` (PID `18420`) is the parent of `sh` (PPID `18420`).
    * `sh` (PID `28941`) is now the parent of the commands you run inside it, such as `ps -f` (PPID `28941`).
3. **Stacked Execution:** The original `bash` process is suspended, patiently waiting for its child process (`sh`) to terminate before reclaiming control of the terminal line.

---

## 5. Exiting Back to the Parent Shell

Because `sh` is simply a child process running in memory, you can terminate it using the built-in `exit` command or pressing `Ctrl + D`:

```bash
$ exit
```

Output:
```text
╭─ abdullah in ~ 
╰─λ 
```

The `sh` process exits, the kernel removes PID `28941` from RAM, and your primary shell (`bash` or `zsh`) regains foreground control of `pts/0`, immediately restoring your customized prompt and environment.

---

## Key Takeaways

* **Shells are Programs:** Shells are standard compiled binaries stored on disk (listed in `/etc/shells`).
* **Nesting:** Executing a shell command (`sh`, `bash`, `zsh`) inside an active terminal spawns a child shell on the exact same terminal line (`pts/*`).
* **Process Stacking:** The new child shell becomes the parent (`PPID`) of any subsequent command executed inside it.
* **Historical Contrast:** Basic shells like `/bin/sh` demonstrate Unix in its original minimal form: a single `$` prompt without colors, shell plugins, or prompt formatting engines.
* **Termination:** Running `exit` kills the child shell process, cleanly returning foreground control to the parent shell.