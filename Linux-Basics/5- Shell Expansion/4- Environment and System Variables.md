# Environment Variables and Special Shell Parameters

In the previous lesson, we created user-defined shell variables like `var2=test`. In this lesson, we examine **Environment Variables** and **Special System Parameters**—the core variables that configure your session, tell the shell where to find programs, track state across processes, and report exit codes.

---

## 1. Terminology: "Environment Variables" vs. "System Variables"

In casual conversation, administrators and developers often use these terms interchangeably, but technically:

- **Environment Variables:** The formal OS mechanism. An environment variable is any variable flagged in memory to be passed down (exported) to child processes.
- **System Variables:** A descriptive label for environment variables that are provided by default by the operating system, systemd, or the login manager (such as `PATH`, `USER`, `HOSTNAME`, `SHELL`, or `LANG`), as opposed to custom variables you created yourself (like `DATABASE_URL`).

At the operating system level, they use the exact same data structure: key-value pairs stored in the process's environment memory block (`environ`).

In short: yes, they are essentially the same.

---

## 2. Lifecycle and Scope: How Long Do They Last and Who Can See Them?

### A. Session vs. Permanent Storage
- **By default, variables exist ONLY in RAM for the active session:**  
  When you set a variable in your terminal (or when the shell initializes one), it lives solely inside that shell's RAM table. If you close your terminal emulator window, reboot, or type `exit`, that memory is wiped.
- **How to make them permanent:**  
will be explained in upcoming lessons.  

### B. Can Other Users See Your Variables?
- **No (under standard permissions):**  
  Every user session runs under its own User ID (UID). Linux memory isolation prevents standard users from reading the memory space of processes owned by someone else. Another user logged into the system cannot run `env` and see your active variables.
- **Exception:** The `root` user (superuser) has the authority to inspect the private memory of any process on the machine (e.g., by reading `/proc/<PID>/environ`).

### C. Can You See Them Over a Remote SSH Connection?
- **Local vs. Remote isolation:**  
  If you SSH into a remote server, that remote shell is an entirely different operating system instance with its own kernel and memory. It cannot see your workstation's local environment variables unless your SSH client explicitly forwards them via configuration (`SendEnv` / `AcceptEnv`).
- The remote session will instead load its own local environment configured on the remote host.

---

## 3. Shell Variables vs. Environment Variables (The Export Boundary)

```text
+-------------------------------------------------------------------------+
| Primary Bash Shell (abdullah@fedora)                                    |
|                                                                         |
|   ├── Local Shell Variable:     my_var=123     (Private to this shell)  |
|   └── Environment Variable:     USER=abdullah  (Exported to children)   |
|         │                                                               |
|         ▼ Spawns child process (e.g., a subshell, git, python3)         |
|   +-----------------------------------------------------------------+   |
|   | Child Process                                                   |   |
|   |   ├── CANNOT see: my_var                                        |   |
|   |   └── CAN see:    USER=abdullah                                 |   |
|   +-----------------------------------------------------------------+   |
+-------------------------------------------------------------------------+
```

- **Local Shell Variable:** Exists only in the current shell process. Subprocesses and child shells have zero access to it.
- **Environment Variable:** Exported into the process environment table. The kernel copies these variables into every child process spawned by the shell.

---

## 4. Elevating a Local Variable with `export`

You can promote any local shell variable into an environment variable using the built-in `export` command. This makes it visible to child processes.

### Without `export` (Local Only):
```bash
abdullah@fedora:~$ my_var="backend"
abdullah@fedora:~$ bash                  # Spawn a child shell
abdullah@fedora:~$ echo $my_var          # Prints nothing (empty)
abdullah@fedora:~$ exit                  # Return to parent shell
```

### With `export` (Inherited by Child):
```bash
abdullah@fedora:~$ export my_var         # Or declare directly: export my_var="backend"
abdullah@fedora:~$ bash                  # Spawn a child shell
abdullah@fedora:~$ echo $my_var
backend
abdullah@fedora:~$ exit                  # Return to parent shell
```

> **Note on Inheritance Direction:** Exporting is strictly a **top-down** operation. A parent exports copies down to its children, but a child process cannot export or change a variable in its parent shell.

---

## 5. Inspecting Core System Identifiers

Your shell populates standard environment variables the moment you log in:

### A. The Identity Variables: `$USER`, `$HOSTNAME`, and `$SHELL`
- **`$USER`**: The username of the logged-in account.
  ```bash
  abdullah@fedora:~$ echo $USER
  abdullah
  ```

- **`$HOSTNAME`**: The network machine name assigned to your system.
  ```bash
  abdullah@fedora:~$ echo $HOSTNAME
  fedora
  ```
  *(These two variables form the default terminal prompt: `abdullah@fedora`.)*

