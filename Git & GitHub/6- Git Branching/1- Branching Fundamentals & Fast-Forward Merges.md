# Lesson 06: Branching Fundamentals & Fast-Forward Merges

## 1. Revision: How Git Stores Objects

Before jumping into branching, let's review how Git stores data internally.

Git models project history as an immutable graph of commit objects. Every commit object links backward to its parent, points to a root tree object representing the project directory, and that tree points to blob objects containing raw file data:

```
+-----------------------------------------------------------------------------+
|                               COMMIT GRAPH                                  |
+-----------------------------------------------------------------------------+

                                                        HEAD
                                                         |
                                                         v
                                                       main
                                                         |
                                                         v
[ e7bb678 ] <------------ [ aaa6ccf ] <------------ [ 8be982d ]
(Root Commit)             (Second Commit)           (Third Commit)
      |                         |                         |
      v                         v                         v
+-----------+             +-----------+             +-----------+
| Root Tree |             | Root Tree |             | Root Tree |
+-----------+             +-----------+             +-----------+
   |      \                  |      \                  |      \
   v       v                 v       v                 v       v
[blob]   [blob]            [blob]   [blob]            [blob]   [blob]
(file1)  (file2)           (file1)  (file2)           (file1)  (file2)
```

Up to this point, our commits formed a single, unbroken chain. This is called **linear development**—every update happens right after the previous one on the exact same line.

---------------------------------------------------------

## 2. What Is a Branch? (Non-Linear Development)

A branch in Git is simply a **lightweight, movable pointer** to a specific commit.

Branching allows you to diverge from the main line of development to build features, fix bugs, or experiment safely without destabilizing the production code on `main`.

```
                                    +---> [ Feature Branch ]  (Experimental Work)
   [ Main Branch ]                 /
 (Stable Production)              /
[ Common Base Commit ] ----------+
                               
```

This creates **non-linear development**: work can happen in parallel across multiple timelines.

---------------------------------------------------------

## 3. Creating and Inspecting Branches

To create a new branch:
```bash
git branch <branch-name>
```

To list all existing local branches:
```bash
git branch
```

Let's create a branch named `testing`:

```bash
asz14@Abdullah MINGW64 /d/Development/testingGit (main)
$ git branch testing

asz14@Abdullah MINGW64 /d/Development/testingGit (main)
$ git branch
* main
  testing
```

- The asterisk `*` and green text mark the **currently active branch** (`main`). Any commit made now will belong to `main`.

### Inspecting History with Graph Flags

To see where branches and `HEAD` currently stand:

```bash
$ git log --oneline --decorate --graph --all
* 8be982d (HEAD -> main, testing) third line added
* aaa6ccf second line added
* e7bb678 initial commit
```

> **Breakdown of flags:**
> - `--oneline`: Compact output showing only hash and message.
> - `--decorate`: Shows branch pointers, tags, and `HEAD`.
> - `--graph`: Draws a visual text-based ASCII branch tree.
> - `--all`: Shows commits from all branches, not just the currently active one.

Both `main` and `testing` point to the exact same commit (`8be982d`). `HEAD` points to `main`.

```
                                          HEAD
                                           |
                                           v
                                          main      testing
                                             \         /
                                              v       v
[ e7bb678 ] <------------ [ aaa6ccf ] <--- [ 8be982d ]
```

---------------------------------------------------------

## 4. Switching Branches

To switch between branches, use `git switch` (the modern, clearer alternative to `git checkout`):

```bash
asz14@Abdullah MINGW64 /d/Development/testingGit (main)
$ git switch testing
Switched to branch 'testing'

asz14@Abdullah MINGW64 /d/Development/testingGit (testing)
$ git status
On branch testing

asz14@Abdullah MINGW64 /d/Development/testingGit (testing)
$ git log --oneline --decorate --graph --all
* 8be982d (HEAD -> testing, main) third line added
* aaa6ccf second line added
* e7bb678 initial commit
```

`HEAD` now points to `testing`.

```
                                                     HEAD
                                                      |
                                                      v
                                           main    testing
                                             \       /
                                              v     v
[ e7bb678 ] <------------ [ aaa6ccf ] <--- [ 8be982d ]
```

