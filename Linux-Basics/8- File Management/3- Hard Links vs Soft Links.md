# Hard Links vs Soft Links with ln

Now that we understand that a file consists of three distinct layers (Filename $\rightarrow$ Inode $\rightarrow$ Data Blocks), Linux links become straightforward.

A link is a mechanism that allows a file to be accessed from multiple locations under different names. In Linux, there are two distinct types of links: **Hard Links** and **Soft Links** (Symbolic Links). Both are created using the **`ln`** command.

---

## 1. Hard Links: Direct Inode Pointers

A **Hard Link** is simply an additional directory entry (filename) that points directly to an **existing inode number**.

```text
 Filename: file1.txt ──┐
                       ├──> Inode #3458129 ──> [ Data Blocks on Disk ]
 Filename: file2.txt ──┘
```

### Creating a Hard Link
The syntax is `ln <target_file> <link_name>`:

```bash
abdullah@fedora:~$ echo "Core database credentials" > original.txt
abdullah@fedora:~$ ln original.txt hardlink.txt
```

Verify with `ls -li`:

```bash
abdullah@fedora:~$ ls -li original.txt hardlink.txt
3458129 -rw-r--r--. 2 abdullah abdullah 26 Oct 31 09:00 hardlink.txt
3458129 -rw-r--r--. 2 abdullah abdullah 26 Oct 31 09:00 original.txt
```

### Key Behaviors of Hard Links:
1. **Identical Inode:** Both `original.txt` and `hardlink.txt` share inode number **`3458129`**. They are not two copies of a file; they are two names for the exact same file.
2. **Link Counter Increments:** Look at column 3 (after permissions): the number changed from `1` to **`2`**. This counter tracks how many directory entries point to that inode.
3. **Survives Deletion:** If you delete `original.txt`:
   ```bash
   abdullah@fedora:~$ rm original.txt
   abdullah@fedora:~$ cat hardlink.txt
   Core database credentials
   ```
   The data blocks are **not** wiped from disk. The system merely decrements the inode link counter from `2` to `1`. Data blocks are only marked as free space when the link counter reaches **`0`** and no open process has the file open.
4. **Modifications Are Instant:** Editing `hardlink.txt` immediately affects `original.txt` because both open the exact same data blocks.

### Constraints of Hard Links:
- **Cannot Cross Filesystems / Partitions:** Inode numbers are only unique within a single filesystem. An inode `3458129` on `/` has no relation to inode `3458129` on a separate `/home` or USB drive partition.
- **Cannot Link Directories:** To prevent infinite circular directory loops, standard Linux filesystems do not allow regular users or administrators to hard-link directories.

---

## 2. Soft Links (Symbolic Links): Path Pointers

A **Soft Link** (or symlink) works like a desktop shortcut in Windows. It is an independent, distinct file with its own unique inode number and its own data block. The content stored inside its data block is simply a **text string containing the path** to the target file.

```text
 Filename: softlink.txt ──> Inode #3458190 ──> [ Text: "/home/abdullah/original.txt" ]
                                                              │
                                                              ▼
 Filename: original.txt ──> Inode #3458129 ──> [ Data Blocks on Disk ]
```

### Creating a Soft Link
To create a symbolic link, supply the **`-s`** (symbolic) flag:

```bash
abdullah@fedora:~$ ln -s target.txt symlink.txt
```

Verify with `ls -li`:

```bash
abdullah@fedora:~$ ls -li target.txt symlink.txt
3458129 -rw-r--r--. 1 abdullah abdullah 18 Oct 31 09:05 target.txt
3458190 lrwxrwxrwx. 1 abdullah abdullah 10 Oct 31 09:06 symlink.txt -> target.txt
```

### Key Behaviors of Soft Links:
1. **Unique Inode:** Notice `symlink.txt` has its own inode (**`3458190`**).
2. **File Type Indicator:** The first character in permissions is **`l`** (symbolic link), and `ls` prints an arrow (`->`) pointing to the target.
3. **File Size Matches Path Length:** Notice the size of `symlink.txt` is `10` bytes—the exact character length of the text string `"target.txt"`.
4. **Dangling (Broken) Links:** If you remove or move `target.txt`:
   ```bash
   abdullah@fedora:~$ rm target.txt
   abdullah@fedora:~$ cat symlink.txt
   cat: symlink.txt: No such file or directory
   ```
   The symlink still exists, but it points to a path that no longer exists. This is called an **orphaned or dangling symlink** (often highlighted in red blinking text in modern terminals).

### Advantages of Soft Links:
- **Can Cross Filesystems:** Because it references a path string rather than an internal filesystem inode, a symlink on `/home` can point to `/mnt/storage/data`.
- **Can Point to Directories:** You can symlink entire directory trees cleanly.

---

## 3. Side-by-Side Comparison

```text
┌──────────────────────────────┬──────────────────────────────┬──────────────────────────────┐
│ Feature                      │ Hard Link                    │ Soft (Symbolic) Link         │
├──────────────────────────────┼──────────────────────────────┼──────────────────────────────┤
│ Command                      │ ln target link               │ ln -s target link            │
│ Inode Number                 │ Shares target's inode        │ Gets its own unique inode    │
│ Link Count on Target Inode   │ Increments by 1              │ Does not change target count │
│ Crosses Filesystems?         │ No (same partition only)     │ Yes                          │
│ Can Link Directories?        │ No                           │ Yes                          │
│ If Original File Is Deleted  │ Data remains fully intact    │ Link breaks (dangling link)  │
│ Permissions Display          │ Matches target permissions   │ Displays lrwxrwxrwx          │
└──────────────────────────────┴──────────────────────────────┴──────────────────────────────┘
```

---

## 4. Summary Reference

```text
┌──────────────────────────────┬────────────────────────────────────────────────────────┐
│ Command Pattern              │ Action Performed                                       │
├──────────────────────────────┼────────────────────────────────────────────────────────┤
│ ln <target> <link>           │ Creates a hard link pointing to target's inode.        │
│ ln -s <target> <link>        │ Creates a symbolic link containing path to target.     │
│ ls -li <file1> <file2>       │ Displays inode numbers and link counters for comparison│
│ unlink <link> / rm <link>    │ Removes a link without affecting the underlying data   │
│                              │ (unless hard link counter drops to 0).                 │
└──────────────────────────────┴────────────────────────────────────────────────────────┘
```

---

## Key Takeaways

- **Hard Links Share Inodes:** A hard link creates a new filename referencing an existing inode; both names are completely equal peers.
- **Link Counting:** The kernel keeps data on disk until the inode link count reaches zero and all processes referencing it are closed.
- **Soft Links Store Paths:** A symlink is an independent file whose content is merely a path string pointing elsewhere.
- **Broken Links:** Deleting the target breaks a symlink, whereas a hard link continues to access the physical data blocks.
- **Flexibility:** Use soft links (`ln -s`) whenever linking across different storage drives or linking entire directory structures.