
# Lesson 02-B: Versioning, Commits & The Object Graph

Now, the versioning and commit section.

The first command to create a snapshot (version) is:
```bash
git commit -m "put a message here to describe the version difference or reason of creation"
```

This will create a snapshot, an initial version—the first one.

Now let's see what objects are created in the `.git` repo:
```bash
$ find .git/Objects/ -type f
.git/Objects/0f/0f286fa3d65ede93d8b5b246e019dc5c9a8bf3
.git/Objects/35/74cca0ab1868769b0532a696584f448178c5b9
.git/Objects/e5/1ca0d0b8c5b6e02473228bbf876ba000932e96
```

Wait, 3 objects? While I only have my text file? And before committing it was only one object?
So what happened when I committed to generate the extra 2 objects?

Remember that we are not only taking a snapshot and tracking the text file, but Git is taking a snapshot of the folder where the file is—the TREE.

So once we commit, we take a snapshot and Git creates at least 3 objects for:
- **The blob** -> the file
- **The tree** -> where the file is (the path / the folder)
- **The commit itself** -> as a container (a wrapper wrapping the objects)

The commit object is the snapshot that contains the file and the folder objects representing a certain version.

Why a commit object container to contain the blobs and trees?
Because if I have 20 blobs that have been created at different times and for different changes, then I would have 20 objects and wouldn't know which is linked to which update, or which blob is paired with which blob in a certain update. Everything would be scattered all over the place!

So the commit object container is introduced to group the related blobs and trees into one BATCH or snapshot, with the commit message as the title of it describing that version at that point of time.

But still, in the `Objects` folder, we see all objects dumped together. How do we differentiate?
How do we see that this object is related to that object, and which object is under the commit object?

Each commit object is like a linked list node that POINTS to the Tree, and the Tree points to the Blobs:

```
                  +---------------------------------------+
                  |             COMMIT OBJECT             |
                  |                (0f0f28)               |
                  |---------------------------------------|
                  | Author: Abdullah Saeed                |
                  | Date:   Sat Sep 19 22:49:46 2026      |
                  | Tree:   3574cc --------------------+  |
                  | Message: initial commit            |  |
                  +------------------------------------+--+
                                                       |
                                                       v
                                    +-----------------------------------+
                                    |            TREE OBJECT            |
                                    |             (3574cc)              |
                                    |-----------------------------------|
                                    | Mode   Type  Hash      Filename   |
                                    | 100644 blob  e51ca0 -> file.txt -+|
                                    +---------------------------------+-+
                                                                      |
                                                                      v
                                                    +-------------------+
                                                    |    BLOB OBJECT    |
                                                    |     (e51ca0)      |
                                                    |-------------------|
                                                    | Hello Git         |
                                                    +-------------------+
```

This way we know this commit (snapshot) has metadata like message, time, who made the commit, and pointers to relate to the objects that were changed in that version.

---------------------------------

### Checking Commit Objects and History

Use this command to see the commit object hashes in history:
```bash
$ git log
commit 0f0f286fa3d65ede93d8b5b246e019dc5c9a8bf3 (HEAD -> main)
Author: Abdullah Saeed <asz1095136568@gmail.com>
Date:   Sat Sep 19 22:49:46 2026 +0300

    initial commit
```

We see that it showed all commits (snapshots), showing the commit object hash and its metadata.
Why did it only show the commit object? Why not the files of that commit?

It doesn't need to show them directly, because this commit object can lead us to its related blobs and trees since it is pointing to them!

Let's do it now. Remember how to see the contents of objects?
Using: `git cat-file -p <hash>`

```bash
$ git cat-file -p 0f0f286fa3d65ede93d8b5b246e019dc5c9a8bf3
tree 3574cca0ab1868769b0532a696584f448178c5b9
author Abdullah Saeed <asz1095136568@gmail.com> 1789847386 +0300
committer Abdullah Saeed <asz1095136568@gmail.com> 1789847386 +0300

initial commit
```

See how we got the tree object hash as the content of the commit object?
In the exact same way, we can reach the blobs from that tree hash!

> **Note on Hashes:** Instead of pasting the whole 40-character hash of an object, just give the first 6 or 7 characters and Git will identify it, since collisions in those first characters are extremely rare.

Let's see the content of the tree object:
```bash
$ git cat-file -p 3574cca
100644 blob e51ca0d0b8c5b6e02473228bbf876ba000932e96    file.txt
```

Now let's see the content of the blob object:
```bash
$ git cat-file -p e51ca0
Hello Git
```