# Privilege Elevation with sudo

The **`sudo`** (SuperUser DO) command allows an authorized regular user to execute commands with elevated administrative privileges—most commonly as `root`—using their own password rather than the target account's password.

---

## 1. How `sudo` Works

Instead of switching your entire interactive shell session into another user, `sudo` acts as an elevation wrapper around individual commands:

```text
 ┌────────────────────────────────────────────────────────┐
 │ User executes: sudo dnf update                         │
 └──────────────────────────┬─────────────────────────────┘
                            │
                            ▼
 ┌────────────────────────────────────────────────────────┐
 │ Authentication Check                                   │
 │ Prompts for: abdullah's password (Caller's Password)   │
 └──────────────────────────┬─────────────────────────────┘
                            │ Validated
                            ▼
 ┌────────────────────────────────────────────────────────┐
 │ Command runs under UID 0 (root privileges)             │
 │ Event logged to system audit trail                     │
 └──────────────────────────┬─────────────────────────────┘
                            │ Execution Finishes
                            ▼
 ┌────────────────────────────────────────────────────────┐
 │ Drops back to regular shell (abdullah, UID 1000)       │
 └────────────────────────────────────────────────────────┘
```

The elevation exists **only for the lifespan of that specific command**. The moment the process finishes, you are back in your restricted user session.

---

## 2. Basic Usage and Password Caching

To run any administrative command, prefix it with `sudo`:

```bash
abdullah@fedora:~$ sudo dnf check-update
[sudo] password for abdullah:
```

### Credential Caching (The Grace Period)
`sudo` implements a credential cache. Once you enter your password successfully, `sudo` issues a temporary authentication timestamp (typically lasting **5 to 15 minutes** depending on distribution settings).

During this window, subsequent `sudo` commands run immediately without prompting for your password again:

```bash
# Prompts for password:
abdullah@fedora:~$ sudo systemctl status sshd

# Runs immediately without prompt:
abdullah@fedora:~$ sudo systemctl restart sshd
```

To immediately invalidate your cached ticket (for example, before walking away from your terminal), use the **`-k`** (kill) flag:

```bash
abdullah@fedora:~$ sudo -k
```

---

## 3. The "Locked Root" Reality in Modern Distros

Many modern Linux distributions (such as Ubuntu and modern Fedora workstation setups) do not prompt you to set a `root` password during installation.

### Is the Root User Missing?
No. **UID `0` always exists** in the Linux kernel.

Instead of deleting `root`, the system sets a lock flag (an exclamation mark `!` or asterisk `*`) in root's password field inside `/etc/shadow`. This deliberately disables direct password logins and blocks commands like `su -` from working.

Administrative rights are delegated entirely through `sudo` to the initial user created during installation.

### Setting a Root Password (If Needed)
If a specific workflow or legacy tool strictly requires an active, unlockable root account, you can assign it a password directly using `sudo`:

```bash
abdullah@fedora:~$ sudo passwd root
New password: 
Retype new password: 
passwd: all authentication tokens updated successfully.
```
This writes a valid password hash to root's entry in `/etc/shadow`, allowing direct logins or `su -` access if required.

---

## 4. Spawning a Root Shell: Why Use `sudo -i` Instead of `su -`?

While running single commands with `sudo <command>` is best practice, extensive maintenance or troubleshooting sometimes requires a persistent root shell.

Both commands spawn an interactive root login session with a clean environment, but **`sudo -i`** is the standard modern approach:

```bash
abdullah@fedora:~$ sudo -i
[sudo] password for abdullah: 
[root@fedora ~]# whoami
root
[root@fedora ~]# pwd
/root
```

### Why `sudo -i` Beats `su -`:
1. **Your Own Password:** `sudo -i` authenticates using **your personal password**. `su -` forces you to enter the actual `root` password.
2. **Works with Locked Root Accounts:** On systems where root has no password set, `su -` fails completely. `sudo -i` works seamlessly.
3. **Audit Trail Remains Intact:** Spawning a root shell with `sudo -i` logs the event in the system audit trail, recording exactly which user initiated the root session.

---

## 5. `sudo` vs. Operating Directly as `root`

```text
┌──────────────────────┬─────────────────────────────┬─────────────────────────────┐
│ Feature              │ Running with sudo           │ Operating as Root (su / -i) │
├──────────────────────┼─────────────────────────────┼─────────────────────────────┤
│ Authentication       │ Your personal user password │ Shared root password        │
│ Scope of Elevation   │ Single command execution    │ Entire interactive session  │
│ Audit Trail          │ Logs username + exact cmd   │ Generic "root" logs         │
│ Accidental Damage    │ Minimal risk after command  │ High risk from stray typos  │
└──────────────────────┴─────────────────────────────┴─────────────────────────────┘
```

---

## Key Takeaways

- **Personal Authentication:** `sudo` elevates administrative operations using the caller's personal password rather than exposing a master root password.
- **Limited Scope:** Administrative power lasts strictly for the duration of the prefixed command.
- **Credential Caching:** Caches authorization for a brief window (typically 5–15 minutes) to avoid repeated password prompts; cleared immediately via `sudo -k`.
- **Locked Root:** Modern distros lock the direct root password by default, relying exclusively on `sudo` for system management.
- **`sudo -i` Over `su -`:** Spawns a full root login session using your personal credentials without requiring a shared or unlocked root password.