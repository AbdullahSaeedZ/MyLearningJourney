# Extracting Columns with cut

While filters like `grep`, `head`, and `tail` select or remove entire horizontal lines from a stream, the **`cut`** utility extracts vertical columns (called **fields** or **characters**) from each line.

It is particularly useful for parsing structured, delimited text files such as `/etc/passwd`, CSV reports, or command outputs.

---

## 1. How `cut` Works

`cut` reads text line by line and slices out specific sections based on a boundary marker called a **delimiter**.

```text
Row:   root : x : 0 : 0 : root : /root : /bin/bash
       ────   ─   ─   ─   ────   ─────   ─────────
Field:  1     2   3   4     5      6         7
              ▲
              │ (Delimiter: :)
```

By default, if you don't tell it which delimiter to look for, `cut` assumes tab characters. For files with different separators (like commas or colons), you configure two primary flags:
- **`-d` (Delimiter):** Specifies the character used to separate fields (e.g., `-d ':'` or `-d ','`).
- **`-f` (Fields):** Specifies which column number(s) to extract.

---

## 2. Basic Usage: Parsing Delimited Text

The `/etc/passwd` file defines user accounts using colons (`:`) as field separators:

```text
username:password:UID:GID:comment:home_directory:shell
```

### A. Extracting a Single Field
To extract only the first field (the usernames):

```bash
abdullah@fedora:~$ cut -d ':' -f 1 /etc/passwd
root
bin
daemon
abdullah
```

```text
 ┌──────────────────────────────────────────────┐
 │                  /etc/passwd                 │
 │  root:x:0:0:root:/root:/bin/bash             │
 └──────────────────────┬───────────────────────┘
                        │
                        ▼ (cut -d ':' -f 1)
 ┌──────────────────────────────────────────────┐
 │ root                                         │ ──> FD 1 (stdout)
 └──────────────────────────────────────────────┘
```

### B. Extracting Multiple Fields
You can specify multiple fields separated by commas, or as a range using a hyphen:

- **Specific fields:**
  ```bash
  # Extracts Field 1 (username) and Field 7 (default shell)
  abdullah@fedora:~$ cut -d ':' -f 1,7 /etc/passwd
  root:/bin/bash
  bin:/sbin/nologin
  abdullah:/bin/bash
  ```

- **Field ranges:**
  ```bash
  # Extracts Fields 1 through 3
  abdullah@fedora:~$ cut -d ':' -f 1-3 /etc/passwd
  root:x:0
  ```

---

## 3. Cutting by Character Position (`-c`)

When input is not structured with delimiters, you can slice lines by exact character index using the **`-c`** flag:

```bash
abdullah@fedora:~$ echo "ABCDEF12345" | cut -c 1-6
ABCDEF
```

---

## 4. `cut` Inside Pipelines

`cut` accepts input from both file arguments and standard input (`stdin`). This allows it to act as an intermediate stage in a pipeline:

```bash
abdullah@fedora:~$ cat /etc/passwd | grep "/bin/bash" | cut -d ':' -f 1
root
abdullah
```

```text
 ┌───────────────────┐
 │ cat /etc/passwd   │
 └─────────┬─────────┘
           │ (stdout)
           ▼
 ┌───────────────────┐
 │ grep "/bin/bash"  │ (Filters only bash users)
 └─────────┬─────────┘
           │ (stdout)
           ▼
 ┌───────────────────┐
 │ cut -d ':' -f 1   │ (Extracts only username column)
 └─────────┬─────────┘
           │ (stdout)
           ▼
 ┌───────────────────┐
 │ Terminal Display  │
 └───────────────────┘
```

---

## Key Takeaways

- **Core Purpose:** `cut` extracts vertical columns (fields) or character ranges out of a text stream.
- **Key Delimiter Flags:**
    - `-d '<char>'`: Defines the delimiter separating columns.
    - `-f <N>`: Selects field number(s) (e.g., `-f 1`, `-f 1,3`, `-f 2-5`).
- **Character Flag:** `-c <range>` extracts exact character positions instead of delimited fields.
- **Pipeline Citizen:** Sits cleanly along a pipeline to isolate single columns from multi-column command outputs.