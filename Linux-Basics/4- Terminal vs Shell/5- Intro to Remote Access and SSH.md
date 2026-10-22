# Remote Access and SSH: The Terminal and Shell Separated

Throughout this module, we explored terminals, emulators, shells, and processes on a single physical machine. **SSH** (**S**ecure **Sh**ell) provides the ultimate demonstration of this architecture by physically splitting the terminal display and the shell interpreter across a network.

*(Note: We will cover full server setups, SSH keys, and firewall configurations in a dedicated later module. Here, we focus strictly on the architecture and verifying it via processes.)*

---

## 1. What is a Daemon?

In the previous lesson, we noticed that background services show a `?` under the `TTY` column in `ps`. In Linux, these background services are called **daemons**.

* A **daemon** is a program that runs silently in the background rather than being actively controlled by an interactive user.
* Daemons usually start when the system boots and wait for specific events or incoming requests.
* By convention, daemon program names often end with the letter **`d`**:
    * `systemd`: System and service manager daemon.
    * `httpd`: HTTP web server daemon (Apache).
    * `sshd`: Secure Shell daemon (listens for incoming SSH connection requests).

Because a daemon does not have an attached screen, keyboard, or window, it has no controlling terminal (`TTY = ?`).

---

## 2. Setting Up SSH (Client & Server)

Most Linux installations come with the `ssh` client pre-installed, but the `sshd` server daemon must often be explicitly installed and enabled.

### Step 1: Install OpenSSH Server
* **On Fedora / RHEL:**
  ```bash
  sudo dnf install openssh-server -y

### Step 2: Start and Enable the Daemon
Start the background daemon immediately and enable it to start on system boot:

* **On Fedora / RHEL (Service name is `sshd`):**
  ```bash
  sudo systemctl enable --now sshd
  ```
* **On Ubuntu / Debian (Service name can also be `ssh`):**
  ```bash
  sudo systemctl enable --now ssh
  ```

Verify that the daemon is actively running:
```bash
systemctl status sshd
```
The output should report `Active: active (running)`.

---

## 3. The Core Architecture: Splitting the Layers

When connecting to a server, your local workstation handles only the visual interface, while the target machine handles the execution:

```text
+------------------------------------+           +------------------------------------+
|        LOCAL MACHINE (CLIENT)      |           |       REMOTE MACHINE (SERVER)      |
|                                    |           |                                    |
|   +----------------------------+   |           |   +----------------------------+   |
|   | Terminal Emulator (Kitty)  |   |           |   |     Remote Shell (Bash)    |   |
|   +--------------┬-------------+   |           |   +--------------▲-------------+   |
|                  │                 |           |                  │                 |
|                  ▼                 |           |                  │                 |
|   +----------------------------+   |           |   +──────────────┴─────────────+   |
|   |         ssh client         |   |           |   |   sshd (Server Daemon)     |   |
|   +--------------┬-------------+   |           |   |   (Allocates a remote PTS) |   |
|                  │                 |           |   +──────────────▲─────────────+   |
+──────────────────┼─────────────────+           +──────────────────┼─────────────────+
                   │                                                │
                   └─────────── [ ENCRYPTED NETWORK ] ──────────────┘
