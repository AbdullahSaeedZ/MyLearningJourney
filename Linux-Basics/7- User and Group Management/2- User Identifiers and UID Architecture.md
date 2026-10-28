# User Identifiers and UID Architecture

While humans interact with Linux using string usernames such as `root` or `abdullah`, the Linux kernel does not track identity using textual names. Instead, the kernel relies entirely on positive integers known as **User Identifiers (UIDs)**.

---

## 1. How the Kernel Tracks Identity

At the kernel layer, process execution rights, file ownership, and resource access are evaluated against numerical values. Textual usernames exist solely as a human-friendly abstraction layer managed in user space.

```text
 User Space (Human View)        Kernel Space (Execution View)
 ┌───────────────────────┐      ┌───────────────────────────┐
 │ Username: abdullah    │ ───> │ UID: 1000                 │
 │ Username: root        │ ───> │ UID: 0                    │
 │ Username: nginx       │ ───> │ UID: 998                  │
 └───────────────────────┘      └─────────────┬─────────────┘
                                              │
                                              ▼
                                 Evaluates File & Process
                                    Permission Checks
```

When you perform an operation, the kernel checks the **UID** attached to the active process structure, not the textual name logged into the shell.

---

## 2. Standard UID Allocation Ranges

Modern Linux distributions (including Fedora, RHEL, Debian, and Ubuntu) divide the integer spectrum of UIDs into standardized blocks:

```text
 0               1                     1000                                60000+
 ┌───────────────┬───────────────────────┬────────────────────────────────────┐
 │  root (UID 0) │ System Accounts (1–999)│ Regular Interactive Users (1000+)   │
 └───────────────┴───────────────────────┴────────────────────────────────────┘
```

### A. The Root Anchor (`UID 0`)
The identifier **`0`** is permanently hardcoded into kernel logic as the superuser.
- The authority of `root` comes from the integer `0`, not the string `"root"`.
- If an account named `admin` is created with UID `0`, the kernel grants it complete superuser privileges identical to `root`.

### B. System / Service Accounts (`UID 1` – `999`)
Reserved for system-level services, background daemons, and system components:
- Modern systems allocate the range **1 through 999** for statically or dynamically created service accounts (e.g., `systemd-resolve`, `sshd`, `polkitd`).
- *Note:* Older distributions (such as CentOS 6 or older Debian releases) traditionally set the regular user boundary at UID `500`. Modern standards have universally shifted this boundary to `1000`.

### C. Regular Interactive Users (`UID 1000`+)
Assigned to real users created on the machine:
- The first non-root human user provisioned during system installation is typically assigned **`UID 1000`**.
- Subsequent user accounts increment sequentially (`1001`, `1002`, and so on).

---

## 3. Inspecting Identity in Practice

Linux provides dedicated utilities to query the active execution context and inspect how usernames map to numerical IDs.

### A. Querying Identity with `id`
The **`id`** command prints the current user's numerical identity, primary group (GID), and supplementary group memberships:

```bash
abdullah@fedora:~$ id
uid=1000(abdullah) gid=1000(abdullah) groups=1000(abdullah),10(wheel)
```

You can also pass a specific username as an argument to inspect other accounts on the system:

```bash
abdullah@fedora:~$ id root
uid=0(root) gid=0(root) groups=0(root)
```

```bash
abdullah@fedora:~$ id systemd-resolve
uid=193(systemd-resolve) gid=193(systemd-resolve) groups=193(systemd-resolve)
```
Notice that `systemd-resolve` falls within the **1–999** system UID bracket.

### B. Querying Active Username with `whoami`
The **`whoami`** command prints only the effective textual username tied to the current shell session:

```bash
abdullah@fedora:~$ whoami
abdullah
```

Running `whoami` is functionally equivalent to running:
```bash
abdullah@fedora:~$ id -un
abdullah
```
*(The `-u` flag selects UID, and `-n` prints the mapped string name instead of the number).*

---

## 4. UID Range Reference Table

```text
┌─────────────────┬───────────────────┬───────────────────────────────────────────────────┐
│ UID Range       │ Account Type      │ Typical Usage                                     │
├─────────────────┼───────────────────┼───────────────────────────────────────────────────┤
│ 0               │ Superuser         │ Root account; hardcoded unrestricted kernel rights│
│ 1 – 999         │ System / Daemon   │ Background services (sshd, nginx, systemd)        │
│ 1000 – 60000    │ Regular Users     │ Interactive human users                           │
│ 65534           │ Special / Nobody  │ Least-privileged NFS/fallback user (`nobody`)     │
└─────────────────┴───────────────────┴───────────────────────────────────────────────────┘
```

---

## Key Takeaways

- **Kernel View vs. User View:** The Linux kernel manages permissions using numerical integer UIDs; human-readable usernames are merely an interface convenience.
- **The Power of Zero:** Superuser authority is tied strictly to **`UID 0`**. Any user account assigned UID `0` possesses root authority regardless of its name.
- **System Tier (1–999):** Reserved for daemons and non-login service accounts to prevent privilege escalation across services.
- **Human Tier (1000+):** The standard starting index for regular interactive user accounts on modern Linux distributions.
- **Identity Queries:** Use `id` to view complete numerical contexts (`uid`, `gid`, groups) and `whoami` to quickly verify the active shell username.