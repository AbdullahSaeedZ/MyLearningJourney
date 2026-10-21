# Basic System and Output Commands

This lesson covers standard commands used to print text, inspect the current user context, retrieve operating system and kernel information, and check network interface configurations.

---

## 1. Printing Text to the Screen (`echo`)

The `echo` command prints text directly to the terminal screen (standard output).

```bash
echo "Hello, Linux"
# Output: Hello, Linux
```

### Key Uses
* **Displaying messages:** Common in terminal tasks and scripts to print status messages or notes.

### Useful Option: `-e` (Enable Backslash Escapes)
By default, `echo` prints literal text. The `-e` flag allows the use of escape characters like newlines (`\n`) or tabs (`\t`):
```bash
echo -e "First Line\nSecond Line"
```

---

## 2. User Identity (`whoami`)

The `whoami` command prints the username of the user currently running the shell session.

```bash
whoami
# Output: abdullah
```

* Useful to verify whether you are currently operating as a normal user or as the administrative superuser (`root`) after using privilege elevation commands.

---

## 3. System and Kernel Details (`uname`)

The `uname` (Unix Name) command prints information about the system and its underlying Linux kernel.

```bash
uname
# Output: Linux
```

### The Essential Flag: `-a` (All)
Running `uname` by itself only prints the kernel name (`Linux`). Adding the **`-a` (all)** flag prints the complete system profile:

```bash
uname -a
```
* **Output breakdown:**
    * **Kernel Name:** e.g., `Linux`
    * **Hostname:** The computer's local network name.
    * **Kernel Release:** The specific kernel version running (e.g., `6.8.0-generic`).
    * **Hardware Architecture:** e.g., `x86_64` (64-bit AMD/Intel) or `aarch64` (ARM).

---

## 4. Network Configuration (`ip a`)

The `ip` utility is the modern Linux standard for inspecting and configuring network interfaces and addresses (replacing the older `ifconfig` tool).

The sub-command **`ip a`** (short for `ip address` or `ip addr show`) displays all network interfaces and their assigned IP addresses.

```bash
ip a
```

### Key Network Interfaces to Look For
1. **`lo` (Loopback interface):**
    * Represents the local machine internally (`127.0.0.1` / `::1`). Network traffic sent here never leaves your system.
2. **`eth0`, `enp3s0`, or `eno1` (Ethernet interfaces):**
    * Wired network connections.
3. **`wlan0` or `wlp2s0` (Wireless interfaces):**
    * Wi-Fi network connections.

### Finding Your Local IP Address
Under each interface block, look for lines starting with:
* **`inet`:** Followed by your local IPv4 address (e.g., `inet 192.168.1.50/24`).
* **`inet6`:** Followed by your IPv6 address.

> **Fast Alternative:** To print only assigned local IP addresses cleanly without extra metadata, run:
> ```bash
> hostname -I
> ```

---

## Summary Reference Table

| Task | Command | Purpose |
| :--- | :--- | :--- |
| Print text to screen | `echo <text>` | Display text output |
| Print active username | `whoami` | Check current user session identity |
| Check kernel and architecture | `uname -a` | Display full system and kernel specifications |
| Inspect network & IP addresses | `ip a` | List network interfaces and assigned IPs |
| Quick local IP lookup | `hostname -I` | Print assigned IPv4 addresses only |