```

* **Local Machine:** Runs your terminal emulator. It captures keystrokes and draws characters on your physical monitor.
* **Network Tunnel:** The `ssh` client encrypts your keystrokes and transmits them across the network.
* **Remote Machine:** The `sshd` background daemon receives the stream, provisions an isolated **remote PTS**, and launches a remote **Shell** to interpret your commands.

---

## 4. Local Demo vs. Real Remote Server

To demonstrate this concept without provisioning an external cloud server, we can SSH into our own local machine (`localhost`):

* **How this demo works:** Your computer acts as both client and server. Your local `ssh` command connects to your local `sshd` daemon running in the background.
* **How it differs from a real remote server:**
    * **In this demo:** Network packets loop through the local loopback interface (`127.0.0.1`), and both sessions share your local CPU and RAM.
    * **On a real remote server:** The server is a separate machine across the network, running its own operating system, kernel, and process tree.
* Despite sharing hardware during this demo, the operating system still isolates the connection onto a separate virtual terminal line.

---

## 5. Proving the Separation with `ps` and `tty`

You do not have to guess whether an independent session was created. The `tty` and `ps` commands confirm the separation immediately.

### Step 1: Check Your Initial Session
Before connecting, inspect your current terminal line:

```bash
tty
```
Output:
```text
/dev/pts/0
```

Check your active processes:
```bash
ps -f
```
Output:
```text
UID          PID    PPID  C STIME TTY          TIME CMD
abdullah   18420   10240  0 10:15 pts/0    00:00:00 bash
```

Now connect via SSH:
```bash
ssh $USER@localhost
```
*(Enter your user password when prompted)*

---

### Step 2: Check the Session After Connecting
Once authenticated, check the terminal line again:

```bash
tty
```
Output:
```text
/dev/pts/2
```
*(Notice that this is a completely different PTS endpoint allocated by `sshd`.)*

Now inspect the processes running on this active session:
```bash
ps -f
```
Output:
```text
UID          PID    PPID  C STIME TTY          TIME CMD
abdullah   31204   31200  0 10:30 pts/2    00:00:00 -bash
abdullah   31580   31204  0 10:31 pts/2    00:00:00 ps -f
```

To close the SSH session and return to your primary terminal:
```bash
exit
```

---

## 6. Tracing the Full Execution Chain

```text
==================================================================================================
SCENARIO A: BARE HARDWARE CONSOLE (tty3)
==================================================================================================
[ KERNEL ]
    │
    ▼ Direct physical display slot
[ TTY 3 Slot ]
    │
    ▼ Spawns interpreter directly
[ Bash Shell ]

Chain: Kernel ──> TTY (Console) ──> Shell


==================================================================================================
SCENARIO B: DESKTOP WORKSTATION CONNECTING VIA SSH
==================================================================================================
[ PHYSICAL HARDWARE ]
    │
    ▼ Kernel provisions physical display slots
[ LOCAL TTY SLOT ] (tty1 or tty2 — Your actual physical screen)
    │
    ▼ Runs your compositor inside this physical screen slot
[ Niri Compositor ]
    │
    ▼ Launches graphical desktop window
[ Terminal Emulator (Kitty) ]
    │
    ▼ Spawns local shell in a virtual memory pipe
[ Local Bash Shell ]  ───► Running on: /dev/pts/0 (LOCAL PTS)
    │
    ▼ Executes SSH client command
[ ssh client ]        ───► Running on: /dev/pts/0 (LOCAL PTS)
    │
    │  (Encrypted Network Socket)
    ▼
[ sshd daemon ]       ───► Running in Background (TTY = ?, no screen)
    │
    ▼ Allocates a fresh virtual memory pipe (NOT a TTY slot!)
[ Remote Bash Shell ] ───► Running on: /dev/pts/2 (REMOTE PTS)

Chain: Local TTY ──> Niri ──> Kitty ──> Local Bash (pts/0) ──> ssh ──> sshd ──> Remote Bash (pts/2)
==================================================================================================
```

> **Important Note: A PTS Does Not Require a TTY**  
> A common misconception is thinking that every PTS must be hosted inside a TTY. It does not.
> * **TTYs** (`tty1`–`tty6`) are physical console slots directly tied to physical monitor hardware.
> * **PTSs** (`/dev/pts/*`) are pure software pipes living in memory.  
    > When you SSH into a remote server, the server never switches or touches its physical TTY slots. The `sshd` background daemon communicates directly with the Linux kernel to create an independent `/dev/pts/` device purely in software.

### Process Inspection Takeaways:
1. **A New Shell Instance:** The shell inside the SSH session has a distinct PID (`31204`), completely isolated from your initial Bash process (`18420`).
2. **The Parent Process (`PPID`):** Tracing the parent of this shell (`PPID: 31200`) leads straight to `sshd`. The background SSH daemon is the process parent that allocated the PTS and spawned the shell.
3. **Endpoint Isolation:** Keystrokes typed into Kitty on `pts/0` are forwarded through the `ssh` network stream into `sshd`, which writes them to `/dev/pts/2`.

---

## Key Takeaways

* **Daemon:** A background service running without a controlling terminal (`TTY = ?`), usually designated by a trailing `d` (like `sshd`).
* **Decoupled Architecture:** SSH proves that the terminal emulator (client display) and the shell (server interpreter) can run across distinct machines and virtual devices.
* **PTS Independence:** A PTS does not need a local or remote TTY; it is an independent virtual software pipe provisioned by the kernel on demand.
* **Process Verification:** Running `tty` and `ps -f` exposes the exact parent-child link between `sshd` and your active remote shell session.