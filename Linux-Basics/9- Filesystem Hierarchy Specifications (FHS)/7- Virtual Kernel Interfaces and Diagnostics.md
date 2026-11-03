# Virtual Kernel Interfaces and Diagnostics

The Linux kernel does not hide live system internals behind black-box diagnostic tools. Instead, it creates **pseudo-filesystems** that look and act like standard directories, but exist entirely inside system RAM. This lesson covers how to inspect running processes, check CPU and memory health, and view hardware drivers using **`/proc`** and **`/sys`**.

---

## 1. The FHS Blueprint

```text
/ (The Root)
│
├── 1. Core System Binaries & Libraries (System Software)
│   ├── /usr          ── Main home for programs & libraries
│   ├── /bin          ── Everyday commands (-> /usr/bin)
│   ├── /sbin         ── Admin maintenance tools (-> /usr/sbin)
│   ├── /lib, /lib64  ── Shared runtime libraries (.so)
│   └── /opt          ── Standalone third-party software
│
├── 2. Configuration & User Data (Saved Files)
│   ├── /etc          ── System-wide settings and configs
│   ├── /home         ── Personal folders for regular users
│   └── /root         ── Personal home folder for admin
│
├── 3. Dynamic, Temporary, and Service Data (Changing Files)
│   ├── /var          ── Files that grow over time (logs, spool)
│   ├── /run          ── Active program data created since boot
│   ├── /tmp          ── Temporary scratchpad for any user/app
│   └── /srv          ── Data served to outside users (web, ftp)
│
├── 4. Hardware, Disks, and Storage (Attached Drives)
│   ├── /dev          ── Device files representing physical and virtual hardware
│   ├── /boot         ── Startup files, Linux kernel, and bootloader menu
│   ├── /mnt          ── Manual mount point for storage drives attached by the admin
│   └── /media        ── Automatic mount point for removable drives (USBs, memory cards)
│
└── 5. Virtual Kernel Interfaces (Live System Diagnostics) ─────────────────┐
    ├── /proc         ── Live view of running processes and CPU/RAM status  │ ] ── [CURRENT LESSON]
    └── /sys          ── Live view of hardware devices and kernel drivers ──┘
```

---

## 2. What Is a Pseudo-Filesystem?

If you check the disk space used by `/proc` or `/sys`:

```bash
abdullah@fedora:~$ df -h /proc /sys
Filesystem      Size  Used Avail Use% Mounted on
proc               0     0     0    - /proc
sysfs              0     0     0    - /sys
```

They report **0 bytes** of disk space used.

- **Pseudo-filesystems** do not exist on your SSD or hard disk.
- When you open or read a file in `/proc` or `/sys`, the Linux kernel generates the text content **on the fly in RAM**.
- This allows administrators and terminal utilities (like `htop`, `free`, `ps`, and `lscpu`) to query live kernel data using simple commands like `cat`.

---

## 3. Processes and System Health: `/proc`

**`/proc`** stands for **Processes**. It is the window into active tasks running on your computer and current kernel metrics.

### A. Numbered Folders (Process IDs)
When you run `ls /proc`, you will see hundreds of numbered folders:

```bash
abdullah@fedora:~$ ls /proc | head -n 8
1
1240
1589
2104
2215
acpi
asound
buddyinfo
```

- Each number is the active **PID (Process ID)** of a program currently running.
- If your text editor has PID `1240`, checking `/proc/1240/cmdline` shows the exact command that launched it, and `/proc/1240/status` shows how much RAM it is consuming right now.
- When the program closes, the kernel deletes that numbered folder instantly from memory.

### B. Hardware and Performance Files in `/proc`
Instead of installing heavy diagnostic tools, you can read system hardware stats directly:

```bash
# View CPU model, clock speed, and core count:
cat /proc/cpuinfo

# View total, free, and cached memory (RAM):
cat /proc/meminfo

# Check how long the computer has been powered on (in seconds):
cat /proc/uptime

# View the exact Linux kernel version:
cat /proc/version
```

---

## 4. Hardware Tree and Kernel Drivers: `/sys`

**`/sys`** stands for **System Filesystem** (`sysfs`).

While `/proc` is primarily focused on **processes and running software**, `/sys` is dedicated to **physical hardware components and kernel drivers**.

```text
 /sys/
 ├── block/     ── Physical storage blocks (sda, nvme0n1)
 ├── bus/       ── Hardware connection buses (pci, usb, i2c)
 ├── class/     ── Devices grouped by category (net, power_supply, drm)
 ├── devices/   ── The master hardware tree of the entire motherboard
 └── power/     ── System sleep, suspend, and hibernation states
```

### Practical Uses of `/sys`:
You can query and even modify hardware states by reading or echoing values into `/sys` files:

```bash
# Check battery level on a laptop:
cat /sys/class/power_supply/BAT0/capacity

# Check network link speed on an Ethernet interface:
cat /sys/class/net/eth0/speed

# Inspect screen brightness level:
cat /sys/class/backlight/*/brightness
```

---

## 5. Summary Reference

```text
┌──────────────────────────────┬────────────────────────────────────────────────────────┐
│ Directory                    │ Role in the System                                     │
├──────────────────────────────┼────────────────────────────────────────────────────────┤
│ Pseudo-Filesystem            │ RAM-only directory generated on the fly by the kernel. │
│ /proc                        │ Live view of running processes (PIDs) and memory/CPU.  │
│ /proc/cpuinfo                │ Real-time CPU processor details and core architecture. │
│ /proc/meminfo                │ Live RAM utilization and buffer counters.              │
│ /sys                         │ Hardware topology, device drivers, and power controls. │
└──────────────────────────────┴────────────────────────────────────────────────────────┘
```

---

## Key Takeaways

- **RAM-Only Directories:** Files inside `/proc` and `/sys` take zero space on your storage drive; reading them queries the Linux kernel directly in memory.
- **Process Tracking (`/proc`):** Every active task receives a numbered directory (`/proc/<PID>`) that disappears the instant the process terminates.
- **Instant Diagnostics:** Built-in files like `/proc/meminfo` and `/proc/cpuinfo` provide hardware metrics without needing external tools.
- **Hardware Management (`/sys`):** Maps connected devices by type (network, power, displays), allowing control over drivers, battery states, and power configurations.