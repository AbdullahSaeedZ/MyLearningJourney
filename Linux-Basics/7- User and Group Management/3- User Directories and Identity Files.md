# User Directories and Identity Files

When managing accounts in Linux, understanding where a user stores their files and how the operating system records their existence requires looking at three distinct locations: **`/home/`**, **`/etc/passwd`**, and **`/etc/shadow`**.

---

## 1. Where Does a User's Data Live?

Every time you log into a Linux machine, the shell drops you into an environment tailored specifically to your account. This workspace is your **home directory**:

- It acts as the personal sandbox where personal configuration files, code, documents, and environment variables are stored.
- Other non-root users are restricted by system permissions from altering or viewing your private workspace.

To understand how the operating system maps a human or a process to a specific folder on the disk, Linux coordinates across three core data sources:

```text
                        Where User Information Lives
 ┌────────────────────────────────────────────────────────────────────────┐
 │                                                                        │
 │  1. Physical Storage (/home/)                                          │
 │     └─ Directory on disk where regular users save personal files.      │
 │                                                                        │
 │  2. System Identity Registry (/etc/passwd)                             │
 │     └─ Central configuration file defining who exists, their IDs,      │
 │        their assigned home folder, and their default shell.            │
 │                                                                        │
 │  3. Secure Authentication Vault (/etc/shadow)                          │
 │     └─ Restricted file storing secure, encrypted password hashes.      │
 │                                                                        │
 └────────────────────────────────────────────────────────────────────────┘
```

---

## 2. Inspecting the Filesystem: The `/home/` Directory

A common first instinct when trying to see what users exist on a system is to look inside `/home/`:

```bash
abdullah@fedora:~$ ls /home
abdullah
```

While this shows user folders on disk, **`/home/` is not a reliable registry of system accounts.** Relying solely on `/home/` leaves significant blind spots:

- **Missing the Administrator:** The `root` user's home folder is not located here. It resides in `/root` directly at the filesystem root.
- **Missing System & Daemon Users:** Background service accounts (such as `nginx`, `sshd`, or `systemd-resolve`) do not use `/home/`. Their workspaces point to specific service paths (like `/var/lib/` or `/var/empty`), or they are assigned no folder at all.
- **Disconnected Data:** A user account can exist without having a physical home directory, and an old directory can remain inside `/home/` long after an account has been removed.

Folders on disk only store files; they do not define the user. To see who actually exists on the system, you must consult the actual identity file.

---

## 3. The Central Identity Registry: `/etc/passwd`

The true source of truth for accounts on a Linux system is the plaintext file **`/etc/passwd`**.

```bash
abdullah@fedora:~$ head -n 3 /etc/passwd
root:x:0:0:root:/root:/bin/bash
bin:x:1:1:bin:/bin:/sbin/nologin
daemon:x:2:2:daemon:/sbin:/sbin/nologin
```

### Why `/etc/passwd` Is Open to Everyone
This file is intentionally readable by every user and running process on the operating system.

Standard command-line tools (such as `ls` or `ps`) need to translate numeric user IDs into readable text names. If this file were restricted, regular commands and unprivileged programs would break because they wouldn't know which name belongs to which numeric ID.

### Deconstructing the Seven Fields
Every line inside `/etc/passwd` represents one account, broken down into seven colon-separated fields:

```text
 abdullah : x : 1000 : 1000 : Abdullah Saeed : /home/abdullah : /bin/bash
 ────────   ─   ────   ────   ──────────────   ──────────────   ─────────
    1       2    3      4           5                 6             7
```

```text
┌───────┬──────────────────┬────────────────────────────────────────────────────────┐
│ Field │ Attribute        │ Meaning                                                │
├───────┼──────────────────┼────────────────────────────────────────────────────────┤
│ 1     │ Username         │ The login name used by the user or service.            │
│ 2     │ Password Marker  │ A simple 'x' signaling the password is kept elsewhere. │
│ 3     │ UID              │ The unique numerical User ID used by the kernel.       │
│ 4     │ GID              │ The primary numerical Group ID.                        │
│ 5     │ Comment / GECOS  │ Descriptive info (e.g., full name or room number).     │
│ 6     │ Home Directory   │ The assigned directory path given to this account.     │
│ 7     │ Default Shell    │ The program executed when the account logs in.         │
└───────┴──────────────────┴────────────────────────────────────────────────────────┘
```

Notice **Field 6**: this is where Linux actually defines where an account's home folder should be, solving the question of how the system knows where to send you.

---

## 4. The Secure Vault: `/etc/shadow`

Looking closely at Field 2 of `/etc/passwd`, you will see a placeholder letter: **`x`**.

In early Unix systems, the actual encrypted password was kept directly in `/etc/passwd`. But because `/etc/passwd` must stay readable for standard programs to work, anyone could read those password hashes and try cracking them offline.

