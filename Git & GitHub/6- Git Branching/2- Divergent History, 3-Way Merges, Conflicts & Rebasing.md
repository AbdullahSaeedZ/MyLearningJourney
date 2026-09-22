# Lesson 07: Divergent History, 3-Way Merges, Conflicts & Rebasing

## 1. Creating Divergent History

In real projects, workflows are rarely completely linear. While you work on a feature branch, your teammates might commit updates to `main`. 

Let's recreate this divergent workflow:

```bash
# Step 1: Create and switch to a new branch
$ git branch testing
$ git switch testing

# Step 2: Make changes, stage, and commit on testing
$ git log --oneline --decorate --graph --all
* c035e15 (HEAD -> testing) fifth line added to file in testing branch
* 60453ee (main) fourth line added in testing branch
* 8be982d third line added
* aaa6ccf second line added
* e7bb678 initial commit
```

Now let's switch back to `main` and introduce new work there too:

```bash
$ git switch main
$ echo "Line one in new file in main branch" >> file2.txt
$ git add file2.txt
$ git commit -m "added new file in main branch"
```

Let's look at the graph:

```bash
$ git log --oneline --decorate --graph --all
* c455fbf (HEAD -> main) added new file in main branch
| * c035e15 (testing) fifth line added to file in testing branch
|/  
* 60453ee fourth line added in testing branch
* 8be982d third line added
* aaa6ccf second line added
* e7bb678 initial commit
```

### Visualizing the Divergence

```
                    +---> [ c035e15 ] (testing: modified file.txt)
                    |
[ 60453ee ] (Base) -+
                    |
                    +---> [ c455fbf ] (main: added file2.txt)
```

The branches split from commit `60453ee`:
- On `main`: Two files exist (`file.txt`, `file2.txt`).
- On `testing`: Only one file exists (`file.txt`), with its own edits.

```bash
# ls in main
asz14@Abdullah MINGW64 /d/Development/testingGit (main)
$ ls
file.txt  file2.txt

# ls in testing
asz14@Abdullah MINGW64 /d/Development/testingGit (testing)
$ ls
file.txt
```

---------------------------------------------------------

## 2. Resolving Divergence: The 3-Way Merge

Because both branches evolved independently, Git cannot perform a simple Fast-Forward. It cannot just move the pointer.

Git uses a **3-way merge** strategy (using the default `ort` engine). It compares:
1. **The Common Ancestor:** Commit `60453ee`.
2. **Branch A Tip:** `c455fbf` (`main`).
3. **Branch B Tip:** `c035e15` (`testing`).

```bash
asz14@Abdullah MINGW64 /d/Development/testingGit (main)
$ git merge testing
Merge made by the 'ort' strategy.
 file.txt | 1 +
 1 file changed, 1 insertion(+)
```

### The Merge Commit Object

Git constructs a brand-new commit called a **merge commit**. Unlike normal commits, a merge commit has **two parent pointers**:

```bash
$ git log --oneline --decorate --graph --all
*   f0a5751 (HEAD -> main) 3-way merge branch 'testing'
|\  
| * c035e15 (testing) fifth line added to file in testing branch
* | c455fbf added new file in main branch
|/  
* 60453ee fourth line added in testing branch
* 8be982d third line added
* aaa6ccf second line added
* e7bb678 initial commit
```

```
                     +---> [ c035e15 ] (testing) ---+
                     |                              |
[ 60453ee ] ---------+                              v
 (Base)              +---> [ c455fbf ] (main) -----> [ f0a5751 ] (Merge Commit)
                                                         ^
                                                         |
                                                    HEAD -> main
```

---------------------------------------------------------

## 3. Handling Merge Conflicts

A **merge conflict** occurs when changes are made to the **exact same lines of the exact same file** on both branches. Git pauses the merge and asks the user to decide which lines to keep.

### Step 1: Triggering a Conflict (Example)
On `main`, line 1 of `file.txt` is modified to:
```text
Hello, Git from Main
```
On `testing`, line 1 of `file.txt` is modified to:
```text
Hello, Git from Testing
```

When you run `git merge testing`, Git flags the conflict:
```bash
$ git merge testing
Auto-merging file.txt
CONFLICT (content): Merge conflict in file.txt
Automatic merge failed; fix conflicts and then commit the result.
```

### Step 2: Conflict Markers Inside the File
Opening `file.txt` reveals Git's conflict markers:

