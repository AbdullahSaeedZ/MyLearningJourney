# Input Redirection

In the previous lesson, we redirected output (`stdout` / FD `1`) and errors (`stderr` / FD `2`) away from the terminal and into files.

**Input Redirection** does the exact opposite: instead of a program waiting for you to type text from the terminal keyboard into **`stdin` (FD `0`)**, we redirect a file on disk straight into `stdin`.

---

## 1. How Input Redirection Works

The input redirection operator is the less-than symbol: **`<`**.

### The Explicit File Descriptor: `0<` vs. `<`
When you write:
```bash
cat < file.txt
```
The shell actually interprets this as:
```bash
cat 0< file.txt
```
The number `0` explicitly instructs the shell: *"Take File Descriptor 0 (stdin) and connect it to `file.txt` instead of the keyboard."*

Just like we omit `1` in `1>`, we omit `0` in `0<` for convenience.

```text
Default Input Flow:
[ Keyboard ] ──(Keystrokes)──> [ FD 0: stdin ] ──> [ Running Program ]

Redirected Input Flow:
[ file.txt on Disk ] ────────> [ FD 0: stdin ] ──> [ Running Program ]
```

The running program does not open the file itself. It simply reads bytes from its default input stream (**`FD 0`**), completely unaware that the shell swapped the keyboard for a file on your disk.

---

## 2. A Simple Demonstration with `cat`

In Lesson 01, we saw that running `cat` with zero arguments causes it to pause and wait for your keyboard input at `stdin`.

Now, create a simple text file:
```bash
echo "Hello from input redirection" > message.txt
```

Feed that file into `cat` using `<`:
```bash
abdullah@fedora:~$ cat < message.txt
Hello from input redirection
```

```text
 ┌─────────────────────────────┐
 │         message.txt         │
 └──────────────┬──────────────┘
                │
                ▼ (Redirected via <)
          [FD 0] stdin
 ┌─────────────────────────────┐
 │        PROCESS: cat         │
 └──────────────┬──────────────┘
                │
                ▼ [FD 1] stdout
 ┌─────────────────────────────┐
 │       Terminal Display      │
 └─────────────────────────────┘
```

### What Happened Behind the Scenes:
1. The shell opened `message.txt` and attached it directly to **`FD 0`** of `cat`.
2. `cat` started running with zero arguments, so it checked **`FD 0`** as usual.
3. Instead of waiting for keyboard typing, it instantly received the contents of `message.txt`.
4. `cat` printed the text to **`FD 1` (stdout)**, which displayed on your terminal.

---

## 3. Why is Input Redirection Rarely Used?

You might notice that running:
```bash
cat < message.txt
```
produces the exact same result on your screen as running:
```bash
cat message.txt
```

Most commands in Linux (like `cat`) already accept file names directly as arguments. When you pass `message.txt` as an argument, `cat` opens the file itself. Because of this built-in capability, manually redirecting `stdin` using `<` is not needed for everyday file viewing.

---

## 4. When is Input Redirection Needed?

Input redirection becomes essential when you work with tools that **do not accept direct file paths as arguments**, but instead require raw input fed directly through `stdin`.

An example of this concept is interacting with database command-line tools:

```bash
sql < query.sql
```

```text
 ┌─────────────────────────────┐
 │          query.sql          │
 └──────────────┬──────────────┘
                │
                ▼ (Redirected via <)
          [FD 0] stdin
 ┌─────────────────────────────┐
 │        PROCESS: sql         │  (Reads SQL commands through FD 0)
 └──────────────┬──────────────┘
```

In this scenario:
* The `sql` tool does not take `query.sql` as a file argument.
* It expects an administrator to type SQL statements manually into the keyboard at `stdin`.
* Using `< query.sql` redirects the entire SQL script directly into the program's `stdin` channel all at once, running the statements without any manual typing.

---

## Key Takeaways

* **The Core Mechanism:** Input redirection connects **`FD 0` (stdin)** to a file on disk instead of your keyboard.
* **`<` vs. `0<`:** `<` is shorthand for `0<`. Both redirect standard input.
* **Why It Feels Rare:** Most modern programs accept file names directly as command-line arguments.
* **Primary Use Case:** Feeding batch scripts, queries, or data into programs that only read instructions from standard input.