To fix this security vulnerability, modern Linux systems moved the actual password hashes into **`/etc/shadow`**:

```text
 ┌──────────────────────────────────────────────┐
 │                 /etc/passwd                  │
 │            Readable by all users             │ ──> Account details, paths, and shells
 │  abdullah:x:1000:1000::/home/abdullah:...    │
 └──────────────────────┬───────────────────────┘
                        │ Field 2 has 'x'
                        ▼
 ┌──────────────────────────────────────────────┐
 │                 /etc/shadow                  │
 │          Strictly restricted to root         │ ──> Actual encrypted password hashes
 │  abdullah:$6$rounds=...:19642:0:99999:7:::   │
 └──────────────────────┘
```

### Access Restrictions
Unlike `/etc/passwd`, regular users are blocked from reading `/etc/shadow`.

If you try to read it directly with your regular user, access is denied:

```bash
abdullah@fedora:~$ cat /etc/shadow
cat: /etc/shadow: Permission denied
```

Only the superuser (`root`) or administrative commands using `sudo` have permission to view it:

```bash
abdullah@fedora:~$ sudo head -n 1 /etc/shadow
root:$6$rounds=656000$saltsalt$hAsH...:19642:0:99999:7:::
```

### Deconstructing the Nine Fields
Each line in `/etc/shadow` is split into **nine colon-delimited fields** containing the account's authentication details and password aging policies:

```text
 root : $6$rounds=656000$saltsalt$hAsH... : 19642 : 0 : 99999 : 7 :   :   :  
 ────   ─────────────────────────────────   ─────   ─   ─────   ─   ─   ─   ─
  1                     2                     3     4     5     6   7   8   9
```

```text
┌───────┬──────────────────────┬────────────────────────────────────────────────────────┐
│ Field │ Attribute            │ Meaning                                                │
├───────┼──────────────────────┼────────────────────────────────────────────────────────┤
│ 1     │ Username             │ The user account name matching /etc/passwd.            │
│ 2     │ Encrypted Password   │ Salted cryptographic password hash. An exclamation mark│
│       │                      │ (!) or asterisk (*) locks the account from login.      │
│ 3     │ Last Changed         │ Days since Jan 1, 1970 (Epoch) that password was reset.│
│ 4     │ Minimum Password Age │ Days the user must wait before allowed to change it.   │
│ 5     │ Maximum Password Age │ Days the password remains valid before it must change. │
│ 6     │ Warning Period       │ Days prior to expiration that the user is warned.      │
│ 7     │ Inactivity Period    │ Days after expiration before the account disables.     │
│ 8     │ Expiration Date      │ Absolute date (days since Epoch) account is revoked.   │
│ 9     │ Reserved             │ Reserved field for future system/kernel expansion.     │
└───────┴──────────────────────┴────────────────────────────────────────────────────────┘
```

> **What is the Unix Epoch?**  
> Fields 3 and 8 measure time as the number of days elapsed since **January 1, 1970 (00:00:00 UTC)**, known as the Unix Epoch. Linux uses this standardized starting point as its universal zero-reference to perform fast integer date arithmetic without complex calendar logic.

---

## 5. Comparison of the Three Sources

```text
┌──────────────┬──────────────────────┬─────────────────────────────────────────────────┐
│ Source       │ Who Can Read It?     │ Primary Purpose                                 │
├──────────────┼──────────────────────┼─────────────────────────────────────────────────┤
│ /home/       │ Permissions depend   │ Stores regular users' files and private data.   │
│              │ on directory owner   │                                                 │
│              │                      │                                                 │
│ /etc/passwd  │ Every user & process │ Defines identity metadata, home paths, shells.  │
│              │                      │                                                 │
│ /etc/shadow  │ Strictly root only   │ Safely stores encrypted password hashes.        │
└──────────────┴──────────────────────┴─────────────────────────────────────────────────┘
```

---

## Key Takeaways

- **`/home/` is Just File Storage:** Looking in `/home/` only reveals human accounts with created folders; it completely ignores `root` (`/root`) and system daemon accounts.
- **`/etc/passwd` is the Single Source of Truth:** A world-readable file containing 7 fields defining users, UIDs, GIDs, home paths, and shells.
- **Why `/etc/passwd` Stays Open:** It must remain readable by all accounts so standard utilities can resolve numerical IDs into user names.
- **The Password Marker (`x`):** The placeholder `x` in `/etc/passwd` points the system to look inside `/etc/shadow` for authentication.
- **`/etc/shadow` Protects Passwords:** A restricted file accessible only by `root` that protects password hashes and aging rules across 9 fields from unprivileged inspection.
- **Epoch-Based Tracking:** Dates inside `/etc/shadow` are counted as days since January 1, 1970, simplifying expiration calculations.