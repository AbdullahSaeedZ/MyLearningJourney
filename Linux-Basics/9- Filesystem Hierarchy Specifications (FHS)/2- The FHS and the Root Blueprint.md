# The Filesystem Hierarchy Standard (FHS) and the Root Blueprint

Linux directory layouts are not arbitrary or left to each distribution's whim. To ensure cross-compatibility for software, packages, and scripts, the structure follows a formal specification maintained by the Linux Foundation known as the **Filesystem Hierarchy Standard (FHS)**, aligned with **POSIX** standards.

---

## 1. What Are POSIX and FHS?

- **POSIX (Portable Operating System Interface):** A family of open standards defined by the IEEE to ensure compatibility between Unix-like systems (such as Linux, macOS, and BSD). It mandates common system calls, command behavior, and core terminal utilities.
- **FHS (Filesystem Hierarchy Standard):** A formal document hosted by the Linux Foundation that establishes the exact layout and purpose of directories directly beneath `/`.

Thanks to the FHS, whether you deploy a web application on Fedora, Ubuntu, Debian, or Rocky Linux, the server configuration files are always located in `/etc`, logs are placed in `/var/log`, and global commands reside in `/usr/bin`.

---

## 2. Legacy Layouts vs. The Modern UsrMerge

Historically, Unix systems had severe storage hardware limits. Administrators separated essential tools needed to boot or repair a broken system (`/bin`, `/sbin`, `/lib`) from general everyday applications (`/usr/bin`, `/usr/lib`).

### The Modern Consolidation (UsrMerge)
Modern storage drives are large and fast, rendering this historical partition split obsolete. Most modern distributions (including Fedora, Arch, and current Debian/Ubuntu releases) unified these duplicate directories into **`/usr`**.

To prevent breaking older software or existing scripts that hardcode legacy paths like `#!/bin/bash`, the system uses **symbolic links** at the root level:

```bash
abdullah@fedora:~$ ls -ld /bin /sbin /lib /lib64
lrwxrwxrwx. 1 root root 7 Oct 31 00:00 /bin -> usr/bin
lrwxrwxrwx. 1 root root 8 Oct 31 00:00 /sbin -> usr/sbin
lrwxrwxrwx. 1 root root 7 Oct 31 00:00 /lib -> usr/lib
lrwxrwxrwx. 1 root root 9 Oct 31 00:00 /lib64 -> usr/lib64
```

- When a program calls `/bin/grep`, the symlink transparently routes the kernel to `/usr/bin/grep`.
- This ensures full backward compatibility while keeping all system binaries organized in a single unified directory.

---

## 3. The Complete Root Blueprint

The entire Linux filesystem branches out from **`/`** into five functional categories:

```text
/ (The Root)
│
├── 1. Core System Binaries & Libraries (System Software)
│   ├── /usr          ── Main home for programs, libraries, and system assets
│   ├── /bin          ── Everyday commands used by all users (symlink to /usr/bin)
│   ├── /sbin         ── Administrative tools for the root user (symlink to /usr/sbin)
│   ├── /lib, /lib64  ── Shared code libraries needed to run programs (symlinks to /usr/lib*)
│   └── /opt          ── Standalone third-party software (Chrome, custom apps)
│
├── 2. Configuration & User Data (Saved Files)
│   ├── /etc          ── System-wide settings and editable text configuration files
│   ├── /home         ── Personal folders and private files for regular users
│   └── /root         ── Personal home folder for the root administrator
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

## 4. Summary Reference

```text
┌──────────────────────────────┬────────────────────────────────────────────────────────┐
│ Concept / Component          │ Role in the System                                     │
├──────────────────────────────┼────────────────────────────────────────────────────────┤
│ POSIX Standards              │ Guarantees shared commands and behaviors across Unixes.│
│ FHS Specification            │ Standardizes directory paths under / across distros.   │
│ UsrMerge                     │ Replaces legacy root folders with symlinks into /usr/. │
│ The Five FHS Branches        │ Categorizes files by binaries, configs, changing data, │
│                              │ hardware/disks, and live kernel diagnostic interfaces. │
└──────────────────────────────┴────────────────────────────────────────────────────────┘
```

---

## Key Takeaways

- **Standardized Tree:** The FHS ensures that system administrators and developers find directories in predictable locations across any standard Linux distribution.
- **UsrMerge Simplification:** Root-level directories like `/bin`, `/sbin`, and `/lib` are modern symlinks pointing into `/usr/` to preserve backward compatibility without file fragmentation.
- **Clear Categorization:** The root directory is systematically divided between read-only software, configuration files, dynamic operational data, hardware storage mounts, and virtual memory interfaces.