---------------------------------------------------------

## 5. Committing on the New Branch

Let's add a fourth line to `file.txt` and commit while inside `testing`:

```bash
$ git log --oneline --decorate --graph --all
* 60453ee (HEAD -> testing) fourth line added in testing branch
* 8be982d (main) third line added
* aaa6ccf second line added
* e7bb678 initial commit
```

Let's verify the commit payload using `git show`:

```bash
$ git show HEAD --oneline
60453ee (HEAD -> testing) fourth line added in testing branch
diff --git a/file.txt b/file.txt
index 64b04bc..a2e3154 100644
--- a/file.txt
+++ b/file.txt
@@ -1,3 +1,4 @@
 Hello, Git
 second line in file
 third line in file
+fourth line in file in testing branch
```

The pointer layout is now:

```
                                                        HEAD
                                                         |
                                                         v
                                                       testing
                                                         |
                                                         v
                                                     [ 60453ee ]
                                                     (4th line added)
                                                         |
                                          main           |
                                             \           |
                                              v          |
[ e7bb678 ] <------- [ aaa6ccf ] <------- [ 8be982d ] <--+
(Initial)            (2nd line)           (3rd line)
```

---------------------------------------------------------

## 6. Switching Back to Main

When switching back to `main`, Git updates the working tree on disk to match the snapshot saved at `main`'s commit:

```bash
asz14@Abdullah MINGW64 /d/Development/testingGit (testing)
$ git switch main
Switched to branch 'main'

asz14@Abdullah MINGW64 /d/Development/testingGit (main)
$ git log --oneline --decorate --graph --all
* 60453ee (testing) fourth line added in testing branch
* 8be982d (HEAD -> main) third line added
* aaa6ccf second line added
* e7bb678 initial commit
```

`file.txt` on your disk reverts back to 3 lines because `HEAD` is once again attached to `main` at `8be982d`.

---------------------------------------------------------

## 7. Fast-Forward Merging

`testing` is now 1 commit ahead of `main`. Because no new commits were added to `main` in the meantime, the history remains completely direct.

```
                                                              testing
                                                                 |
                                                                 v
                                                            [ 60453ee ]
                                                            (4th line)
                                                                 |
                                             HEAD                |
                                              |                  |
                                              v                  |
                                             main                |
                                              |                  |
                                              v                  v
[ e7bb678 ] <------- [ aaa6ccf ] <------- [ 8be982d ] <----------+
(Initial)            (2nd line)           (3rd line)
```

To merge `testing` into `main`:
1. Switch to the target branch (`main`).
2. Run `git merge testing`.

```bash
asz14@Abdullah MINGW64 /d/Development/testingGit (main)
$ git merge testing
Updating 8be982d..60453ee
Fast-forward
 file.txt | 1 +
 1 file changed, 1 insertion(+)
```

### What Is a Fast-Forward?
Because there was no conflicting work on `main`, Git did not need to compute an algorithm or build a merge commit. It simply slid the `main` pointer forward to match `testing`:

```
                                                                 HEAD
                                                                  |
                                                                main     testing
                                                                  \        /
                                                                   v      v
[ e7bb678 ] <-------- [ aaa6ccf ] <-------- [ 8be982d ] <-------- [ 60453ee ]
(Initial)             (2nd line)            (3rd line)            (4th line)
```
Check the log after the merge:
```bash
asz14@Abdullah MINGW64 /d/Development/testingGit (main)
$ git log --oneline --decorate --graph --all
* 60453ee (HEAD -> main, testing) fourth line added in testing branch
* 8be982d third line added
* aaa6ccf second line added
* e7bb678 initial commit
```

---------------------------------------------------------

## 8. Branch Cleanup and Deletion

To see which branches have already been integrated into your current branch:

```bash
$ git branch --merged
* main
  testing
```

Since `testing` is fully merged, its pointer is redundant. Delete it safely with `-d`:

```bash
asz14@Abdullah MINGW64 /d/Development/testingGit (main)
$ git branch -d testing
Deleted branch testing (was 60453ee).
```