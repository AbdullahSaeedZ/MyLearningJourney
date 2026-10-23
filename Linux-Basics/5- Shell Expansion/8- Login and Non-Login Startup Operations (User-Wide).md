# Login and Non-Login Startup Operations (User-Wide)

In the previous lesson, we saw how `/etc/profile` executes system-wide commands for login shells. Now we examine the most frequently used startup configuration file in Linux: **`~/.bashrc`**.

Unlike `/etc/profile`, `~/.bashrc` belongs to your specific user account and runs automatically across everyday terminal sessions.

---

## 1. What is `~/.bashrc`?

The file name stands for **Bash Run Commands**. It resides directly in your home directory (`/home/abdullah/.bashrc` or `~/.bashrc`).

Two core characteristics define `~/.bashrc`:

1. **User-Wide Scope (Strictly Isolated):**  
   It belongs exclusively to your personal user account. Modifying it does not require `sudo`. Most importantly, **it affects only you**—if another user logs into the system with their own credentials, or if you switch to another account (like `root`), they will **not** see your changes, variables, or startup operations. Every user has their own independent `~/.bashrc` inside their own home folder.

2. **Runs for Both Shell Types (For Your User):**
    - **Non-login shells:** Opening a standard terminal window or tab on your desktop executes `~/.bashrc` directly.
    - **Login shells:** Logging in via SSH or a console executes `~/.bash_profile`, which by default is configured to source and execute `~/.bashrc` as well.

Because of this design, settings placed in `~/.bashrc` are available across virtually every interactive terminal session you start, while remaining completely private to your account.

---

## 2. Testing Startup Operations in `~/.bashrc`

To verify that `~/.bashrc` runs for both non-login and login shells, we will add a simple message to it and test both environments.

### Step 1: Add the Startup Command
Open your personal `.bashrc` in `nano`:

```bash
nano ~/.bashrc
```

> **Permission Note:** Because this file is located inside your home directory and owned by you, you **do not** use `sudo`.

Scroll to the bottom of the file, add this line, and save (`Ctrl + O`, `Enter`, then `Ctrl + X`):

```bash
echo "this is for user-wide (login and non-login)"
```

---

### Step 2: Test in a Regular Terminal (Non-Login Shell)
Open a new tab or window in your standard desktop terminal:

```bash
this is for user-wide (login and non-login)
abdullah@fedora:~$ 
```

**Result:** The message prints immediately upon opening the window.  
**Why?** Every standard interactive non-login shell executes `~/.bashrc` during its startup sequence.

---

### Step 3: Test via SSH (Login Shell)
Now initiate an authenticated login session over SSH:

```bash
abdullah@fedora:~$ ssh abdullah@localhost
abdullah@localhost's password: 
this is for user-wide (login and non-login)
Last login: Fri Oct 23 16:30:00 2026 from 127.0.0.1
abdullah@fedora:~$
```

**Result:** The message prints here as well.  
**Why?** Even though SSH launches a login shell, your personal login sequence loads `~/.bashrc` to pull in your user environment.

Exit the SSH session:
```bash
abdullah@fedora:~$ exit
logout
Connection to localhost closed.
abdullah@fedora:~$
```

---

## 3. Applying Changes Instantly: `source`

When you edit `~/.bashrc`, open terminal windows do not detect the change automatically. Instead of closing and reopening your terminal emulator, you can instruct your current shell to reload the file in place using `source`:

```bash
source ~/.bashrc
```

*(You can also use the shorter POSIX dot shortcut: `. ~/.bashrc`)*

`source` reads and executes every line in the file directly within your active shell session.

---

## 4. What Operations Belong in `~/.bashrc`?

Because `~/.bashrc` runs for every interactive shell, it is the primary location for:

* **Command Aliases:** Custom terminal shortcuts (e.g., `alias gs="git status"`).
* **Terminal Prompt Customization:** Defining color schemes and formats for `$PS1`.
* **Personal Environment Variables:** Variables like `export EDITOR="nano"` or custom tool paths.
* **Custom Functions:** Small Bash helper functions you want available at any prompt.

---

## 5. Cleaning Up the Test Line

Remove the test line so it does not print every time you open a terminal:

```bash
nano ~/.bashrc
```
Scroll to the bottom, delete the `echo "this is for user-wide (login and non-login)"` line, and save the file (`Ctrl + O`, `Enter`, then `Ctrl + X`).

---

## Key Takeaways

* **User Scope & Isolation:** `~/.bashrc` lives in your personal home folder; other users on the system will never trigger or see your startup scripts.
* **Dual Execution:** Runs directly for non-login terminals and is called during login sessions, making it universal for interactive work.
* **Reloading Configuration:** Use `source ~/.bashrc` (or `. ~/.bashrc`) to apply changes immediately to your current session.
* **Core Purpose:** The standard place to define personal aliases, shell prompts, helper functions, and custom variables.