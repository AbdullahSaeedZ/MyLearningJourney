# Core System Binaries and Libraries

In Linux, application code, executable commands, and shared code libraries are organized systematically to prevent system files from mixing with user configuration or dynamic application data. This lesson covers the primary software directories located under `/`.

---

## 1. The FHS Blueprint

```text
/ (The Root)
│
├── 1. Core System Binaries & Libraries (System Software) ──┐
│   ├── /usr          ── Main home for programs & libraries │
│   ├── /bin          ── Everyday commands (-> /usr/bin)    │
│   ├── /sbin         ── Admin maintenance tools (-> /sbin) │ ] ── [CURRENT LESSON]
│   ├── /lib, /lib64  ── Shared runtime libraries (.so)     │
│   └── /opt          ── Standalone third-party software ───┘
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

## 2. The Primary Software Container: `/usr`

**`/usr`** stands for **Unix System Resources**. In modern Linux systems, it is the primary repository for all read-only, user-space system software, utilities, shared libraries, and documentation installed by the package manager.

Think of `/usr` as the Linux equivalent of `C:\Program Files` and `C:\Windows\System32` combined.

```text
 /usr/
 ├── bin/       ── Executable user commands
 ├── sbin/      ── Executable administrative commands
 ├── lib/       ── 32-bit architecture libraries and shared modules
 ├── lib64/     ── 64-bit architecture shared libraries (.so files)
 ├── include/   ── C/C++ header files used for compiling source code
 ├── local/     ── Programs compiled and installed manually by the local admin
 └── share/     ── Architecture-independent assets (icons, fonts, man pages)
```

---

## 3. Everyday Commands vs. Admin Tools: `/bin` vs. `/sbin`

Executable program files in Linux are referred to as **binaries**. These are divided into two main categories based on who is intended to run them.

### A. `/bin` (Everyday User Binaries)
Contains the essential terminal utilities and shell commands that all regular, unprivileged users need to work:

```bash
abdullah@fedora:~$ ls /bin | head -n 8
bash
cat
chmod
cp
date
echo
grep
ls
```

- These are the fundamental tools of the operating system.
- Modern Linux links `/bin` directly to `/usr/bin`.

### B. `/sbin` (System / Superuser Binaries)
The extra **`s`** stands for **System** or **Superuser**. This folder houses binaries specifically designed for system maintenance, booting, disk partitioning, network configuration, and hardware repair:

```bash
abdullah@fedora:~$ ls /sbin | head -n 8
fdisk
fsck
groupadd
iptables
reboot
sysctl
useradd
visudo
```

- These commands alter core system behavior or manage user identity.
- Regular users cannot run them directly without elevated privileges via `sudo`.
- Modern Linux links `/sbin` directly to `/usr/sbin`.

---

## 4. Shared Code Modules: `/lib` and `/lib64`

Just like Windows applications rely on `.dll` (Dynamic Link Library) files, Linux programs depend on **shared library files** bearing the extension **`.so`** (Shared Object).

```bash
abdullah@fedora:~$ ls /lib64/*.so* | head -n 6
/lib64/ld-linux-x86-64.so.2
/lib64/libc.so.6
/lib64/libcrypto.so.3
/lib64/libm.so.6
/lib64/libpthread.so.0
/lib64/libssl.so.3
```

- **`/lib`**: Contains 32-bit libraries (or 64-bit symlinks depending on architecture).
- **`/lib64`**: Contains 64-bit libraries required for modern processors.
- When an executable like `/bin/ls` starts, the dynamic linker loads the shared math and C libraries from `/lib64` into memory so the binary can run without packaging its own separate copy of the code.

---

## 5. Third-Party Standalone Apps: `/opt`

**`/opt`** stands for **Optional**. It is reserved for third-party, proprietary, or self-contained applications that do not follow standard distribution packaging structures.

### Standard Package Manager vs. `/opt`:
- **Standard Linux App (e.g., via `dnf` or `apt`):** Files are scattered across system folders according to standard rules:
    - Binary $\rightarrow$ `/usr/bin/`
    - Libraries $\rightarrow$ `/usr/lib64/`
    - Configuration $\rightarrow$ `/etc/`
- **Standalone `/opt` App (e.g., Google Chrome, JetBrains IDEs):** The entire application bundles its own dedicated private folder containing its own binaries, dependencies, and assets all in one spot:
    - `/opt/google/chrome/`
    - `/opt/JetBrains/Rider/`

This design makes uninstalling third-party suites trivial: removing the single folder under `/opt` purges the entire software package cleanly without touching system libraries.

---

## 6. Summary Reference

```text
┌───────────────────────────────┬────────────────────────────────────────────────────────┐
│ Directory                     │ Role in the System                                     │
├───────────────────────────────┼────────────────────────────────────────────────────────┤
│ /usr                          │ Main container for distribution-managed OS software.   │
│ /bin (symlink to /usr/bin)    │ Everyday commands used by all standard accounts.       │
│ /sbin (symlink to /usr/sbin)  │ Administrative commands requiring superuser rights.    │
│ /lib64 (symlink to /usr/lib64)│ Shared object libraries (.so) required by binaries.    │
│ /opt                          │ Standalone directory for third-party, monolithic apps. │
└───────────────────────────────┴────────────────────────────────────────────────────────┘
```

---

## Key Takeaways

- **The Software Hub (`/usr`):** The primary repository for all package-manager installed system programs, libraries, and assets.
- **Target Audience Distinction:** `/bin` provides everyday tools for general users, while `/sbin` holds maintenance and partition utilities intended for root administration.
- **Shared Code (`/lib64`):** Stores dynamic shared objects (`.so`) loaded at runtime to avoid code duplication across executables.
- **Monolithic Bundles (`/opt`):** Keeps third-party external applications completely isolated within their own single directory rather than scattering them into system folders.