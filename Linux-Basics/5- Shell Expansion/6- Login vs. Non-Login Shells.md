# Login vs. Non-Login Shells

Whenever you interact with a terminal in Linux, Bash runs in one of two basic modes: a **Login Shell** or a **Non-Login Shell**.

Understanding this distinction is important because each mode reads different startup files when it turns on.

---

## 1. What is a Login Shell?

A **Login Shell** is a shell that starts when you authenticate with your credentials (entering a username and password, or using an SSH key).

Because you are logging in fresh, the system treats this as a brand-new session and runs special startup scripts to set up your entire environment.

### Common Examples:
* Connecting to a server over **SSH**: `ssh abdullah@fedora`
* Switching to a virtual console on your machine (e.g., using `Ctrl + Alt + F3`)
* Running bash explicitly with the login flag: `bash --login`

---

## 2. What is a Non-Login Shell?

A **Non-Login Shell** is a shell started *after* you have already logged in. It does not ask for your username or password.

Because your session is already active, this shell simply inherits your existing environment variables from the desktop or parent session.

### Common Examples:
* Opening a new terminal window or tab on your desktop
* Typing `bash` inside an existing terminal to open a subshell

---

## 3. The Quick Difference

```text
┌──────────────────┬─────────────────────────────┬─────────────────────────────────┐
│ Feature          │ Login Shell                 │ Non-Login Shell                 │
├──────────────────┼─────────────────────────────┼─────────────────────────────────┤
│ Authentication   │ Requires login credentials  │ No credentials needed           │
│ Typical scenario │ SSH, raw console login      │ Opening a terminal on desktop   │
│ Environment      │ Built from scratch          │ Inherited from parent session   │
└──────────────────┴─────────────────────────────┴─────────────────────────────────┘
```

---

## 4. How to Check Which Shell You Are Using

Bash provides a quick trick to check your shell type using the parameter `$0` (which shows the name of the currently running shell program).

### Step 1: Check Your Active Desktop Terminal (Non-Login)
Run the command directly in your regular terminal window:

```bash
abdullah@fedora:~$ echo $0
bash
```
*(or `/bin/bash`)*

Notice there is **no hyphen** in front of the name. This confirms your active desktop session is a normal **Non-Login Shell**.

---

### Step 2: Simulate a Login Shell Using Local SSH
To see what a login shell looks like without leaving your desk, SSH into your own machine (`localhost`):

```bash
abdullah@fedora:~$ ssh abdullah@localhost
abdullah@localhost's password: 
abdullah@fedora:~$ echo $0
-bash
```

Notice the **hyphen (`-`)** right in front of `-bash`. That leading minus sign is the operating system's internal flag confirming: *"This process is a genuine Login Shell."*

To exit the login test and return to your regular terminal:
```bash
abdullah@fedora:~$ exit
logout
Connection to localhost closed.
abdullah@fedora:~$
```

---

## Key Takeaways

* **Non-Login Shell:** The standard shell you use when opening a terminal on your desktop. `echo $0` displays plain `bash`.
* **Login Shell:** Initialized when authenticating (like via SSH). `echo $0` displays `-bash` with a leading hyphen.
* **Why It Matters:** The presence or absence of that hyphen tells Bash which startup configuration files to execute when turning on.