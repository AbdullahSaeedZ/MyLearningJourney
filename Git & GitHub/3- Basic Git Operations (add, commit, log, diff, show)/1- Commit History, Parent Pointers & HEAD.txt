## 1. Staging Status: Red M vs. Green M

When modifying a file that is already tracked, but without staging or committing it yet:

```bash
$ git status -s
 M file.txt
?? .idea/
```

- **`M` in red (in the second column):** The file has modifications in your working directory that do not match what is recorded in the staging area (index) or in the latest commit snapshot.

Once we stage it:

```bash
$ git add .
$ git status -s
M  file.txt
?? .idea/
```

- **`M` in green (in the first column):** The file is now modified and staged. It is prepared for the next commit, but it does not yet match the last committed version in the repository object database.

```
Working Directory               Staging Area (Index)              Repo (.git/objects)
+-------------------+          +--------------------+           +--------------------+
| file.txt (Edited) |  ----->  |  file.txt (Staged) |  ------>  |  Last Commit Blob  |
+-------------------+          +--------------------+           +--------------------+
         ^                               ^
         |                               |
    [ M in red ]                   [ M in green ]
(Working vs Index)                 (Index vs Repo)
```

---------------------------------------------------------

## 2. Exploring Multiple Commit Objects: The Parent Pointer

Now that we have created a second commit, let's inspect its contents directly:

```bash
$ git cat-file -p 3cf4d99a
tree ab54e24020e0b57ad91a91d6f01b592c80010d31
parent 0f0f286fa3d65ede93d8b5b246e019dc5c9a8bf3
author Abdullah Saeed <asz1095136568@gmail.com> 1789926851 +0300
committer Abdullah Saeed <asz1095136568@gmail.com> 1789926851 +0300

added a second line to file.txt
```

Notice a critical structural addition:
- In our first commit object, there was **no parent line**. A commit with no parent is called a **root commit**.
- In this second commit object, we now see a `parent` hash: `0f0f286...`, which points directly to the first commit.

### How Git Tracks History Internally

Git does not maintain history by building a list from oldest to newest. Instead, Git behaves like a **singly-linked list** where each commit holds an immutable cryptographic pointer backward to its parent:

```
[ Root Commit: 0f0f286 ] <---------- [ Second Commit: 3cf4d99 ]
(Has NO parent pointer)              (parent: 0f0f286)
```

---------------------------------------------------------

## 3. What Is a Branch?

A branch in Git is essentially a named, movable pointer to a linear sequence of commits:

```
(Timeline / Commit Graph)

[ 0f0f286 ] <--- [ 3cf4d99 ] <--- [ 21731eb ] <=== main / master
(Root commit)     (Commit 2)       (Latest)
```

The key concept is **linearity**. Every new commit builds on top of its parent. The default branch created when initializing a repository is typically called `main` (historically `master`).

---------------------------------------------------------

## 4. The HEAD Pointer

When we have multiple commits in our repository, which commit version do we actually see reflected on disk in the working directory?

By default, we see the latest snapshot. But how does Git keep track of that?

> **HEAD** is an active reference pointer that tells Git which branch or specific commit snapshot is currently checked out in your working directory.


```
                                      HEAD
                                       |
                                       v
                                     main
                                       |
                                       v
[ 0f0f286 ] <--- [ 3cf4d99 ] <--- [ 21731eb ]
(Initial)         (Second)        (Latest Snapshot)
                                       |
                                       v
                         Files visible in Working Tree

``````

When `HEAD` points to `main`, and `main` points to commit `21731eb`, Git populates your working directory with the exact state preserved in commit `21731eb`.

---------------------------------------------------------

## 5. Configuring an External Commit Editor

Instead of writing short commit messages only with `-m`, you can configure Git to open a full GUI or terminal text editor (like VS Code) for writing multi-line, detailed commit descriptions:

```bash
# Configure VS Code as the default Git editor:
$ git config --global core.editor "code --wait"
```

> **Why `--wait`?**  
> The `--wait` flag instructs the terminal process to pause and wait until you finish writing your message and completely close the editor tab before Git finalizes the commit object. Without `--wait`, Git would see an empty message immediately upon launching the editor window and abort the commit!