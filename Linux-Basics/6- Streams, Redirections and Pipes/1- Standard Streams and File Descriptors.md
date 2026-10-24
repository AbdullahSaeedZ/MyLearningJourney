# Standard Streams and File Descriptors

In Linux, programs do not send data directly to physical parts of your computer like the screen, keyboard, or SSD. Instead, communication happens through continuous flows of text and bytes called **Streams**.

To track where data comes from and where it goes, the operating system gives each open stream a simple number called a **File Descriptor (FD)**.

---

## 1. What is a File Descriptor?

A **File Descriptor (FD)** is simply a **tracking number** assigned by the Linux operating system to an open channel of data.

Think of it like a **claim ticket at a coat check or an order number at a restaurant**:
1. You hand over your coat, and the staff hands you a small token with the number **`5`**.
2. When you want your coat back, you don't describe the coat. You just say, *"Give me item number 5."*
3. The staff checks number 5 on their rack and hands it to you.

Linux works the same way:
* When a program needs to read or write data, it does not manage the disk or screen directly.
* The Linux kernel opens the resource and hands the program an integer (like `0`, `1`, or `2`).
* When the program wants to send data, it tells Linux: *"Send this text to channel number 1."*

---

## 2. File Descriptors vs. Exit Codes

Both are simple numbers in Linux, but they do completely different jobs:

```text
┌──────────────────┬──────────────────────────────────────┬──────────────────────────────────────┐
│ Feature          │ File Descriptor (FD)                 │ Exit Code ($?)                       │
├──────────────────┼──────────────────────────────────────┼──────────────────────────────────────┤
│ What is it?      │ A tracking number for an open stream │ A final status code                  │
│ When is it used? │ DURING program execution             │ AFTER program finishes               │
│ Purpose          │ Moving data in and out of a program  │ Reporting success (0) or failure (1+)│
│ Examples         │ 0 (stdin), 1 (stdout), 2 (stderr)    │ 0 = OK, 1 = Error, 127 = Not Found   │
└──────────────────┴──────────────────────────────────────┴──────────────────────────────────────┘
```

* A **File Descriptor** is an active pipeline for moving actual data.
* An **Exit Code** carries no data—it is just the final grade reported when the program exits.

---

## 3. Streams vs. Standard Streams

* **A Regular Stream:** Any flow of data in Linux. It can be a text file on your drive, an internet connection, or sound sent to your speakers.
* **Standard Streams:** Three specific streams that the operating system gives to **every single program automatically** when it starts.

By default, these three streams connect straight to your active terminal window:

```text
               ┌────────────────────────────────────────────────────────┐
               │                    ALL I/O STREAMS                     │
               │                                                        │
               │   • File Streams (reading/writing to disk)             │
               │   • Network Sockets (talking over the internet)        │
               │                                                        │
               │   ┌────────────────────────────────────────────────┐   │
               │   │           THE 3 STANDARD STREAMS               │   │
               │   │      (Auto-created for every program)          │   │
               │   │                                                │   │
               │   │   [FD 0] stdin  ── From terminal to shell      │   │
               │   │   [FD 1] stdout ── Shell back to terminal      │   │
               │   │   [FD 2] stderr ── Shell back to terminal      │   │
               │   └────────────────────────────────────────────────┘   │
               └────────────────────────────────────────────────────────┘
```

---

## 4. The Three Standard Streams

The system numbers these default channels starting from `0`:

```text
┌────┬────────────────┬──────────┬───────────┬───────────────────────────────────────────┐
│ FD │ Formal Name    │ Short    │ Direction │ Default Route                             │
├────┼────────────────┼──────────┼───────────┼───────────────────────────────────────────┤
│ 0  │ Standard Input │ stdin    │ Reading   │ From terminal to shell                    │
│ 1  │ Standard Output│ stdout   │ Writing   │ From shell back to your terminal as result│
│ 2  │ Standard Error │ stderr   │ Writing   │ From shell back to your terminal as result│
└────┴────────────────┴──────────┴───────────┴───────────────────────────────────────────┘
```

### Visualizing the Default Setup

When you run a command without changing anything, all three streams hook up to your current terminal session:

```text
                        ┌────────────────────────┐
                        │   Terminal Window      │
                        └───────┬────────▲───────┘
                                │        │
                       Keyboard │        │ From shell back to terminal
                          Input │        │ as result (Data & Errors)
                                │        │
                                ▼        │
                         [FD 0] stdin    │ [FD 1] stdout & [FD 2] stderr
                     (Terminal -> Shell) │
                        ┌────────────────┴───────┐
                        │                        │
                        │    RUNNING PROGRAM     │
                        │          (ls)          │
                        │                        │
                        └────────────────────────┘
```

---

## 5. Explaining Each Standard Stream

### 1. `stdin` (File Descriptor `0`): Standard Input
* **What it does:** The channel where data enters a program or shell.
* **Default:** From terminal to shell (via your keyboard).

### 2. `stdout` (File Descriptor `1`): Standard Output
* **What it does:** The channel for regular, successful output.
* **Default:** From shell back to your terminal as a result.

