# Deep Filesystem Search with find

While shell globs like `ls *.log` can match files inside a single folder, they fail when you need to search deeply across nested directory trees or filter items by attributes such as file type, size, or modification age. The standard POSIX utility for real-time filesystem discovery is **`find`**.

---

## 1. How `find` Works

`find` does not read from a pre-compiled index. Instead, it starts at a given root path and recursively walks down the directory tree in real time, inspecting filesystem metadata using kernel system calls.

### General Syntax:
```bash
find [starting_path] [search_criteria]
```

- If no path is specified, `find` defaults to the current working directory (`.`).
- If no criteria are specified, `find` lists every single file and directory recursively from that starting point.

```bash
# Recursively list everything under the current directory:
abdullah@fedora:~$ find .
```

---

## 2. Searching by Name: `-name` and `-iname`

To look for files by filename pattern, use the **`-name`** flag.

```bash
# Case-sensitive search for specific files:
abdullah@fedora:~$ find /etc -name "hosts"
/etc/hosts

# Wildcard pattern (always wrap quotes to prevent premature shell expansion):
abdullah@fedora:~$ find /etc -name "*.conf"
```

### Case-Insensitive Search: `-iname`
When searching where the casing may vary (e.g., `.JPG`, `.jpg`, `.Png`), use **`-iname`**:

```bash
abdullah@fedora:~$ find ~/Documents -iname "report*.pdf"
```

> **Why Quotes Matter:** Always wrap search patterns in quotes (`"*.txt"`). Without quotes, your shell (Bash) will attempt to expand the wildcard before passing it to `find`, causing unexpected errors if matching files exist in the current directory.

---

## 3. Controlling Search Depth: `-maxdepth`

By default, `find` crawls as deep as the filesystem tree goes. On large partitions or network mounts, this can take a long time and generate excessive terminal output.

Use **`-maxdepth`** to limit how many directory levels down `find` traverses:

```bash
# Search only directly inside /etc without descending into subdirectories:
abdullah@fedora:~$ find /etc -maxdepth 1 -name "*.conf"

# Search current directory and only 1 level of subfolders:
abdullah@fedora:~$ find . -maxdepth 2 -name "*.log"
```

---

## 4. Filtering by Inode Type: `-type`

Often, a directory and a file might share a similar name, or you may only want to list directories. The **`-type`** flag restricts results by POSIX file type:

```text
┌──────────────┬────────────────────────────────────────────────────────┐
│ Type Flag    │ Matches Target                                         │
├──────────────┼────────────────────────────────────────────────────────┤
│ -type f      │ Regular files (text documents, images, scripts)        │
│ -type d      │ Directories only                                       │
│ -type l      │ Symbolic links (shortcuts)                             │
└──────────────┴────────────────────────────────────────────────────────┘
```

```bash
# Find only directories named "bin" inside /usr:
abdullah@fedora:~$ find /usr -maxdepth 2 -type d -name "bin"
/usr/bin

# Find only regular files ending with .sh:
abdullah@fedora:~$ find ~/scripts -type f -name "*.sh"
```

---

## 5. Filtering by Size and Modification Time

`find` can query file metadata directly without reading file contents.

### A. Searching by File Size: `-size`
Use size suffixes: `c` (bytes), `k` (kilobytes), `M` (megabytes), `G` (gigabytes). Prepend `+` for larger than, or `-` for smaller than:

```bash
# Find files strictly larger than 100 Megabytes:
abdullah@fedora:~$ find /var/log -type f -size +100M

# Find files smaller than 1 Kilobyte:
abdullah@fedora:~$ find ~/Projects -type f -size -1k
```

### B. Searching by Age: `-mtime` and `-mmin`
- **`-mtime` (Modification Days):** Time since file contents were last modified in 24-hour intervals.
- **`-mmin` (Modification Minutes):** Time since file contents were modified in minutes.

```bash
# Find files modified within the last 24 hours:
abdullah@fedora:~$ find /var/log -type f -mtime -1

# Find files modified more than 30 days ago (ideal for pruning old logs):
abdullah@fedora:~$ find /var/log -type f -mtime +30

# Find files modified in the last 15 minutes:
abdullah@fedora:~$ find /tmp -type f -mmin -15
```

---

## 6. A Note on `locate`

You may encounter another command called **`locate`** (or `plocate` / `mlocate`).

- **How it works:** Instead of scanning disks live, `locate` queries a pre-indexed database (usually `/var/lib/mlocate/mlocate.db`) generated periodically by a background service called **`updatedb`**.
- **Pros:** It returns results almost instantly because it just looks up an index.
- **Cons & Why It Is Often Skipped:**
    1. **Stale Results:** If you create, rename, or delete a file right now, `locate` will not know about it until the indexer runs again.
    2. **Not Pre-Installed:** Many modern, minimal, or container-based Linux distributions do not include it by default.
    3. **No Dynamic Filtering:** It cannot filter by file permissions, size limits, or real-time modification age like `find` does.

---

## 7. Summary Reference

```text
┌──────────────────────────────┬────────────────────────────────────────────────────────┐
│ Syntax                       │ Practical Search Function                              │
├──────────────────────────────┼────────────────────────────────────────────────────────┤
│ find <path>                  │ Recursively lists all items starting from path.        │
│ find <path> -name "*.txt"    │ Case-sensitive search by filename pattern.             │
│ find <path> -iname "*.txt"   │ Case-insensitive search by pattern.                    │
│ find <path> -maxdepth <N>    │ Limits search depth to N directory levels.             │
│ find <path> -type f / -type d│ Restricts results to regular files or directories.     │
│ find <path> -size +50M       │ Finds files larger than 50 Megabytes.                  │
│ find <path> -mtime -7        │ Finds files modified within the last 7 days.           │
│ locate <name>                │ Fast lookup via static database (may return stale data)│
└──────────────────────────────┴────────────────────────────────────────────────────────┘
```

---

## Key Takeaways

- **Real-Time Discovery (`find`):** Traverses the live filesystem tree, ensuring search results always reflect the current state of the machine.
- **Quote Patterns:** Always wrap wildcard patterns in quotes (`"*.conf"`) so the shell does not expand them before `find` receives the pattern.
- **Depth Control:** Use `-maxdepth` to prevent long, unnecessary traversals into deep directories.
- **Metadata Filters:** `find` combines easily with flags like `-type`, `-size`, and `-mtime` to pinpoint exact system files without external scripts.