# Filtering Streams

In earlier lessons, commands dumped their entire output straight from the shell back to your terminal as a result. For a small directory or a 5-line file, that is manageable. But in real systems, commands and log files produce thousands of lines of noisy data.

To make streams useful, Linux provides specialized tools called **Filters**.

A filter is a small utility that accepts a stream of lines, processes them according to specific criteria, and outputs only the relevant subset or aggregated result.

---

## 1. What Makes a Tool a "Filter"?

A filter in Linux follows two operating rules:
1. It processes data **line by line** (or byte by byte).
2. It can read input directly from a file argument, OR it can read from **`stdin` (FD `0`)** when no file is specified.

The primary stream filters are:
* **`grep`**: Filters lines by **matching a text pattern**.
* **`head`**: Filters lines by **taking from the beginning**.
* **`tail`**: Filters lines by **taking from the end**.
* **`wc`**: Filters/aggregates lines by **counting lines, words, and bytes**.

```text
                  ┌──────────────────────────────┐
                  │        Incoming Stream       │
                  │ (Many lines of raw data)     │
                  └──────────────┬───────────────┘
                                 │
         ┌───────────────────────┼───────────────────────┐
         ▼                       ▼                       ▼
┌─────────────────┐    ┌──────────────────┐    ┌───────────────────┐
│ By Position:    │    │ By Content:      │    │ By Aggregation:   │
│ head (top lines)│    │ grep (pattern)   │    │ wc (counts)       │
│ tail (bottom)   │    └──────────────────┘    └───────────────────┘
└─────────────────┘
```

---

## 2. Filtering by Content: `grep`

The `grep` command (Global Regular Expression Print) scans incoming text line by line and prints **only** the lines containing a specific pattern.

### Basic Syntax:
```bash
grep "search_pattern" filename
```

### Demonstration:
Linux stores registered user accounts in the file `/etc/passwd`. Look for an account named `root`:

```bash
abdullah@fedora:~$ grep "root" /etc/passwd
root:x:0:0:root:/root:/bin/bash
```

Every line inside `/etc/passwd` that did not contain the text `root` was discarded. Only the matching line was passed to `stdout`.

```text
 ┌────────────────────────────────────────────────────────┐
 │                      /etc/passwd                       │
 │  root:x:0:0:root:/root:/bin/bash  ───> [ MATCH: KEEP ] │ ──> FD 1 (stdout)
 │  bin:x:1:1:bin:/bin:/sbin/nologin ───> [ NO MATCH: DROP]
 │  daemon:x:2:2:daemon:/sbin:nologin───> [ NO MATCH: DROP]
 └────────────────────────────────────────────────────────┘
```

### Key Flags to Know:
* `-i` (Case-Insensitive): Matches text regardless of upper or lower case.
  ```bash
  grep -i "fedora" /etc/os-release
  ```
* `-n` (Line Numbers): Prints the line numbers where matches were found.
  ```bash
  grep -n "root" /etc/passwd
  ```
* `-v` (Invert Match): Discards matching lines and prints **everything else**.
* `-r` (Recursive Search): Searches for the pattern inside all files under a specified directory tree.
  ```bash
  grep -r "abdullah" /etc/
  ```

---

## 3. Filtering by Position: `head`

The `head` command outputs the first part of a file or stream. By default, it prints the **first 10 lines**.

### Basic Usage:
```bash
abdullah@fedora:~$ head /etc/passwd
```
This prints lines 1 through 10 of `/etc/passwd`.

### Specifying Line Count with `-n`:
To view a specific number of lines from the top, supply the `-n` flag:

```bash
abdullah@fedora:~$ head -n 3 /etc/passwd
root:x:0:0:root:/root:/bin/bash
bin:x:1:1:bin:/bin:/sbin/nologin
daemon:x:2:2:daemon:/sbin:/sbin/nologin
```

