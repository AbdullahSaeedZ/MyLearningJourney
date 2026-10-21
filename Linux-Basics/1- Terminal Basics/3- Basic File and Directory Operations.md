# Basic File and Directory Operations

This lesson covers how to create, move, copy, and delete files and directories on disk. It treats files as filesystem objects without looking inside their text content.

---

## 1. Creating Files and Directories

### A. `touch` (Update Timestamps & Create Files)
Creates a new blank file if it does not already exist.

```bash
touch notes.txt
touch app.cs models.cs database.cs    # Create multiple files at once
```

> **Important Note:**  
> The **primary design purpose** of `touch` is actually to update the access and modification timestamps of an existing file (without opening or altering its content).  
> However, because it creates an empty file whenever the target does not exist, developers commonly use it as a quick shortcut for creating blank files.

### B. `mkdir` (Make Directory)
Creates one or more new directories (folders).

```bash
mkdir projects
mkdir frontend backend database      # Create multiple directories at once
```

#### Crucial Flag: `-p` (Parents)
By default, `mkdir` throws an error if you try to create nested subfolders whose parent folder does not exist yet. The **`-p` flag** creates all missing parent directories automatically:

```bash
# Fails if "backend" does not exist:
mkdir backend/api/v1

# Works and creates every missing folder in the path:
mkdir -p backend/api/v1
```

---

## 2. Moving and Renaming (`mv`)

In Linux, **moving** a file and **renaming** a file are the exact same command: `mv`.

```bash
mv [SOURCE] [DESTINATION]
```

### Renaming a File
If the destination is a new name in the same directory, the file is renamed:
```bash
mv old_name.txt new_name.txt
```

### Moving a File
If the destination is an existing directory, the file is moved into it:
```bash
mv notes.txt projects/
```

### Moving and Renaming Together
```bash
mv notes.txt projects/todo.txt
```

---

## 3. Copying Files and Folders (`cp`)

Duplicates files or folders from a source to a destination. The original file remains untouched.

```bash
cp [SOURCE] [DESTINATION]
```

### Copying a File
```bash
cp app.cs app_backup.cs
cp app.cs projects/
```

### Copying a Directory: `-r` (Recursive)
By default, `cp` will refuse to copy a folder. You must pass the **`-r` (recursive)** flag to copy the folder and everything inside it:

```bash
# Fails: cp my_folder backup_folder
# Works:
cp -r my_folder backup_folder
```

---

## 4. Deleting Files and Folders (`rm` / `rmdir`)

> ⚠️ **Warning:** Files deleted with `rm` do **not** go to a Trash or Recycle Bin. They are unlinked and permanently deleted immediately.

### Deleting Files (`rm`)
```bash
rm notes.txt
rm file1.txt file2.txt
```

### Deleting Empty Directories (`rmdir`)
Deletes a directory **only if it has zero files or subfolders inside it**:
```bash
rmdir empty_folder
```
If the folder contains even one file, `rmdir` will refuse to touch it.

### Deleting Non-Empty Directories (`rm -r`)
To delete a directory and all files and subfolders inside it, pass the **`-r` (recursive)** flag:
```bash
rm -r old_project/
```

### Suppressing Warnings (`-f` / Force)
The **`-f` flag** suppresses confirmation prompts and avoids errors if the file does not exist:
```bash
rm -rf old_project/
```

> **Safety Rule:** Always run `pwd` first to confirm where you are before running `rm -r` or `rm -rf`.

---

## Summary Reference Table

| Action | Command | Example |
| :--- | :--- | :--- |
| Update timestamp / create blank file | `touch <file>` | `touch program.cs` |
| Create folder | `mkdir <dir>` | `mkdir src` |
| Create nested folders | `mkdir -p <path>` | `mkdir -p src/core/models` |
| Rename / Move | `mv <src> <dest>` | `mv old.txt new.txt` |
| Copy file | `cp <src> <dest>` | `cp config.json config.bak` |
| Copy folder | `cp -r <src> <dest>` | `cp -r src/ src_backup/` |
| Remove file | `rm <file>` | `rm temp.log` |
| Remove empty folder | `rmdir <dir>` | `rmdir empty_dir` |
| Remove folder + content | `rm -rf <dir>` | `rm -rf build/` |