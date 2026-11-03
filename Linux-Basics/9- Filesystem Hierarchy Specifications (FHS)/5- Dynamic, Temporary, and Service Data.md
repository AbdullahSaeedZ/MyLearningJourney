# Dynamic, Temporary, and Service Data

Unlike static application binaries in `/usr` or manual settings in `/etc`, modern operating systems generate large volumes of operational data during execution. Linux categorizes this data by lifespan, persistence, and consumer: data that grows over time (**`/var`**), transient runtime state (**`/run`**), volatile scratchpads (**`/tmp`**), and network-facing service payloads (**`/srv`**).

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
├── 3. Dynamic, Temporary, and Service Data (Changing Files) ─────┐
│   ├── /var          ── Files that grow over time (logs, spool)  │
│   ├── /run          ── Active program data created since boot   │ ] ── [CURRENT LESSON]
│   ├── /tmp          ── Temporary scratchpad for any user/app    │
│   └── /srv          ── Data served to outside users (web, ftp) ─┘
│
├── 4. Hardware, Disks, and Storage (Attached Drives)
│   ├── /dev          ── Device files representing physical and virtual hardware
│   ├── /boot         ── Startup files, Linux kernel, and bootloader menu
│   ├── /mnt          ── Manual mount point for storage drives attached by the admin
│   └── /media        ── Automatic mount point for removable drives (USBs, memory cards)
│
└── 5. Virtual Kernel Interfaces (Live System Diagnostics)
    ├── /proc         ── Live view of running processes and CPU/RAM status (in-memory)
    └── /sys          ── Live view of hardware devices and kernel drivers (in-memory)
```

---

## 2. Persistent Variable Data: `/var`

**`/var`** stands for **Variable**. It houses multi-user data that is expected to grow dynamically and continually change during normal system operation.

Unlike temporary directories, data in `/var` **persists across reboots**.

```text
 /var/
 ├── log/       ── System and service log files (journald, audit, auth)
 ├── cache/     ── Application cache data (e.g., dnf package metadata)
 ├── spool/     ── Queued tasks waiting for processing (print queues, cron jobs)
 ├── lib/       ── Dynamic state information maintained by services (e.g., databases)
 └── tmp/       ── Temporary files preserved between reboots
```

### Key Subdirectories in `/var`:
1. **`/var/log/`:** The most critical directory for system administrators. Contains text logs and binary journals recording authentication attempts, kernel errors, package installations, and service diagnostics.
2. **`/var/lib/`:** Holds persistent state information and internal application databases. For instance, package managers (`/var/lib/dnf`) and relational databases (like PostgreSQL in `/var/lib/pgsql` or MySQL) store their core data files here by default.
3. **`/var/cache/`:** Locally cached data generated from remote repositories (such as package manager repository indexes). Deleting cache files frees disk space without corrupting system functionality.

---

## 3. Ephemeral Runtime State: `/run`

**`/run`** is a standardized runtime directory that describes the live system state **since the last boot**.

It does not reside on a physical hard drive or SSD. Instead, it is mounted as a **`tmpfs`** (a virtual in-memory filesystem stored directly in RAM):

```bash
abdullah@fedora:~$ df -h /run
Filesystem      Size  Used Avail Use% Mounted on
tmpfs           7.8G  2.1M  7.8G   1% /run
```

### What Lives in `/run`?
When background daemons and system services run, they write lightweight communication and locking tokens:
- **PID Files (`*.pid`):** Small plain text files containing the numerical Process ID of an active background daemon (e.g., `/run/sshd.pid`), preventing the service from starting twice.
- **UNIX Domain Sockets (`*.sock`):** Inter-Process Communication (IPC) sockets allowing local programs to exchange data at memory speed (e.g., systemd sockets, Wayland display sockets).
- **Process Locks:** Temporary lock files preventing concurrent processes from colliding.

> **Key Rule of `/run`:** Because `/run` lives in RAM, its entire contents are cleared automatically whenever the machine is powered off or rebooted.

---

## 4. The Shared Scratchpad: `/tmp` vs. `/var/tmp`

Both directories provide unconstrained scratchpad storage where any user or program can write temporary files, but their cleanup behavior is fundamentally different.

```text
┌──────────────┬──────────────────┬────────────────────────┬────────────────────────────────────┐
│ Directory    │ Physical Storage │ Cleanup Behavior       │ Primary Administrative Use         │
├──────────────┼──────────────────┼────────────────────────┼────────────────────────────────────┤
│ /tmp         │ RAM (tmpfs) or   │ Emptied automatically  │ Short-lived scratch files, session │
│              │ root filesystem  │ on reboot or timer     │ locks, build intermediates.        │
├──────────────┼──────────────────┼────────────────────────┼────────────────────────────────────┤
│ /var/tmp     │ Physical Storage │ Preserved across       │ Large crash dumps, long-running    │
│              │ (Disk drive)     │ reboots                │ installation buffers, job state.   │
└──────────────┴──────────────────┴────────────────────────┴────────────────────────────────────┘
```

### The Sticky Bit (`t`) on `/tmp`:
Inspect permissions on `/tmp`:

```bash
abdullah@fedora:~$ ls -ld /tmp
drwxrwxrwt. 28 root root 4096 Nov 4 00:30 /tmp
```

- Notice the trailing **`t`** in `drwxrwxrwt`. This special permission flag is called the **Sticky Bit**.
- While any user on the machine can create and write files inside `/tmp`, the sticky bit ensures that **only the user who created a file (or root) can delete or rename it**. This prevents unprivileged users from deleting each other's temporary application files.

---

## 5. Files Served to Other People: `/srv`

**`/srv`** stands for **Service Data**.

Simply put, this folder is where you put files that your computer serves or gives to other people over the network:

- If your machine is hosting a website, the website files (HTML, CSS, images) can be placed in `/srv/www/`.
- If your machine is a file server where coworkers download company documents (via FTP), those shared files go in `/srv/ftp/`.

### The Core Idea:
Instead of putting public website or download files inside your personal `/home/` folder or mixing them into system logs, you put them in `/srv`. It is just a tidy, dedicated shelf for files meant for outside visitors.

---

## 6. Summary Reference

```text
┌──────────────────────────────┬────────────────────────────────────────────────────────┐
│ Directory                    │ Role in the System                                     │
├──────────────────────────────┼────────────────────────────────────────────────────────┤
│ /var                         │ Persistent operational data (logs, queues, databases). │
│ /run                         │ Ephemeral runtime state in RAM (PIDs, domain sockets). │
│ /tmp                         │ Global scratchpad protected by the sticky bit.         │
│ /var/tmp                     │ Disk-backed temporary storage preserved across reboots.│
│ /srv                         │ Files served directly to outside network visitors.     │
└──────────────────────────────┴────────────────────────────────────────────────────────┘
```

---

## Key Takeaways

- **Persistence Boundaries:** Data in `/var` stays on disk across system reboots; data in `/run` lives purely in RAM and is wiped on shutdown.
- **Diagnostic Core (`/var/log`):** The primary administrative destination for troubleshooting, system auditing, and service failure investigation.
- **Scratchpad Security (`/tmp`):** Open to all users for write access, but protected by the Sticky Bit (`t`) so users cannot tamper with or delete other users' files.
- **Files for Visitors (`/srv`):** A clean, designated folder for hosting files given to outside clients (like public website pages or FTP downloads).