```text
 Top of Stream ───► Line 1  ┐
                    Line 2  ├─► Selected by: head -n 3
                    Line 3  ┘
                    Line 4  ─── Dropped
                    Line 5  ─── Dropped
```

---

## 4. Filtering by Position: `tail`

The `tail` command outputs the ending part of a file or stream. By default, it prints the **last 10 lines**.

### Basic Usage:
```bash
abdullah@fedora:~$ tail /etc/passwd
```
This prints the final 10 lines of the file.

### Specifying Line Count with `-n`:
To inspect only the last 3 lines:

```bash
abdullah@fedora:~$ tail -n 3 /etc/passwd
sshd:x:74:74:Privilege-separated SSH:/usr/share/empty.sshd-prv:/usr/sbin/nologin
systemd-coredump:x:999:997:systemd Core Dumper:/:/usr/sbin/nologin
abdullah:x:1000:1000:Abdullah Alzahrani:/home/abdullah:/bin/bash
```

```text
                    Line 20 ─── Dropped
                    Line 21 ─── Dropped
 Bottom of Stream ─►Line 22 ┐
                    Line 23 ├─► Selected by: tail -n 3
                    Line 24 ┘
```

### Real-World Administration: `tail -f`
The `-f` (follow) flag keeps `tail` open, actively monitoring a file and printing new lines in real time as another application writes to them. This is the primary command used to monitor backend application and server logs:

```bash
tail -f /var/log/messages
```

---

## 5. Aggregating Streams: `wc`

The `wc` (word count) command processes an incoming text stream and counts lines, words, and characters.

### Basic Usage:
When run on a file without flags, `wc` outputs three metrics: **newlines**, **words**, and **byte size**:

```bash
abdullah@fedora:~$ wc /etc/hostname
 1  1 15 /etc/hostname
```
*(1 line, 1 word, 15 bytes)*

### Key Flags to Know:
* `-l` (Lines): Counts only newline characters.
  ```bash
  abdullah@fedora:~$ wc -l /etc/passwd
  48 /etc/passwd
  ```
* `-w` (Words): Counts only words (text separated by whitespace).
  ```bash
  abdullah@fedora:~$ wc -w /etc/hostname
  1 /etc/hostname
  ```
* `-c` (Bytes/Characters): Counts raw bytes.

---

## 6. The Critical Link: Filters Listen to `stdin`

Notice how we passed filenames directly to `grep`, `head`, `tail`, and `wc` in the examples above.

However, all of these tools share the exact same foundational behavior as `cat`: **if you do not give them a file, they keep File Descriptor `0` (`stdin`) open and wait for a stream of input.**

### Testing `head` on `stdin`:
```bash
abdullah@fedora:~$ head -n 2
Alpha
Beta
Gamma
```
1. You run `head -n 2`. It pauses and listens to `FD 0` (your keyboard).
2. You type `Alpha`, `Beta`, and `Gamma`.
3. Because `head` was instructed to select 2 lines, it prints `Alpha` and `Beta` to `stdout` and terminates immediately.

### Testing `wc` on `stdin`:
```bash
abdullah@fedora:~$ wc -w
Linux backend development
```
*(Press `Ctrl + D` to send the EOF signal)*
```text
3
```
`wc -w` listened to `FD 0`, counted 3 words, and returned the result to your terminal screen.

---

## Key Takeaways

* **Filter Utilities:** Tools designed to take an input stream, trim out or count data, and emit the useful result to `stdout`.
* **`grep`:** Selects lines containing a specific text pattern (`-i` ignore case, `-n` line numbers, `-v` invert, `-r` recursive).
* **`head`:** Extracts lines starting from the very top (default: 10 lines, `-n` for specific count).
* **`tail`:** Extracts lines starting from the very bottom (default: 10 lines, `-f` to monitor logs in real time).
* **`wc`:** Aggregates streams into counts (`-l` lines, `-w` words, `-c` bytes).
