# System Configuration and User Data

Linux strictly isolates configuration files from program executables and separates system-wide settings from individual user environments. This lesson covers where settings live, how user workspaces are segmented, and why administrative accounts are treated distinctly.

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
├── 2. Configuration & User Data (Saved Files) ─────────────┐
│   ├── /etc          ── System-wide settings and configs   │
│   ├── /home         ── Personal folders for regular users │ ] ── [CURRENT LESSON]
│   └── /root         ── Personal home folder for admin ────┘
│
├── 3. Dynamic, Temporary, and Service Data (Changing Files)
│   ├── /var          ── Files that grow over time (system logs, databases, cache)
│   ├── /run          ── Active program data created since boot (PIDs, process locks)
│   ├── /tmp          ── Temporary scratchpad for any user/app (cleared on reboot)
│   └── /srv          ── Data served to outside users (web pages, file server shares)
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

## 2. System-Wide Configuration: `/etc`

Historically an acronym for *"et cetera"*, **`/etc`** in modern Linux represents **Editable Text Configurations** (or *Extended Tool Chest*).

It contains host-specific, system-wide configuration files used by the operating system, daemons, and installed applications.

```bash
abdullah@fedora:~$ ls -d /etc/*.conf /etc/*passwd* /etc/*shadow* /etc/*group*
/etc/group          /etc/gshadow        /etc/passwd         /etc/shadow
/etc/host.conf      /etc/resolv.conf    /etc/vconsole.conf
```

### Key Architectural Rules of `/etc`:
1. **Plain Text Only:** Files in `/etc` are human-readable text files (JSON, YAML, INI, XML, or plain key-value pairs). They are never compiled binaries or executable scripts.
2. **System-Wide Scope:** Any setting defined in `/etc` affects **all users** on the system unless an individual user explicitly overrides it inside their own home directory.
3. **Admin Ownership:** Nearly every file in `/etc` is owned by `root:root` with read-only permissions for regular users (`0644`) or restricted access for sensitive files (`0600` or `0000` on `/etc/shadow`).

### Common Files:
- **Identity & Access:** `/etc/passwd`, `/etc/shadow`, `/etc/group`, `/etc/gshadow`.
- **Administrative Privileges:** `/etc/sudoers` (configured using `visudo`).
- **Networking:** `/etc/hosts` (local DNS overrides), `/etc/resolv.conf` (nameservers).
- **Filesystems:** `/etc/fstab` (static filesystem mount rules applied during boot).

---

## 3. Regular User Workspaces: `/home`

The **`/home`** directory serves as the parent container for standard, unprivileged user accounts.

```text
 /home/
 ├── abdullah/    ── UID 1000 personal files, desktop settings, bashrc
 ├── khalid/      ── UID 1001 personal files
 └── sara/        ── UID 1002 personal files
```

### Standard Structure of a User Directory:
Each regular user receives an isolated subdirectory named after their username (e.g., `/home/abdullah/`).

Inside their respective home directory, users have full ownership and write permissions (`rwx`). This space contains:
1. **Visible Data:** Documents, Downloads, Music, Projects, and Desktop files.
2. **Hidden Dotfiles & Configs (`~/.config`, `~/.bashrc`):** Application-specific settings that override global defaults defined in `/etc`. For example:
    - System default shell settings live in `/etc/bashrc`.
    - Your personal shell customizations live in `/home/abdullah/.bashrc` (or `~/.bashrc`).

---

## 4. The Administrative Workspace: `/root`

While regular users reside under `/home/<username>`, the superuser (root) has an entirely separate home directory located at the root of the filesystem: **`/root`**.

```bash
abdullah@fedora:~$ sudo ls -la /root
drwx------.  4 root root 4096 Oct 31 08:00 .
dr-xr-xr-x. 18 root root 4096 Oct 31 00:00 ..
-rw-------.  1 root root 1240 Oct 31 08:15 .bash_history
-rw-r--r--.  1 root root  141 Jan 24  2024 .bashrc
```

### Why Isn't Root Located in `/home/root`?
This separation is a critical disaster-recovery design decision:
- In production servers, `/home` is frequently mounted on a **separate physical drive or network share** (e.g., NFS or separate partition `/dev/sdb1`).
- If that drive fails, corrupts, or fails to mount during boot, the system enters **emergency maintenance mode**.
- Because `/root` sits directly on the core root partition (`/`), the administrator can still log in, load their shell environment, and access diagnostic tools even if the `/home` partition is completely inaccessible.

---

## 5. Summary Reference

```text
┌──────────────────────────────┬────────────────────────────────────────────────────────┐
│ Directory                    │ Role in the System                                     │
├──────────────────────────────┼────────────────────────────────────────────────────────┤
│ /etc                         │ System-wide plain text configuration files (all users).│
│ /home/<user>                 │ Personal workspaces and user-specific configurations.  │
│ /root                        │ Standalone home directory for the root administrator   │
│                              │ kept on the primary partition for emergency recovery.  │
└──────────────────────────────┴────────────────────────────────────────────────────────┘
```

---

## Key Takeaways

- **Text-Based Administration (`/etc`):** Linux services and kernel parameters are configured via plain text files stored in `/etc`, not opaque registry databases.
- **Hierarchy of Settings:** Global rules are defined in `/etc`; individual user customizations in `/home/<user>/.config` or dotfiles take precedence for that specific user.
- **Root Isolation (`/root`):** Kept separate from `/home` to ensure the administrator can log in and repair the machine even if secondary storage partitions fail to mount.