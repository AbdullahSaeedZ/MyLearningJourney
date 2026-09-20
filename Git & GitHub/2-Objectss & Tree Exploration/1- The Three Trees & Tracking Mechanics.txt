# Lesson 02-A: The Three Trees & Tracking Mechanics

Now we have 3 trees of folders:
1. The working directory
2. The index or staging area
3. The git repo (`.git`)

```
+------------------------+       +------------------------+       +------------------------+
|   Working Directory    |       |      Staging Area      |       |     Git Repository     |
|     (Working Tree)     | ----> |        (Index)         | ----> |     (.git/objects)     |
|                        |       |                        |       |                        |
|  Actual files on disk  |       |  Proposed next commit  |       | Permanent object store |
+------------------------+       +------------------------+       +------------------------+
            |                                |                                |
            v                                v                                v
       Inspect via:                     Inspect via:                     Inspect via:
          `ls`                         `git ls-files`              `find .git/objects -type f`
```

-------------------------------------

1. We can see files in the working tree by using:
```bash
ls
```

2. We can see content (files or OBJECTS) which are in the index (the staging area) by using:
```bash
git ls-files
```

3. To see the content of the git repo, there is no direct command for it, but we can access it using Linux commands:
```bash
find .git/objects/ -type f
```

---------------------------------------

We want to explore how files and trees—blobs and trees (objects)—are tracked by the index file once any file is added to the staging area.

So let's add a file to the index:
```bash
git add file.txt
```
Or using wildcards and such for multiple files:
```bash
git add *.txt
```
Or all files in the current directory:
```bash
git add .
```

```
[Working Directory]        git add file.txt         [Index / Staging Area]
   +------------+        -------------------->         +----------------+
   |  file.txt  |                                      |  file.txt      |
   +------------+                                      | (Tracked Now)  |
                                                       +----------------+
                                                             |
                                                             v Creates Object Immediately
                                                    [.git/objects/e5/1ca0...]
                                                    (Compressed Blob Content)
```

^  
|  
At this moment, we just added the file to the index to be tracked. We still don't have a snapshot of the files because we didn't COMMIT yet.

Use the status command to check:
```bash
git status
```

In the phase of tracking the changes of a file, the index creates a blob object for files and a tree object for folders.

Now check for the index file content:
```bash
git ls-files
```
We will see `file.txt` added there to be tracked.

And each file there is represented by a hash (using SHA-1) and gets compared each time to track if changes happen. Use this command to see the file hashes:
```bash
$ git ls-files -s
100644 e51ca0d0b8c5b6e02473228bbf876ba000932e96 0       file.txt
```

```
Existing Blob Hash:  e51ca0d0b8c5b6e02473228bbf876ba000932e96
                              VS
File Modified on Disk -> Generates New Hash: 4b825dc...
                              ||
                      Hashes Do Not Match
                              ||
                              v
                   Status flagged as: MODIFIED
```

Once a change happens in any tracked file, Git will generate a new hash and compare it to the existing hash of the same file. If it is not the same, then the file status will be MODIFIED.

This index file and the objects created to track files and folders are in the Git repo inside a folder called `objects`.

Now if we check the object directory, we will see a new folder and a blob inside it:
```bash
$ find .git/Objects/ -type f
.git/Objects/e5/1ca0d0b8c5b6e02473228bbf876ba000932e96
```

Notice that for ordering and organizing purposes, Git uses the first 2 characters of the hash to create a folder, and the remaining characters for the object file itself:

```
Full SHA-1:  e51ca0d0b8c5b6e02473228bbf876ba000932e96
             ^^ \____________________________________/
             |                        |
         Directory                File Name
             |                        |
             v                        v
     .git/objects/e5/   1ca0d0b8c5b6e02473228bbf876ba000932e96
```

---------------------------------------------------------

Now we know that this hash is representing our text file object. But what if we have 30 objects here and all of them are hashes? How can we know which is which?

We use this command to read the content of the object by providing flags or parameters:
- `-t` for type
- `-s` for size
- `-p` for content (pretty-print)

```bash
$ git cat-file -t e51ca0d0b8c5b6e02473228bbf876ba000932e96
blob
```

In this stage, we are just seeing how objects are created and saved for tracking changes. We still don't have snapshots or versions of our tracked files.