- **`$SHELL`**: The path to your default login shell binary.
  ```bash
  abdullah@fedora:~$ echo $SHELL
  /bin/bash
  ```

---

### B. The Command Search Path: `$PATH`
`$PATH` is the single most critical environment variable on a Linux system. It contains a colon-separated (`:`) list of directories where the OS searches for executable binaries when you run a command without specifying its exact file path:

```bash
abdullah@fedora:~$ echo $PATH
/usr/local/bin:/usr/bin:/bin:/usr/local/sbin:/usr/sbin
```

#### How the Shell Searches `$PATH`:
When you type `ls`, the shell searches each directory in `$PATH` from left to right:
1. Does `/usr/local/bin/ls` exist? No.
2. Does `/usr/bin/ls` exist? **Yes.**
3. The shell executes `/usr/bin/ls` and stops searching immediately.

If a command does not exist in any of those folders, the shell halts and reports: `Command not found`.

---

## 6. Other Essential Environment Variables in Production

| Variable | Represents | Typical Value |
| :--- | :--- | :--- |
| **`$HOME`** | Absolute path to the active user's home directory | `/home/abdullah` |
| **`$PWD`** | **P**resent **W**orking **D**irectory (where your shell currently sits) | `/home/abdullah/projects` |
| **`$OLDPWD`** | Previous working directory (powers `cd -`) | `/var/log` |
| **`$LANG`** | System locale and character encoding | `en_US.UTF-8` |
| **`$EDITOR`** | Default text editor used by CLI utilities (`git commit`, etc.) | `nano`, `vim` |

To list **every** currently exported environment variable in your session at once:
```bash
env
```
*(or `printenv`)*

---

## 7. Special Parameters: The Exit Status Code (`$?`)

Not every `$` token represents a standard variable stored in the environment. Some are **special automatic parameters** maintained dynamically by the kernel and shell.

The most important special parameter is **`$?`**, which holds the **exit status (return code)** of the *most recently executed foreground command*.

In Linux and Unix:
- **`0`** = **Success** (Clean execution, no errors).
- **Non-zero (`1` to `255`)** = **Error / Failure** (Indicates a specific error condition).

### Proving `$?` in Action

#### 1. A Successful Command:
```bash
abdullah@fedora:~$ echo $SHELL
/bin/bash
```

Check the exit code:
```bash
abdullah@fedora:~$ echo $?
0
```
*(Code `0` confirms the `echo` process terminated normally without errors.)*

#### 2. A Failed Command:
Run a command name that does not exist:
```bash
abdullah@fedora:~$ popo
bash: popo: command not found...
```

Inspect the exit code immediately:
```bash
abdullah@fedora:~$ echo $?
127
```

*(By Unix convention, exit status **`127`** specifically means "Command not found in `$PATH`". Other standard codes include `1` for general execution errors, `2` for syntax errors, and `130` when a process is terminated via `Ctrl + C`.)*

> **Critical Note on `$?`:**  
> `$?` updates after **every single command**. If you want to check why a command failed, you must inspect or capture `$?` immediately. Running any other command—even a simple `ls`—will immediately overwrite `$?` with the result of that new command.

---

## 8. Other Essential Special Parameters

| Parameter | Expands To | Description |
| :--- | :--- | :--- |
| **`$$`** | Process ID (PID) | The PID of the current shell instance. |
| **`$#`** | Argument count | Total number of arguments passed to a script or function. |
| **`$0`** | Executable name | The name of the currently executing script or shell binary. |
| **`$1`, `$2`...** | Positional arguments | The explicit arguments passed to a script ($1 is the first, $2 is the second). |
| **`$!`** | Background PID | The PID of the most recently executed background job. |

Verify your active shell PID:
```bash
abdullah@fedora:~$ echo $$
18420
```

---

## Key Takeaways

- **Naming Conventions:** "System variables" refers to built-in variables provided by the OS; "environment variables" describes the mechanism that exports variables to child processes.
- **Scope and Persistence:** Environment variables exist in volatile RAM for the duration of that shell session. To persist them across reboots, they must be saved to configuration files like `~/.bashrc`.
- **Process Isolation:** Variables are isolated to your user session. Other non-root users cannot read your session's memory, and remote SSH hosts do not see your local environment.
- **Inheritance with `export`:** Use `export` to pass variables down to child processes and subshells.
- **Search Mechanics (`$PATH`):** Directs the shell to search specific directories in order when resolving commands. - **The Exit Status (`$?`):** The universal status code of the last run command (`0` = success, non-zero = failure).