# Output and Error Redirection

In the previous lesson, we saw that by default, every command sends its normal output (`stdout` / FD `1`) and its error messages (`stderr` / FD `2`) from the shell back to your terminal display.

**Redirection** is the process of telling the shell to intercept those streams and point them toward a different destination—such as a file on disk—instead of printing them to the terminal.

---

## 1. What is Redirection?

When a program writes to standard output, it does not know or care where that data ultimately goes. It simply pushes bytes through File Descriptor `1`.

* **Without Redirection:** The shell leaves FD `1` attached to your pseudoterminal (`/dev/pts/X`). Output renders directly on your screen.
* **With Redirection:** The shell unhooks FD `1` from the terminal and connects it to a target destination (like a file). The program runs completely unaware of the change.

```text
Default Flow:
[ Running Command ] ──(FD 1: stdout)──> [ Shell ] ──> [ Terminal Display ]

Redirected Flow:
[ Running Command ] ──(FD 1: stdout)──> [ Shell ] ──> [ output.txt on Disk ]
```

---

## 2. Redirecting Standard Output: `>` vs. `>>`

The standard redirection operator is the greater-than symbol: **`>`**.

### The Explicit File Descriptor: `1>` vs. `>`
When you write:
```bash
ls /etc > files.txt
```
The shell actually interprets this as:
```bash
ls /etc 1> files.txt
```
The number `1` directly tells the shell: *"Take File Descriptor 1 (stdout) and route it to `files.txt`."* Because redirecting standard output is the most frequent operation in Linux, the shell permits omitting the `1` entirely as a convenient shorthand.

---

### A. Overwriting with `>`
The single bracket **`>`** opens the target file in **truncate/overwrite mode**.
* If the file does not exist, the shell creates it.
* If the file already exists, the shell wipes its contents completely and writes the new data from the start.

```bash
abdullah@fedora:~$ echo "First line of text" > output.txt
abdullah@fedora:~$ cat output.txt
First line of text

abdullah@fedora:~$ echo "A replacement line" > output.txt
abdullah@fedora:~$ cat output.txt
A replacement line
```
The original content was wiped clean.

---

### B. Appending with `>>`
The double bracket **`>>`** opens the target file in **append mode**.
* If the file does not exist, the shell creates it.
* If the file exists, the shell preserves existing content and writes new bytes strictly to the end of the file.

```bash
abdullah@fedora:~$ echo "Line 1" > log.txt
abdullah@fedora:~$ echo "Line 2" >> log.txt
abdullah@fedora:~$ echo "Line 3" >> log.txt
abdullah@fedora:~$ cat log.txt
Line 1
Line 2
Line 3
```

---

## 3. Redirecting Standard Error: `2>`

Standard Error (`stderr`) operates on **File Descriptor `2`**.

If a command fails and you use normal redirection (`>`), the error still prints to your terminal. Why? Because `>` only redirects File Descriptor `1`.

```bash
abdullah@fedora:~$ ls /nonexistent > files.txt
ls: cannot access '/nonexistent': No such file or directory
```
The terminal still displayed the failure because FD `2` was left untouched.

### Using `2>` to Capture Errors
To redirect errors, explicitly attach the operator to File Descriptor `2`:

```bash
abdullah@fedora:~$ ls /nonexistent 2> error.log
abdullah@fedora:~$ cat error.log
ls: cannot access '/nonexistent': No such file or directory
```

```text
 ┌─────────────────────────────┐
 │    ls /nonexistent          │
 └──────────────┬──────────────┘
                │
                ▼
          [FD 2] stderr
                │
                ▼ (Redirected by 2>)
 ┌─────────────────────────────┐
 │       error.log File        │
 └─────────────────────────────┘
```

Nothing printed in the terminal because the shell routed FD `2` directly into `error.log`.

---

## 4. Redirecting Both Streams in a Single Command

Real-world administration often requires processing good data and errors simultaneously. We can attach both `1>` (or simply `>`) and `2>` to the same command line.

### Practical Test Using `cat`
We will test with two targets:
1. `/etc/hostname`: A normal, readable file (generates `stdout` on FD `1`).
2. `/etc/shadow`: A restricted password hash file readable only by `root` (generates a `Permission denied` error on FD `2`).

Run the command and route each stream to its own log:

```bash
abdullah@fedora:~$ cat /etc/hostname /etc/shadow 1> success.txt 2> error.txt
```

```text
                         ┌──────────────────────────────────────────────┐
                         │   cat /etc/hostname /etc/shadow              │
                         └──────────────────────┬───────────────────────┘
                                                │
                     ┌──────────────────────────┴──────────────────────────┐
                     │                                                     │
                     ▼                                                     ▼
         [FD 1] stdout (Normal Data)                             [FD 2] stderr (Errors)
                     │                                                     │
                     ▼ (Redirected via 1>)                                 ▼ (Redirected via 2>)
        ┌─────────────────────────┐                           ┌─────────────────────────┐
        │       success.txt       │                           │        error.txt        │
        └─────────────────────────┘                           └─────────────────────────┘
```

### Inspect the Results:

Check the normal output destination:
```bash
abdullah@fedora:~$ cat success.txt
fedora
```

Check the error log destination:
```bash
abdullah@fedora:~$ cat error.txt
cat: /etc/shadow: Permission denied
```

### What Happened Internally:
1. `cat` processed `/etc/hostname`, read the contents, and emitted `fedora` to **FD `1`**.
2. The shell captured FD `1` and appended it to `success.txt`.
3. `cat` attempted to open `/etc/shadow`, hit an OS permission block, and emitted the failure message to **FD `2`**.
4. The shell captured FD `2` and stored it in `error.txt`.
5. Zero text printed to your active terminal window during execution.

---

## Key Takeaways

* **The Core Mechanism:** Redirection simply reassigns where File Descriptors point before the command begins execution.
* **`>` vs. `1>`:** `>` is shorthand for `1>`. Both redirect `stdout` (File Descriptor 1).
* **Overwrite vs. Append:**
    * `>` overwrites or truncates the file.
    * `>>` appends new data to the end of the file.
* **`2>` for Errors:** Explicitly redirects `stderr` (File Descriptor 2) away from the terminal and into a specified file.
* **Dual Stream Separation:** Combining `1> file1 2> file2` allows clean, simultaneous logging of valid data and runtime errors into independent files.