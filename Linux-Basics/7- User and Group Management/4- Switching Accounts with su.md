# Switching Accounts with su / su -

The **`su`** (Substitute User or Switch User) utility allows you to switch your active shell context to another user account during a terminal session. While it is most frequently used to transition into the administrative `root` account, it can substitute identity to any valid account defined on the system.

---

## 1. The Core Architecture of `su`

Under the hood, `su` requests authorization to change the current process's real and effective **UID** and **GID** to match the target account.

```text
 ┌────────────────────────────────────────────────────────┐
 │ Active Shell: abdullah (UID 1000)                      │
 └──────────────────────────┬─────────────────────────────┘
                            │ Runs: su -
                            ▼
 ┌────────────────────────────────────────────────────────┐
 │ su Authentication Gate                                 │
 │ Prompts for: TARGET USER'S PASSWORD (e.g., root)       │
 └──────────────────────────┬─────────────────────────────┘
                            │ Password Validated
                            ▼
 ┌────────────────────────────────────────────────────────┐
 │ New Subshell Spawns: root (UID 0)                      │
 └────────────────────────────────────────────────────────┘
```

### The Authentication Requirement
To switch identity using `su`, you must supply the **target account's password**, not your own:
- Switching to `root` requires entering the actual password assigned to `root`.
- Switching to another user requires entering that specific user's password.

To return to your original user session at any time, terminate the subshell using `exit` or by pressing `Ctrl + D`.

---

## 2. Switching to Root: `su` vs. `su -`

When invoking `su` without specifying a username, Linux assumes the target account is **`root`**. However, there is a fundamental architectural distinction between executing `su` and `su -`.

```bash
# Non-login switch (Keeps current user's environment)
abdullah@fedora:~$ su

# Full login switch (Rebuilds environment from scratch)
abdullah@fedora:~$ su -
```

Both commands grant absolute administrative authority at the kernel layer (setting your active UID to `0`). The difference lies entirely in the **user-space environment context**.

### A. Non-Login Switch (`su`)
Executing `su` without the hyphen preserves your current shell environment:
- **`$HOME` Remains Unchanged:** Points to your regular user home (`/home/abdullah`), not `/root`.
- **Working Directory Retained:** Keeps you in whatever directory you were working in.
- **`$PATH` Inheritance:** Inherits the calling user's binary search path, which often omits system administration directories like `/sbin` and `/usr/sbin`.

```bash
abdullah@fedora:~$ pwd
/home/abdullah
abdullah@fedora:~$ su
Password: 
[root@fedora abdullah]# pwd
/home/abdullah
[root@fedora abdullah]# echo $HOME
/home/abdullah
```

### B. Full Login Switch (`su -` or `su -l`)
Adding the hyphen (`-` or `-l` / `--login`) instructs `su` to spawn a **login shell**. It wipes the calling user's environment clean and re-initializes the session as if the target user had logged into the machine directly:
- **`$HOME` Resets:** Switched directly to `/root`.
- **Working Directory Resets:** Automatically changes directory to the target user's home (`/root`).
- **Clean `$PATH`:** Loads standard administrative paths containing tools like `fdisk`, `iptables`, and `reboot`.
- **Startup Files Evaluated:** Fully executes `/etc/profile`, `/root/.bash_profile`, and `/root/.bashrc`.

```bash
abdullah@fedora:~$ su -
Password: 
[root@fedora ~]# pwd
/root
[root@fedora ~]# echo $HOME
/root
```

> **Best Practice:** Always use **`su -`** when switching to root. Operating in an uncleaned environment with bare `su` can lead to scripts executing against user-owned configuration files, creating unpredictable side effects and security holes.

---

## 3. Switching to Regular Accounts

You can substitute into any other regular user account by appending their username to the command:

```bash
# Switches to the user 'developer' in a clean login shell
abdullah@fedora:~$ su - developer
Password: 
[developer@fedora ~]$ whoami
developer
```

### Root's Special `su` Privilege
The superuser bypasses standard authentication checks. If you are already operating as `root`, you can switch to any regular user on the machine **without entering their password**:

```bash
[root@fedora ~]# su - abdullah
[abdullah@fedora ~]$ whoami
abdullah
```
This is commonly used by system administrators to test user-specific permissions, environment configurations, and access constraints directly.

---

## 4. Why the `su` / `su -` Paradigm Breaks Down (The Path to `sudo`)

Whether you switch via `su` or `su -`, relying on direct account substitution for day-to-day administration introduces critical operational and security weaknesses:

```text
 The Traditional 'su / su -' Bottleneck:
 ┌──────────────────┐
 │ Admin: abdullah  ├──┐
 └──────────────────┘  │
 ┌──────────────────┐  │ Shares 1 Root Password
 │ Admin: sara      ├──┼────────────────────────>  Single Root Password
 └──────────────────┘  │                            (No Audit Trail | Shared Key)
 ┌──────────────────┐  │
 │ Admin: khalid    ├──┘
 └──────────────────┘
```

1. **Shared Credential Risk:** To give multiple administrators root access via `su` or `su -`, you must give all of them the server's actual `root` password. Handing out the master password eliminates individual access control.
2. **Revocation Overhead:** When an administrator leaves an organization, the single shared `root` password must be changed manually across every server they had access to.
3. **Loss of Accountability:** The moment an engineer switches to `root`, all commands they run are logged by the system under UID `0`. If an accidental deletion occurs, system logs record only that `root` performed the action—making it impossible to identify which individual was responsible.
4. **All-or-Nothing Scope:** `su` provides zero granular filtering. An engineer either has full administrative control over the entire system or none at all.

### The Solution: Delegated Elevation via `sudo`
To fix these structural flaws, modern Linux systems introduced **`sudo`** (SuperUser DO).

Instead of forcing users to become `root` directly, `sudo` elevates the privileges of regular users for specific commands using **their own personal passwords**. Every single command executed with root privileges is recorded alongside the user's real account name in system audit logs, establishing complete individual accountability without ever exposing the root password.

---

## Key Takeaways

- **Purpose of `su` / `su -`:** Substitutes the active shell context by changing the process's real and effective UID/GID to the target account.
- **Target Password Required:** Switching requires entering the **target user's password** (except when switching *from* `root`, which requires no password).
- **`su` vs. `su -`:** Both grant UID `0`, but `su` retains your regular user's `$HOME` and environment, while `su -` spawns a clean login shell with `/root` as the working directory and a proper administrative `$PATH`.
- **The Core Flaws of `su` / `su -`:** Relies on sharing the master root password, provides all-or-nothing control, and erases individual accountability from system logs.
- **Why `sudo` Replaced It:** `sudo` elevates regular users using their own passwords and records an exact audit trail of who ran what command with root privileges.