```text
<<<<<<< HEAD
Hello, Git from Main
=======
Hello, Git from Testing
>>>>>>> testing
```

- Content between `<<<<<<< HEAD` and `=======` comes from your current branch (`main`).
- Content between `=======` and `>>>>>>> testing` comes from the branch being merged (`testing`).

### Step 3: Resolving the Conflict
1. Edit the file directly, choose the desired code, and delete the marker lines:
   ```text
   Hello, Git from Main and Testing Combined
   ```
2. Stage the resolved file to tell Git the conflict is solved:
   ```bash
   git add file.txt
   ```
3. Complete the merge commit:
   ```bash
   git commit -m "resolved merge conflict in file.txt"
   ```

---------------------------------------------------------
## 4. Alternative: Rebasing (`git rebase`)

Merging integrates branches by creating a diamond-shaped divergence that ties back together using a **Merge Commit** (a commit with two parents).

**Rebasing** achieves the same end result without creating a merge commit. Instead, it changes the base of your branch: Git takes the unique commits from your feature branch, removes them temporarily, and **replays them one by one** right on top of the target branch's newest commit.

This rewrites history into a clean, single **linear line**.

---

### Step 1: Before Rebase (Divergent History)

`testing` and `main` both split from the common ancestor commit `60453ee`:

```
                                          testing
                                             |
                                             v
                                        [ c035e15 ]
                                        (5th line)
                                             |
                                             v
[ 60453ee ] <--------------------------------+
(4th line)  <--------------------------------+
                                             ^
                                             |
                                        [ c455fbf ]
                                        (file2.txt)
                                             ^
                                             |
                                            main
                                             ^
                                             |
                                            HEAD
```

- In `main`: Two files exist (`file.txt`, `file2.txt`).
- In `testing`: Only one file exists (`file.txt`).

---

### Step 2: Running Rebase

To move the work of `testing` on top of `main`:

```bash
$ git switch testing
$ git rebase main
Successfully rebased and updated refs/heads/testing.
```

### What Git Does Behind the Scenes:
1. Git locates the common ancestor (`60453ee`).
2. It saves the changes of commit `c035e15` as temporary patches.
3. It resets the `testing` branch to match `main` (`c455fbf`).
4. It applies the patch on top of `c455fbf`, creating a **brand-new commit object** with a new hash (`c035e15'` $\rightarrow$ e.g., `d819fa2`).

---

### Step 3: After Rebase (Linear History)

```
                                                        HEAD
                                                         |
                                                      testing
                                                         |
                                                         v
                                                    [ d819fa2 ]  <-- (Was c035e15, now has new hash!)
                                                    (5th line)
                                                         |
                                     main                |
                                      |                  |
                                      v                  v
[ 60453ee ] <------------------- [ c455fbf ] <-----------+
(4th line)                       (file2.txt)
```

> **File Contents Check:**  
> Does `testing` have both files now? **Yes!** Because `testing` is now rebased on top of commit `c455fbf`, it inherits `file2.txt` from `main` along with its own modified `file.txt`.

---

### Step 4: Completing the Integration (Fast-Forward Merge)

Rebase **only linearizes the history of the current branch**—it does not update or move `main`. 

To complete the process and bring `main` up to date, you still have to switch to `main` and run a fast-forward merge:

```bash
$ git switch main
$ git merge testing
```

Now `main` simply slides forward directly to `d819fa2` with zero merge commits:

```
                                                                 HEAD
                                                                  |
                                                                main     testing
                                                                  \        /
                                                                   v      v
[ 60453ee ] <------------------- [ c455fbf ] <------------------ [ d819fa2 ]
(4th line)                       (file2.txt)                     (5th line)
```

---

### Key Differences: Merge vs. Rebase

```
+-----------------------------------+-----------------------------------+
|               MERGE               |              REBASE               |
+-----------------------------------+-----------------------------------+
| Preserves true historical record  | Rewrites history into a clean,    |
| exactly as it happened.           | single linear line.               |
|                                   |                                   |
| Creates a distinct Merge Commit   | No merge commit created; commits  |
| with two parents.                 | are re-applied with new SHA-1s.   |
|                                   |                                   |
| Non-destructive; safe for shared  | Never rebase commits that have    |
| public branches.                  | already been pushed to a team.    |
+-----------------------------------+-----------------------------------+
```