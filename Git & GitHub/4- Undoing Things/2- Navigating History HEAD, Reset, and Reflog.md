# Lesson 04-B: Navigating History: HEAD, Reset, and Reflog

## 1. What Is HEAD? Under the Hood

What is `HEAD`? It is simply a text file inside `.git/` that points to whatever branch or commit you are currently looking at in your working tree.

Let's inspect it manually:

```bash
$ cd .git/
$ ls
COMMIT_EDITMSG  HEAD  config  description  hooks  index  info  logs  objects  refs
```

Let's read the contents of `HEAD`:
```bash
$ cat HEAD
ref: refs/heads/main
```

`HEAD` does not store the commit hash directly; it points to the branch reference file `refs/heads/main`.

Now let's check what `main` contains:

```bash
$ cd refs/heads/
asz14@Abdullah MINGW64 /d/Development/testingGit/.git/refs/heads (GIT_DIR!)
$ ls
main

asz14@Abdullah MINGW64 /d/Development/testingGit/.git/refs/heads (GIT_DIR!)
$ cat main
4c92497e4c8bc439aac5096bcb9c8f5acf31f48f
```

`main` holds the SHA-1 of the latest commit! Every time you make a new commit, Git writes the new hash into `refs/heads/main`, and since `HEAD` points to `main`, `HEAD` automatically moves forward.

---------------------------------------------------------

## 2. Visualizing Commits, HEAD, and Branches

Here is our commit history:
```
4c92497 (HEAD -> main) fourth file added to file.txt
3356ca6 third line added to file.txt (edited message)
8cc9331 second line added
6c12004 initial commit
```

Represented as a singly-linked graph:

```
                                                              HEAD
                                                               |
                                                               v
                                                             main
                                                               |
                                                               v
[ C1: 6c12004 ] <--- [ C2: 8cc9331 ] <--- [ C3: 3356ca6 ] <--- [ C4: 4c92497 ]
 (Root Commit)                                                (Latest Commit)
```

---------------------------------------------------------

## 3. The Tilde (`~`) Operator & Relative Diffing

Since `HEAD` represents our current commit hash, we can use it in commands instead of copying full hashes:

```bash
$ git diff 8cc9331..HEAD
```

Git provides the **tilde (`~`)** operator to reference parent commits relatively:
- `HEAD` $\rightarrow$ The current commit.
- `HEAD~1` $\rightarrow$ The 1st parent before HEAD (one commit back).
- `HEAD~2` $\rightarrow$ 2 commits back.
- `HEAD~n` $\rightarrow$ $n$ commits back.

---------------------------------------------------------

## 4. Moving HEAD and the Branch with `git reset`

When you want to roll back to an older commit (for example, moving from C4 back to C3 or C2):

```
                                              HEAD / main
                                              (after reset)
                                                    |
                                                    v
[ C1: 6c12004 ] <--- [ C2: 8cc9331 ] <--- [ C3: 3356ca6 ] <--- [ C4: 4c92497 ]
                                                                      ^
                                                                      |
                                                                 HEAD / main
                                                                  (before)
```

How does this affect the Three Trees?

```
+---------------------------------------------------------------------------------+
|                                 GIT RESET MODES                                 |
+---------------------------------------------------------------------------------+
| Mode        | Moves HEAD/Branch? | Updates Staging (Index)? | Overwrites Disk (WT)? |
|-------------|--------------------|--------------------------|-----------------------|
| --soft      | YES                | NO                       | NO                    |
| --mixed     | YES                | YES (Matches target)     | NO (Keeps edits)      |
|   (default) |                    |                          |                       |
| --hard      | YES                | YES (Matches target)     | YES (Destructive!)    |
+---------------------------------------------------------------------------------+
```

```
+---------------------------------------+
|              Repository               |  <-- HEAD moves back to older commit
+---------------------------------------+
                    |
                    v (updates index in default/--mixed and --hard)
+---------------------------------------+
|             Staging Area              |
+---------------------------------------+
                    |
                    v (ONLY updated if --hard is specified!)
+---------------------------------------+
|             Working Tree              |
+---------------------------------------+
```

Here is our commit history again before moving the head:
```
4c92497 (HEAD -> main) fourth file added to file.txt
3356ca6 third line added to file.txt (edited message)
8cc9331 second line added
6c12004 initial commit
```

### Approach 1: Mixed Reset (`git reset HEAD~n`)
```bash
$ git reset HEAD~2
```
Moves `HEAD` and `main` back 2 commits, resets the staging area to match `HEAD~2`, but leaves your Working Tree intact. The changes that were introduced in `HEAD~1` and `HEAD` will now appear as modified unstaged changes in your working tree.

### Approach 2: Hard Reset (`git reset --hard HEAD~n`)
```bash
$ git reset --hard HEAD~2
HEAD is now at 8cc9331 second line added
```
Moves `HEAD`, updates the staging area, and **overwrites your working tree files** so that disk contents match that older snapshot exactly.

Now let's check our standard log:
```bash
$ git log --oneline
8cc9331 (HEAD -> main) second line added
6c12004 initial commit
```

Commits `3356ca6` and `4c92497` have vanished from `git log`. Are they deleted? **No!** Git objects in `.git/objects` are immutable; only the pointers moved.

---------------------------------------------------------

## 5. The Safety Net: `git reflog`

Standard `git log` traverses backward from where `HEAD` is currently pointing. Because `HEAD` was reset backward to `8cc9331`, `git log` cannot see forward into the orphaned commits.

To see every movement of `HEAD`:

```bash
$ git reflog
8cc9331 (HEAD -> main) HEAD@{0}: reset: moving to HEAD~2
4c92497 HEAD@{1}: commit: fourth file added to file.txt
3356ca6 HEAD@{2}: commit (amend): third line added to file.txt (edited message)
26e4374 HEAD@{3}: commit: third line added to file.txt
8cc9331 (HEAD -> main) HEAD@{4}: commit: second line added
6c12004 HEAD@{5}: commit (initial): initial commit
```

`reflog` (Reference Log) tracks every single place `HEAD` has stood.

### Jumping Forward to Recover History

We can jump back to our newest commit (`4c92497`) using the index position recorded in `reflog` (`HEAD@{1}`):

```bash
$ git reset --hard HEAD@{1}
HEAD is now at 4c92497 fourth file added to file.txt
```

Now let's check `git log`:

```bash
$ git log --oneline
4c92497 (HEAD -> main) fourth file added to file.txt
3356ca6 third line added to file.txt (edited message)
8cc9331 second line added
6c12004 initial commit
```

All your commits and working files are restored.