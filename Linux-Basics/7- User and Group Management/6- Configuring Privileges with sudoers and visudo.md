# Configuring Privileges with sudoers and visudo

The `sudo` utility does not make arbitrary decisions about who can elevate privileges. Every authorization rule, group permission, and command restriction is centrally governed by the configuration file **`/etc/sudoers`**.

---

## 1. Where Does `sudo` Get Its Authority?

When a user prefixes a command with `sudo`, the operating system consults a single configuration file: **`/etc/sudoers`**.

```text
 ┌────────────────────────────────────────────────────────┐
 │                      User runs:                        │
 │               sudo systemctl restart sshd              │
 └──────────────────────────┬─────────────────────────────┘
                            │
                            ▼
 ┌────────────────────────────────────────────────────────┐
 │ System Checks: /etc/sudoers                            │
 │ Evaluates if calling user has matching permission rule │
 └──────────────────────────┬─────────────────────────────┘
                            │
            Matches Rule? ──┴──> Grants/Denies Execution
```

If the user is not explicitly listed or part of an authorized group inside `/etc/sudoers`, the execution is denied, and the security incident is reported to system logs.

---

## 2. The Golden Rule: Always Use `visudo`

Never edit `/etc/sudoers` directly using standard text editors like `nano` or `vim`.

A single syntax error (such as a missing colon, typo, or stray character) in `/etc/sudoers` can instantly break `sudo` across the entire machine, locking all administrators out of elevated access.

Instead, always edit configuration rules using **`visudo`**:

```bash
abdullah@fedora:~$ sudo visudo
```

### Why `visudo` Is Essential:
1. **Syntax Validation:** When you save and exit, `visudo` parses the file. If you made a syntax error, it warns you and refuses to apply the changes until corrected.
2. **File Locking:** It applies a lock to prevent concurrent administrative edits from corrupting the file.

---

## 3. Deconstructing the `sudoers` Rule Syntax

Inside `/etc/sudoers`, privilege rules follow a standardized four-part structure:

```text
 abdullah    ALL = (ALL)    ALL
 ────────    ───    ────    ───
    1         2       3      4
```

```text
┌───────┬────────────────────┬──────────────────────────────────────────────────────────┐
│ Field │ Segment            │ Meaning                                                  │
├───────┼────────────────────┼──────────────────────────────────────────────────────────┤
│ 1     │ User or Group      │ Who the rule applies to (Groups are prefixed with '%').  │
│ 2     │ Host Specification │ Which machines this applies to ('ALL' on local systems). │
│ 3     │ Target Identity    │ Which user(s) they can run commands as ('(ALL)' = root). │
│ 4     │ Command List       │ Which commands are allowed ('ALL' or specific paths).    │
└───────┴────────────────────┴──────────────────────────────────────────────────────────┘
```

### A. Limiting Scope to Specific Commands
Instead of granting unconditional access (`ALL`), an administrator can restrict an account to specific binaries:

```text
# Allows sara to ONLY restart the web server, nothing else:
sara    ALL=(root)    /usr/bin/systemctl restart nginx
```

### B. Applying Rules to Entire Groups (`%`)
Instead of defining permissions user-by-user, you can target an entire group of users at once by prefixing the identifier with a percent sign (**`%`**):

```text
# Any user who belongs to the 'webadmins' group inherits this permission:
%webadmins    ALL=(root)    /usr/bin/systemctl restart nginx
```

This simplifies administration: to grant or revoke privileges, you manage membership in that group rather than editing `/etc/sudoers` every time team members change.

---

## 4. Summary Reference

```text
┌─────────────────────────┬─────────────────────────────────────────────────────────────┐
│ Target / Utility        │ Core Purpose                                                │
├─────────────────────────┼─────────────────────────────────────────────────────────────┤
│ /etc/sudoers            │ Central rule file defining sudo privileges and policies.    │
│ visudo                  │ Safe editor with built-in syntax checker to prevent lockouts│
│ %<group_name>           │ Prefix syntax used to assign rules to a group of users.     │
└─────────────────────────┴─────────────────────────────────────────────────────────────┘
```

---

## Key Takeaways

- **Central Authority:** All `sudo` rights are controlled exclusively via `/etc/sudoers`.
- **Syntax Safety with `visudo`:** Never edit `/etc/sudoers` directly; `visudo` checks for syntax errors before saving to prevent irreversible system lockouts.
- **Rule Syntax:** Follows `Who Where=(As_Whom) What` (e.g., `user ALL=(ALL) ALL`).
- **Group Prefix (`%`):** Prefacing an identifier with `%` applies the rule to all members of that group simultaneously, avoiding the need to manage individual accounts.