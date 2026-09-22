# Lesson 05: The Fourth Git Object — Annotated Tags

## 1. Commits vs. Releases: Why Tags Exist

Earlier, we learned about 3 of the 4 core Git objects:
- **Blob:** File contents.
- **Tree:** Directory state and filenames.
- **Commit:** Snapshot wrapper with metadata and parent pointers.

A commit records an incremental snapshot of your project. Changing a single line or fixing a minor typo creates a commit snapshot, but that does not mean it qualifies as a complete milestone or formal software release.

When you reach a stable point—say, after multiple feature commits—you want to stamp that exact commit with an immutable label like `v1.0` or `v2.0`.

This is where the 4th Git object comes in: **The Annotated Tag Object**.

```
                           +-------------------------------+
                           |     ANNOTATED TAG OBJECT      |
                           |           (v2.0)              |
                           |-------------------------------|
                           | Tagger: Abdullah Saeed        |
                           | Date:   Tue Sep 22 10:00:50   |
                           | Message: version 2.0          |
                           | Points to: Commit f7d31b5 ----+
                           +-------------------------------+
                                           |
                                           v
                           +-------------------------------+
                           |         COMMIT OBJECT         |
                           |           (f7d31b5)           |
                           +-------------------------------+
```

A tag acts like an immutable, human-readable bookmark pointing directly to a specific commit so you never have to memorize or hunt down raw SHA-1 hashes.

---------------------------------------------------------

## 2. Creating an Annotated Tag

Here is our commit log after adding a 5th line to `file.txt`:

```bash
$ git log --oneline
f7d31b5 (HEAD -> main) 5th line added to file.txt
4c92497 fourth file added to file.txt
3356ca6 third line added to file.txt (edited message)
8cc9331 second line added
6c12004 initial commit
```

To create an annotated tag on the current commit (`HEAD`):

```bash
$ git tag -a v2.0 -m "version 2.0 of file.txt"
```

### Explaining the Flags:
- `-a` (**Annotated**): Tells Git to create a real, standalone **object** inside `.git/objects/`. It stores its own checksum, creation date, tagger identity (name and email), and custom message.
  > *(Without `-a`, Git creates a "lightweight tag," which is just a pointer file containing a commit hash without an object wrapper or metadata).*
- `-m`: Specifies the message assigned to the tag object.

### How to Target a Specific (Older) Commit
If you run `git tag -a <tagname>` without specifying a commit hash, Git automatically targets wherever `HEAD` is currently pointing.

To tag an older commit in history, append its hash to the end:

```bash
# Syntax: git tag -a <tag-name> <target-commit-hash> -m <message>
$ git tag -a v1.0 8cc9331 -m "version 1.0 baseline"
```

---------------------------------------------------------

## 3. Inspecting Tags with `git show`

Once created, you can pass tag names anywhere Git expects a commit reference:

```bash
$ git show v2.0
tag v2.0
Tagger: Abdullah Saeed <asz1095136568@gmail.com>
Date:   Tue Sep 22 10:00:50 2026 +0300

versoin 2.0 of file.txt

commit f7d31b50fe0964ee5fa57e785865cf765c937d57 (HEAD -> main, tag: v2.0)
Author: Abdullah Saeed <asz1095136568@gmail.com>
Date:   Tue Sep 22 09:59:40 2026 +0300

    5th line added to file.txt

diff --git a/file.txt b/file.txt
index cb95434..c6d8b6e 100644
--- a/file.txt
+++ b/file.txt
@@ -2,3 +2,4 @@ Hello, Git
Second line in the file
Third line in file
Fourth line in file
+Fifth line in file
```

Notice how `git show v2.0` outputs two distinct layers:
1. **The Tag Object Metadata:** Tagger name, timestamp, and tag message.
2. **The Target Commit Payload:** The commit details and unified diff of what changed in that release.

---------------------------------------------------------

## 4. Useful Tag Operations

```bash
# List all tags in the repository:
$ git tag

# Search for tags matching a pattern:
$ git tag -l "v1.*"

# Delete a tag:
$ git tag -d v2.0
```