### 3. `stderr` (File Descriptor `2`): Standard Error
* **What it does:** The channel reserved only for warnings and error messages.
* **Default:** From shell back to your terminal as a result.
* **Why Separate `stdout` from `stderr`?**  
  Because both show up in your terminal, they look like the same thing. But because the system keeps them on two different channel numbers (`1` and `2`), we can separate them: we can save clean output data into a text file while letting error messages stay visible in our terminal.

---

## 6. Seeing the Channels in Action with `ls`

### A. The Input Channel: `stdin` (FD `0`)
When you type `ls /home/abdullah/` and hit Enter, your keystrokes travel directly through **`stdin` (FD `0`)** from terminal to shell, which reads it and executes the `ls` process:

```bash
abdullah@fedora:~$ ls /home/abdullah/
```

```text
 ┌─────────────────────────────┐
 │       Terminal Window       │
 └──────────────┬──────────────┘
                │ Keystrokes (from terminal to shell)
                ▼
           [FD 0] stdin
 ┌─────────────────────────────┐
 │        Shell / Bash         │ ──(Spawns & Runs)──> ┌──────────────────┐
 └─────────────────────────────┘                      │   PROCESS: ls    │
                                                      └──────────────────┘
```

---

### B. The Normal Output Channel: `stdout` (FD `1`)
When `ls` successfully reads the directory, it sends the output through **`FD 1` (stdout)** from the shell back to your terminal as a result:

```bash
abdullah@fedora:~$ ls /home/abdullah/
Desktop  Documents  Downloads  Music  Pictures  Videos
```

```text
 ┌──────────────────────────────────────────────┐
 │                 PROCESS: ls                  │
 └──────────────────────┬───────────────────────┘
                        │ Successful listing
                        ▼
                  [FD 1] stdout
                        │
                        ▼
 ┌──────────────────────────────────────────────┐
 │ From shell back to your terminal as a result │
 └──────────────────────────────────────────────┘
```

---

### C. The Error Channel: `stderr` (FD `2`)
When you give `ls` a path that does not exist, the program writes the failure message out through **`FD 2` (stderr)** from the shell back to your terminal as a result:

```bash
abdullah@fedora:~$ ls /home/abdullah/nonexistent/
ls: cannot access '/home/abdullah/nonexistent/': No such file or directory
```

```text
 ┌──────────────────────────────────────────────┐
 │                 PROCESS: ls                  │
 └──────────────────────┬───────────────────────┘
                        │ Error message
                        ▼
                  [FD 2] stderr
                        │
                        ▼
 ┌──────────────────────────────────────────────┐
 │ From shell back to your terminal as a result │
 └──────────────────────────────────────────────┘
```

---

### D. Both Output Channels Firing Together (`stdout` + `stderr`)
When you query one valid directory and one invalid directory in the exact same command:

```bash
abdullah@fedora:~$ ls /home/abdullah/ /home/abdullah/nonexistent/
ls: cannot access '/home/abdullah/nonexistent/': No such file or directory
/home/abdullah/:
Desktop  Documents  Downloads  Music  Pictures  Videos
```

```text
               ┌──────────────────────────────────────────────────┐
               │    ls /home/abdullah/ /home/abdullah/nonexistent │
               └────────────────────────┬─────────────────────────┘
                                        │
                 ┌──────────────────────┴──────────────────────┐
                 ▼                                             ▼
           [FD 2] stderr                                 [FD 1] stdout
          (Error Message)                                (Folder List)
                 │                                             │
                 └──────────────────────┬──────────────────────┘
                                        │
                                        ▼
                 ┌──────────────────────────────────────────────┐
                 │ From shell back to your terminal as a result │
                 └──────────────────────────────────────────────┘
```

Both lines appear in your terminal, but they arrived over two separate numbered channels.

---

## 7. Checking File Descriptors Live: `/proc`

You can look at the active channels of your current shell (`$$`) inside the Linux system folder `/proc`:

```bash
abdullah@fedora:~$ ls -l /proc/$$/fd
```

Output:
```text
lrwx------. 1 abdullah abdullah 64 Oct 24 12:45 0 -> /dev/pts/1
lrwx------. 1 abdullah abdullah 64 Oct 24 12:45 1 -> /dev/pts/1
lrwx------. 1 abdullah abdullah 64 Oct 24 12:45 2 -> /dev/pts/1
lrwx------. 1 abdullah abdullah 64 Oct 24 12:45 255 -> /dev/pts/1
```

* `0`, `1`, and `2` are open.
* They all point to `/dev/pts/1` (your active pseudoterminal session).

---

## Key Takeaways

* **File Descriptor (FD):** A simple tracking number (`0`, `1`, `2`) given to an open channel of data while a program is running.
* **Exit Code vs FD:** An FD moves data during execution; an exit code reports whether the program succeeded after it finishes.
* **The Three Standard Streams:**
    * **`0` (`stdin`)**: Input into the program (from terminal to shell).
    * **`1` (`stdout`)**: Normal output (from shell back to your terminal as a result).
    * **`2` (`stderr`)**: Error messages (from shell back to your terminal as a result).
* **What Redirection Does:** Redirection simply takes channel `0`, `1`, or `2` and connects it to a file on disk instead of the terminal.