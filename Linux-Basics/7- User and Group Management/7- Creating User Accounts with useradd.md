# Creating User Accounts with useradd

The **`useradd`** command is the low-level utility responsible for provisioning new user accounts in Linux. Under the hood, it allocates the next available **UID**, creates a primary group, provisions the user's workspace, and registers the account across the system's identity databases.

---

## 1. What Happens Under the Hood?

When you execute `useradd`, Linux performs several coordinated actions across the operating system:

```text
               User Executes: sudo useradd -m engineer
                                  │
      ┌───────────────────────────┼───────────────────────────┐
      ▼                           ▼                           ▼
 Writes Account Metadata      Locks Password Field       Allocates Workspace
   ┌─────────────────┐         ┌─────────────────┐       ┌─────────────────┐
   │   /etc/passwd   │         │   /etc/shadow   │       │ /home/engineer/ │
   │ UID: 1001       │         │ Password: !     │       │ Seeded from:    │
   │ GID: 1001       │         │ (Locked State)  │       │ /etc/skel/      │
   └─────────────────┘         └─────────────────┘       └─────────────────┘
```

1. **Allocates Identifiers:** Finds the next available non-root UID (e.g., `1001`) and registers it in `/etc/passwd`.
2. **Creates a Primary Group:** Creates a dedicated group sharing the same name and numerical GID.
3. **Locks Password Entry:** Writes an initial placeholder (such as `!` or `*`) in `/etc/shadow`, locking the account until a valid credential is set.
4. **Provisions Home Folder:** Creates `/home/<username>` and populates it with default shell configuration files (`.bashrc`, `.bash_profile`) copied from the template directory `/etc/skel`.

---

## 2. The Home Directory Flag: `-m`

A critical administrative detail is ensuring the account actually receives a physical workspace on disk.

While some distributions configure `useradd` to build home directories by default, standard system administration practice dictates always using the **`-m`** (make home) flag:

```bash
abdullah@fedora:~$ sudo useradd -m engineer
```

Verify that the account was created and its directory provisioned:

```bash
abdullah@fedora:~$ ls -l /home
total 0
drwx------. 1 abdullah abdullah 402 Oct 28 18:30 abdullah
drwx------. 1 engineer engineer   0 Oct 29 21:00 engineer
```

If you omit `-m` on a system where default home creation is disabled, the user entry will exist in `/etc/passwd`, but the user will have no workspace upon logging in.

---

## 3. The Password Pitfall: Using `-p`

The `useradd` command provides a **`-p`** flag to define a password during creation. However, this flag has a major technical pitfall.

### Why `-p` Is Insecure and Problematic
The `-p` flag **expects an already-encrypted hash**, not raw plaintext:

```bash
# Insecure Demonstration:
abdullah@fedora:~$ sudo useradd -m -p "TempPass123" testuser
```

When you inspect the resulting entry in `/etc/shadow`:

```bash
abdullah@fedora:~$ sudo grep "testuser" /etc/shadow
testuser:TempPass123:19642:0:99999:7:::
```

Notice what happened:
- Linux wrote the literal plaintext string `"TempPass123"` directly into `/etc/shadow`.
- When the user tries to log in, the authentication system (PAM) hashes the entered password and compares that hash against the string stored in `/etc/shadow`.
- Because `"TempPass123"` is plaintext and not a cryptographic hash, the comparison fails every time, locking the user out.
- Furthermore, typing passwords directly into the terminal leaves them exposed in your shell history (`~/.bash_history`).

> **The Onboarding Scenario:** Some corporate deployment scripts use automated tools (like `openssl passwd -6 "TempPass123"`) to pre-hash a temporary password before passing it to `-p`. This allows newly hired employees to log in once with a temporary credential and immediately be prompted to change it.

---

## 4. The Standard Best Practice: Using `passwd`

The standard, secure way to provision an account is a two-step process: create the account cleanly, then set its password interactively using the **`passwd`** utility.

### Step 1: Create the User
```bash
abdullah@fedora:~$ sudo useradd -m developer
```

### Step 2: Set the Password with `passwd`
```bash
abdullah@fedora:~$ sudo passwd developer
New password: 
Retype new password: 
passwd: all authentication tokens updated successfully.
```

The `passwd` utility automatically salts and hashes the credential using the system's default cryptographic algorithm before writing it to disk.

### Step 3: Verify the Resulting Hash in `/etc/shadow`
Inspect the newly provisioned account in `/etc/shadow`:

```bash
abdullah@fedora:~$ sudo grep "developer" /etc/shadow
developer:$6$rounds=656000$saltstring$hashedpasswordstring...:19642:0:99999:7:::
```

- Field 2 now contains a secure, salted hash (indicated by `$6$` for SHA-512).
- The user can now authenticate successfully and securely.

---

## 5. Common `useradd` Flags Reference

```text
┌───────┬──────────────────────┬────────────────────────────────────────────────────────┐
│ Flag  │ Long Option          │ Purpose                                                │
├───────┼──────────────────────┼────────────────────────────────────────────────────────┤
│ -m    │ --create-home        │ Force creation of the user's home directory.           │
│ -s    │ --shell <path>       │ Specify the default login shell (e.g., /bin/bash).     │
│ -d    │ --home-dir <path>    │ Set a custom home directory path instead of /home/<user│
│ -u    │ --uid <number>       │ Assign a specific, manual numerical UID.               │
│ -c    │ --comment "<text>"   │ Add full name or descriptive info into GECOS field.    │
└───────┴──────────────────────┴────────────────────────────────────────────────────────┘
```

---

## Key Takeaways

- **Low-Level Provisioning:** `useradd` allocates the next available UID, registers metadata in `/etc/passwd`, and locks the initial entry in `/etc/shadow`.
- **Always Make Home (`-m`):** Use `-m` to guarantee that `/home/<username>` is physically created and seeded with default configuration files from `/etc/skel`.
- **The `-p` Pitfall:** Never pass raw plaintext passwords to `useradd -p`; it expects a pre-hashed string and will store plaintext directly, breaking logins and exposing secrets.
- **The Standard Approach:** Always provision the user with `useradd -m <user>` first, then assign their salted password securely using `sudo passwd <user>`.