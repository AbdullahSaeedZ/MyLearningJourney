## 1. Comparing Differences Across the Three Trees

Now let's add a 3rd line to `file.txt`, save it, but leave it unstaged and uncommitted.

To see what changes exist between our edited working directory and what the index currently tracks:

```bash
$ git diff
diff --git a/file.txt b/file.txt
index 1cac8af..8f9952e 100644
--- a/file.txt
+++ b/file.txt
@@ -1,2 +1,3 @@
 Hello Git
-Second line in file.txt
\ No newline at end of file
+Second line in file.txt
+Third line in file.txt
\ No newline at end of file
```

The newly added line is shown in green. This shows the difference between the **working tree** and the **index (staging area)**.

```
       [ Working Directory ]
                 |
                 |  git diff  (Compares working edits vs. index)
                 v
       [ Staging Area (Index) ]
                 |
                 |  git diff --staged  (Compares staged changes vs. repository)
                 v
       [ Repository (.git Objects) ]
```

### Staging the Changes

Let's stage the file:

```bash
$ git add file.txt
$ git status -s
M  file.txt
?? .idea/
```

Now run `git diff` again:

```bash
$ git diff
```

It returns nothing! Why? Because your working tree and your staging area now match perfectly.

### Comparing Staged vs. Committed (`--staged`)

Even though the working tree matches the index, the staged changes still do not match the previous commit snapshot in `.git/objects`.

To compare the staging area against the latest commit:

```bash
$ git diff --staged
diff --git a/file.txt b/file.txt
index 1cac8af..8f9952e 100644
--- a/file.txt
+++ b/file.txt
@@ -1,2 +1,3 @@
 Hello Git
-Second line in file.txt
\ No newline at end of file
+Second line in file.txt
+Third line in file.txt
\ No newline at end of file
```

> **Note:** `git diff --cached` is an exact synonym for `git diff --staged`.

---------------------------------------------------------

## 2. Inspecting and Filtering the Commit Log

Once we commit our changes, we can inspect repository history using different log views:

```bash
$ git log --oneline
21731eb (HEAD -> main) third line added
3cf4d99 added a second line to file.txt
0f0f286 initail commit
```

### Practical Log Filters

1. **Filter by specific file:**  
   Inspect only commits that touched a given file:
   ```bash
   $ git log --oneline file.txt
   21731eb (HEAD -> main) third line added
   3cf4d99 added a second line to file.txt
   0f0f286 initail commit
   ```

2. **Limit by commit count:**  
   Show only the latest $N$ commits:
   ```bash
   $ git log --oneline -2
   21731eb (HEAD -> main) third line added
   3cf4d99 added a second line to file.txt
   ```

3. **Show inline file diffs inside the log:**
   ```bash
   $ git log -p -1
   ```

4. **Show commit statistics (files changed, insertions, deletions):**
   ```bash
   $ git log --stat -2
   ```

---------------------------------------------------------

## 3. Practical Snapshot Inspection: `git show`

Earlier, we manually traversed the object graph:
`Commit -> Tree -> Blob -> cat-file -p`

While manual traversal is great for understanding internals, `git show` automates the entire process in one quick command:

```bash
$ git show 3cf4d99
commit 3cf4d99ad824137709bf498ceb4050a4aadf515a
Author: Abdullah Saeed <asz1095136568@gmail.com>
Date:   Sun Sep 20 20:54:11 2026 +0300

    added a second line to file.txt

diff --git a/file.txt b/file.txt
index e51ca0d..1cac8af 100644
--- a/file.txt
+++ b/file.txt
@@ -1 +1,2 @@
-Hello Git
\ No newline at end of file
+Hello Git
+Second line in file.txt
\ No newline at end of file
```

`git show` displays the commit metadata, author information, commit message, and the exact diff introduced by that specific commit.

---------------------------------------------------------

## 4. Comparing Two Arbitrary Historic Commits

What if we want to compare two older versions directly against each other, even when our working directory is completely clean?

```
Working Tree == Staging Area == Latest Commit (HEAD)
```

Running `git diff` or `git diff --staged` will output nothing because there are no pending working changes.

Instead, we use two-dot syntax to compare two arbitrary snapshots:

```
Syntax: git diff <older-commit>..<newer-commit>
```

First, let's verify our commit hashes:

```bash
$ git log --oneline
21731eb (HEAD -> main) third line added
3cf4d99 added a second line to file.txt
0f0f286 initail commit
```

Now let's compare the root commit against the second commit:

```bash
$ git diff 0f0f286..3cf4d99
diff --git a/file.txt b/file.txt
index e51ca0d..1cac8af 100644
--- a/file.txt
+++ b/file.txt
@@ -1 +1,2 @@
-Hello Git
\ No newline at end of file
+Hello Git
+Second line in file.txt
\ No newline at end of file
```

Git reads the root tree of `0f0f286`, reads the root tree of `3cf4d99`, traverses to their respective blobs, and computes the unified diff directly between them.