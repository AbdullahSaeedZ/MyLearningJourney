# Modifying User Accounts with usermod

The **`usermod`** (user modify) command allows system administrators to alter existing account properties without deleting and recreating the user. Under the hood, it modifies the corresponding fields directly in **`/etc/passwd`** and **`/etc/shadow`**.

---

## 1. Why Use `usermod`?

When a user's details change—such as their login shell, account status, or username—recreating the account is bad practice:
- Recreating an account assigns a new **UID**, breaking file ownership across existing projects.
- `usermod` updates configuration records in place while preserving the user's numeric identity and file permissions.

---

## 2. Changing the Login Shell: `-s`

If a user needs a different default command interpreter (e.g., switching from Bash to Zsh), or if you need to block interactive terminal access, update Field 7 in `/etc/passwd` using the **`-s`** flag:

```bash
# Change developer's default shell to zsh:
abdullah@fedora:~$ sudo usermod -s /bin/zsh developer
```

### Disabling Interactive Login
For service accounts or suspended users, you can route the login shell to `/sbin/nologin`:

```bash
abdullah@fedora:~$ sudo usermod -s /sbin/nologin developer
```

This prevents the account from opening an interactive shell session while still allowing background system processes to function under that UID.

---

## 3. Locking and Unlocking Accounts: `-L` and `-U`

When an employee takes extended leave or an account is under investigation, you can temporarily suspend access without deleting their files or metadata.

### A. Locking an Account (`-L`)
```bash
abdullah@fedora:~$ sudo usermod -L developer
```

**What happens under the hood:**  
`usermod -L` prepends an exclamation mark (**`!`**) to the user's password hash in `/etc/shadow`:

```bash
abdullah@fedora:~$ sudo grep "developer" /etc/shadow
developer:!$6$rounds=656000$salt...:19642:0:99999:7:::
```

Because no entered password can ever hash to a string starting with `!`, all password-based authentication attempts fail immediately.

### B. Unlocking an Account (`-U`)
To restore access, run the command with **`-U`**:

```bash
abdullah@fedora:~$ sudo usermod -U developer
```

This removes the `!` prefix from `/etc/shadow`, returning the password hash to its active, valid state.

---

## 4. Renaming a Username: `-l`

To change the login name of an existing user while keeping their UID, files, and group memberships intact, use the **`-l`** (login name) flag:

```text
 sudo usermod -l <new_name> <old_name>
```

```bash
# Rename the user 'dev_temp' to 'khalid':
abdullah@fedora:~$ sudo usermod -l khalid dev_temp
```

Verify that the name was updated in `/etc/passwd`:

```bash
abdullah@fedora:~$ id khalid
uid=1002(khalid) gid=1002(dev_temp) groups=1002(dev_temp)
```

> **Important Note on Home Directories:**  
> Renaming the username with `-l` changes only the login name in `/etc/passwd`. It **does not** automatically rename their home directory on disk (`/home/dev_temp` remains unchanged). To rename both the login name and the home folder at the same time, pair it with `-d` and `-m`:  
> `sudo usermod -l khalid -d /home/khalid -m dev_temp`

---

## 5. Summary Reference

```text
┌───────────────────────────┬───────────────────────────────────────────────────────────┐
│ Command Pattern           │ Action Performed                                          │
├───────────────────────────┼───────────────────────────────────────────────────────────┤
│ usermod -s <shell> <user> │ Changes the user's default login shell.                   │
│ usermod -L <user>         │ Locks account by prepending '!' to hash in /etc/shadow.   │
│ usermod -U <user>         │ Unlocks account by removing the '!' from /etc/shadow.     │
│ usermod -l <new> <old>    │ Updates the textual login username in /etc/passwd.        │
└───────────────────────────┴───────────────────────────────────────────────────────────┘
```

---

## Key Takeaways

- **Preserves Identity:** `usermod` updates account attributes in place without altering the UID or disrupting file ownership.
- **Shell Control (`-s`):** Modifies the login shell in `/etc/passwd`; use `/sbin/nologin` to block interactive logins.
- **Non-Destructive Suspension (`-L` / `-U`):** Locking prepends `!` to the password hash in `/etc/shadow`, disabling logins without touching user files.
- **Renaming Users (`-l`):** Updates the login name in `/etc/passwd`, but leaves the home folder name untouched unless explicitly moved.