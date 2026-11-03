# Hardware, Disks, and Storage

Linux treats hardware devices and storage drives as if they were simple files so programs can interact with them easily. This lesson covers how physical hardware is represented in the terminal, where startup files reside, and how storage drives are attached to the system.

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
├── 4. Hardware, Disks, and Storage (Attached Drives) ─────────┐
│   ├── /dev          ── Device files representing hardware    │
│   ├── /boot         ── Startup files, Linux kernel, boot menu│ ] ── [CURRENT LESSON]
│   ├── /mnt          ── Manual mount point for storage drives │
│   └── /media        ── Automatic mount point for USBs/cards ─┘
│
└── 5. Virtual Kernel Interfaces (Live System Diagnostics)
    ├── /proc         ── Live view of running processes and CPU/RAM status (in-memory)
    └── /sys          ── Live view of hardware devices and kernel drivers (in-memory)
```

---

## 2. Hardware Representation: `/dev`

**`/dev`** stands for **Devices**.

Under the Linux philosophy of *"everything is a file"*, your computer hardware is represented as special files inside `/dev`. Instead of talking directly to raw hardware chips, Linux lets programs read from or write to these file paths.

### 1. Storage Disks & Partitions
Whenever you plug in a drive, Linux assigns it a file name here:
- **`/dev/sda`:** Your first SATA hard disk or SATA SSD.
- **`/dev/sda1`:** The first partition on that first drive.
- **`/dev/nvme0n1`:** A modern high-speed M.2 NVMe SSD.

### 2. Useful "Special" Devices
Linux also provides virtual helper devices in `/dev`:
- **`/dev/null` (The Trash Can):** Any output you send here disappears completely (`command > /dev/null`). Use it to silence unwanted terminal messages.
- **`/dev/urandom` (Random Generator):** Produces endless random data used for creating secure passwords and encryption keys.

---

## 3. Starting the Machine: `/boot`

The **`/boot`** directory contains the startup files needed to turn on your computer and load the Linux operating system into memory.

```bash
abdullah@fedora:~$ ls /boot
config-6.11.4-200.fc41.x86_64
efi
grub2
initramfs-6.11.4-200.fc41.x86_64.img
vmlinuz-6.11.4-200.fc41.x86_64
```

### Key Components of `/boot`:
1. **`vmlinuz-*`:** The actual compiled **Linux kernel**. This is the core engine of the operating system that loads into RAM when the computer powers on.
2. **`initramfs-*`:** A small temporary helper loaded into memory during startup. It contains basic disk drivers so the kernel can find and unlock your main storage partition (`/`).
3. **`grub2/` or `efi/`:** The bootloader files that show the startup menu where you pick which operating system or kernel to boot.

---

## 4. Mounting Storage Drives: `/mnt` vs. `/media`

When you want to access files on an external disk, USB drive, or secondary hard drive, it must be attached (mounted) to an empty directory. Linux provides two standard locations depending on who mounts it:

```text
┌──────────────┬────────────────────────┬──────────────────────┬────────────────────────────────────┐
│ Directory    │ Mount Type             │ Managed By           │ Typical Administrative Use         │
├──────────────┼────────────────────────┼──────────────────────┼────────────────────────────────────┤
│ /mnt         │ Manual mount point     │ System Administrator │ Manually attaching a backup drive  │
│              │                        │                      │ or secondary hard disk in terminal.│
├──────────────┼────────────────────────┼──────────────────────┼────────────────────────────────────┤
│ /media       │ Automatic mount point  │ Desktop Environment  │ Plugging in a USB flash drive or   │
│              │                        │ (System GUI)         │ SD card via graphical desktop.     │
└──────────────┴────────────────────────┴──────────────────────┴────────────────────────────────────┘
```

### A. Manual Administration: `/mnt`
When you manually connect a partition using the terminal, you mount it to `/mnt`:

```bash
# Administrator manually attaches a partition:
abdullah@fedora:~$ sudo mount /dev/sdb1 /mnt
```

### B. Desktop Removable Media: `/media` (or `/run/media/$USER/`)
When you plug a USB thumb drive into your computer while logged into a desktop environment, the system detects it and mounts it automatically under `/media` (or `/run/media/abdullah/<DriveName>`):

```bash
# Automatically mounted when plugged in:
abdullah@fedora:~$ ls /run/media/abdullah/
My_USB_Drive
```

When you safely eject or unplug the drive, the system removes that folder automatically.

---

## 5. Summary Reference

```text
┌──────────────────────────────┬────────────────────────────────────────────────────────┐
│ Directory                    │ Role in the System                                     │
├──────────────────────────────┼────────────────────────────────────────────────────────┤
│ /dev                         │ Files representing hardware drives, partitions, & tools│
│ /boot                        │ Linux kernel (vmlinuz), bootloader, and startup files. │
│ /mnt                         │ Manual temporary mount point used by administrators.   │
│ /media                       │ Automatic mount directory for plugged-in USB drives.   │
└──────────────────────────────┴────────────────────────────────────────────────────────┘
```

---

## Key Takeaways

- **Hardware as Files (`/dev`):** Storage disks (`sda`, `nvme0n1`) and special tools (`null`, `urandom`) are accessed as regular file paths.
- **Operating System Core (`/boot`):** Stores the bootloader menu, the Linux kernel (`vmlinuz`), and startup drivers needed to power on the PC.
- **Where Disks Attach:** Use `/mnt` for manual mounts you attach yourself in the terminal; check `/media` (or `/run/media/$USER`) for USB flash drives plugged into a desktop interface.