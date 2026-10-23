# Login Shell Startup Operations (System-Wide)

Now that we understand the difference between a login shell and a non-login shell, we examine the primary system-wide startup file: **`/etc/profile`**.

This file is a standard shell script that executes automatically whenever **any user** starts a **login shell** on the machine.

---

## 1. What is `/etc/profile`?

Startup files are executable **shell scripts**. Any standard Linux command written inside them will run immediately when the shell initializes.

Two key traits define `/etc/profile`:
1. **System-wide:** Located in `/etc/`, meaning it applies globally to every account on the system.
2. **Login Shells Only:** It triggers only when a user logs in via a fresh authentication session (like over SSH or at a physical console). It does not run when opening standard desktop terminal windows.

---

## 2. Testing Startup Operations in `/etc/profile`

To verify how and when this file executes, we can append a simple message to it and observe which shell triggers it.

### Step 1: Add the Startup Command
Open the file in a text editor like `nano`:

```bash
sudo nano /etc/profile
```

> **Permission Note:** Because `/etc/profile` is a system-level configuration file owned by `root`, you must open it using `sudo` to have write permissions.

Scroll to the very bottom of the file, add this line, and save (`Ctrl + O`, `Enter`, then `Ctrl + X`):

```bash
echo "this is for system-wide and all users"
```

---

### Step 2: Test in a Regular Terminal (Non-Login Shell)
Open a new tab or window in your standard desktop terminal:

```bash
abdullah@fedora:~$ 
```

**Result:** Nothing prints.  
**Why?** Opening a desktop terminal creates a non-login shell, which skips `/etc/profile` entirely.

---

### Step 3: Test via SSH (Simulating a Login Shell)
Initiate a login session by connecting to your local machine over SSH:

```bash
abdullah@fedora:~$ ssh abdullah@localhost
abdullah@localhost's password: 
this is for system-wide and all users
Last login: Fri Oct 23 16:25:00 2026 from 127.0.0.1
abdullah@fedora:~$
```

**Result:** The message prints immediately upon authentication.  
**Why?** SSH requires credential authentication, which starts a login shell (`-bash`). The login shell reads `/etc/profile` line by line and executes our `echo` command before giving you the command prompt.

Exit the SSH session to return to your regular terminal:
```bash
abdullah@fedora:~$ exit
logout
Connection to localhost closed.
abdullah@fedora:~$
```

---

## 3. What Operations Belong in `/etc/profile`?

Because `/etc/profile` affects every user on the computer, it is used strictly for global configurations:

* **Global Environment Variables:** Defining system-wide settings like default language encoding (`LANG`) or system paths.
* **Global `$PATH` Additions:** Ensuring essential shared directories (such as `/usr/local/bin`) are accessible to all users upon login.
* **System Notices:** Printing broadcast announcements or maintenance alerts during login.

---

## 4. Cleaning Up the Test Line

Remove the test line after testing to keep your system file clean:

```bash
sudo nano /etc/profile
```
Scroll to the bottom, delete the `echo "this is for system-wide and all users"` line, and save the file (`Ctrl + O`, `Enter`, then `Ctrl + X`).

---

## Key Takeaways

* **Startup Script Execution:** Files like `/etc/profile` execute normal shell commands automatically when a session starts.
* **System-Wide Scope:** Any operation or exported variable in `/etc/profile` applies to all users on the machine.
* **Root Permissions Required:** Modifying system-wide startup files in `/etc/` requires `sudo`.
* **Login Shell Trigger:** Runs strictly during **login shells** (like SSH logins). Regular desktop terminal windows bypass it.