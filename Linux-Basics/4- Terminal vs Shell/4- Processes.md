# Tracking Processes and Terminal Sessions with ps

In previous lessons, we saw that Linux boots with several TTY slots sitting directly above the kernel. One of those slots hosts your graphical session, while others remain bare text consoles. To understand how software actually runs inside these environments, we need to inspect the fundamental unit of execution in Linux: the **Process**.

---

## 1. What is a Process?

A **process** is simply any program loaded into system memory (RAM) and running under the direction of the kernel. Every single active task on your system—from the display compositor rendering your desktop to a simple utility command—is a process.

To manage and track all these executing tasks without confusion, the Linux kernel assigns every single process a unique identification number called a **PID** (**P**rocess **ID**).

### The Chain of Execution (Parent and Child)
Processes do not appear out of thin air. In Linux, almost every process is spawned by another existing process (its parent):

1. Your machine boots, and the kernel allocates **TTY slots**.
2. A TTY slot (such as `tty1` or `tty2`) launches your graphical session or compositor (like Niri or GNOME).
3. From that compositor, you open applications like your browser or a terminal emulator (e.g., Kitty).
4. Inside Kitty, a **Shell process** (like Bash) is launched.
5. Inside that shell, every command you type temporarily runs as a child process of the shell.

---

## 2. Inspecting Your Active Terminal with Basic `ps`

When you type `ps` (**P**rocess **S**tatus) without extra options, Linux inspects your current execution environment and displays only the processes tied strictly to your active terminal session:

```bash
ps
```

Example output:
```text
    PID TTY          TIME CMD
  18420 pts/0    00:00:00 bash
  24105 pts/0    00:00:00 ps
```

### Breaking Down the Columns:
* **`PID`:** The unique Process ID assigned by the kernel.
* **`TTY`:** The terminal device controlling this process. Seeing `pts/0` proves this Bash session and the `ps` command are bound to your graphical window's virtual terminal line.
* **`TIME`:** Total CPU processing time consumed by the command.
* **`CMD`:** The executable name of the process.

Notice that `ps` itself appears in the list. To inspect the system, the kernel had to spawn `ps` as an active process inside that exact same `pts/0` session.

---

## 3. Viewing the Hierarchy: The Process Tree

Every child process keeps a record of who spawned it via a **PPID** (**P**arent **P**rocess **ID**).

Here is how that hierarchy looks inside your environment:

```text
+-------------------------------------------------------------+
| TTY 1 (Graphical Slot)                                      |
|                                                             |
|   [ Compositor / Window Manager ] (PID: 1205)               |
|               │                                             |
|               ▼ Spawns application window                   |
|   [ Terminal Emulator (Kitty) ]   (PID: 10240, PPID: 1205)  |
|               │                                             |
|               ▼ Spawns shell inside /dev/pts/0              |
|           [ Bash ]                (PID: 18420, PPID: 10240) |
|               │                                             |
|               ▼ Executes typed command                      |
|            [ ps ]                 (PID: 24105, PPID: 18420) |
+-------------------------------------------------------------+
```

To see this exact parent-child hierarchy in the terminal along with the TTY mapping, use `ps` with formatting flags:

```bash
ps -f
```
* **`-f`:** Display **full** format listing (shows user ownership, PID, PPID, and arguments).

Example output:
```text
UID          PID    PPID  C STIME TTY          TIME CMD
abdullah   18420   10240  0 10:15 pts/0    00:00:00 bash
abdullah   24105   18420  0 10:22 pts/0    00:00:00 ps -f
```

Look at the IDs:
* `bash` has PID `18420`, and its **PPID** (`10240`) traces back to the terminal emulator that opened it.
* `ps -f` has PID `24105`, and its **PPID** (`18420`) points directly to `bash` as its parent.

To view every process running across the entire operating system (all TTY slots and background services):
```bash
ps -ef
```
* **`-e`:** Show **every** process running on the system.

In this full listing, notice the `TTY` column:
* Everyday desktop terminal windows appear with `pts/0`, `pts/1`, etc.
* Direct emergency console logins show `tty1`, `tty2`, etc.
* Background system services (daemons) show a `?` because they run silently in the background without any attached interactive terminal.

---

## Key Takeaways

* **Process:** Any active program loaded into RAM, assigned a unique **PID** by the kernel.
* **Hierarchy:** Processes form parent-child chains; a child's **PPID** matches the **PID** of the program that launched it.
* **TTY Column:** Identifies which terminal device (`pts/*`, `tty*`, or `?` for background services) controls the process.
* **Commands:**
    * `ps`: Displays active processes attached to your current terminal session.
    * `ps -f`: Displays full detail, including parent process IDs (PPID).
    * `ps -ef`: Displays all active processes running across the entire operating system.