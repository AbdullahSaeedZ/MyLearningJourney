# Lesson 04-A: Undoing Changes & The Staging Lifecycle

## 1. Resetting the Slate: Deleting a Git Repository

A Git repository is completely self-contained inside the hidden `.git/` folder. If you ever want to completely delete a repository and strip away all tracking while keeping your actual project files intact:

```bash
$ rm -rf .git/
```

After deleting `.git/`, we re-initialized a fresh repository in the same directory:
```bash
$ git init
```

---------------------------------------------------------

## 2. Tracking and Untracking Files: `git rm --cached`

When you stage a file for the first time:
```bash
$ git add file.txt
```

If you decide you do not want Git to track this file at all, but you want to keep the file sitting on your disk in the working directory:

```bash
$ git rm --cached file.txt
```

- `rm`: Remove.
- `--cached`: Remove the reference from the index/staging area only, leaving the working tree file untouched.

---------------------------------------------------------

## 3. Discarding Modifications: The `git restore` Pipeline

Understanding file states between the Three Trees:

```
[ Working Tree ]           [ Staging (Index) ]           [ Repository (.git) ]
================           ===================           =====================
   Edited file                     --                        Last Commit
```

### Scenario 1: Discarding Unstaged Changes in the Working Tree

You make an edit to `file.txt`, but haven't staged it yet:
```
State: Working Tree != (Index == Repo)
```

To throw away your unstaged local changes and revert `file.txt` back to what the index/repo currently has:

```bash
$ git restore file.txt
```

Now: `Working Tree == Index == Repo`. Your local unsaved modifications are discarded.

---

### Scenario 2: Unstaging Changes from the Index

Now let's modify `file.txt` and stage it:
```bash
$ git add file.txt
```

```
State: (Working Tree == Index) != Repo
```

You staged the file, but you realized you aren't ready to commit it. You want to pull it out of staging without losing the edits you made:

```bash
$ git restore --staged file.txt
```

Now: `Working Tree != (Index == Repo)`. The file is un-staged (green `M` becomes red `M`), but your edits are still safely sitting in your working tree!

---

### Scenario 3: Completely Discarding Both Staged and Local Changes

If you want to completely erase the changes from both staging and disk:

```bash
# Step 1: Remove from staging back to working tree
$ git restore --staged file.txt

# Step 2: Discard edits in the working tree
$ git restore file.txt
```

---------------------------------------------------------

## 4. Editing the Last Commit Message: `git commit --amend`

If you committed and made a typo in your commit message, you do not need to create a whole new commit:

```bash
$ git commit --amend
```

This opens your configured editor, letting you modify the message of the most recent commit. Git generates a new commit object with the updated text and replaces the old tip.