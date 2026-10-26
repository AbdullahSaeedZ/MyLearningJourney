# Translating Characters with tr

The **`tr`** (translate) utility manipulates text at the character level. It can translate (replace), squeeze (deduplicate), or delete specific characters from a text stream.

---

## 1. The Core Rule of `tr`

Unlike most Linux tools, **`tr` does not accept file names as arguments.**

```bash
# This will fail or behave incorrectly:
tr 'a' 'b' /etc/hosts
```

`tr` reads **strictly** from standard input (**`FD 0`**). Because of this architectural rule, `tr` is designed to be fed via **pipes (`|`)** or input redirection (`<`).

```text
 ┌─────────────────────┐
 │ Incoming Process    │
 └──────────┬──────────┘
            │ [FD 1] stdout
            ▼
    ┌───────────────┐
    │  Kernel Pipe  │
    └───────┬───────┘
            │ [FD 0] stdin (REQUIRED)
            ▼
 ┌─────────────────────┐
 │        tr           │ ───> [FD 1: stdout] ───> Display / Next Process
 └─────────────────────┘
```

---

## 2. Translating and Replacing Characters

The default behavior of `tr` maps characters from a source set to a destination set one-to-one:
```bash
tr [source_set] [destination_set]
```

### A. Replacing Single Characters
Map lowercase `i` to uppercase `I`:

```bash
abdullah@fedora:~$ echo "This iss a test 123 !" | tr [i] [I]
ThIs Iss a test 123 !
```
Every `i` in the stream was replaced with `I`.

### B. Changing Case with Character Ranges
Translate all lowercase characters (`a-z`) to uppercase (`A-Z`):

```bash
abdullah@fedora:~$ echo "This iss a test 123 !" | tr [a-z] [A-Z]
THIS ISS A TEST 123 !
```

### C. Replacing All Digits
Replace any numeric digit with the character `z`:

```bash
abdullah@fedora:~$ echo "This iss a test 123 !" | tr [:digit:] 'z'
This iss a test zzz !
```

---

## 3. Deleting Characters with `-d`

The **`-d`** flag instructs `tr` to strip matching characters out of the stream entirely.

### A. Deleting Specific Characters
Remove every occurrence of the letter `s`:

```bash
abdullah@fedora:~$ echo "This iss a test 123 !" | tr -d 's'
Thi i a tet 123 !
```

### B. Deleting Entire Character Classes
Remove all numbers from the text stream using the `[:digit:]` class:

```bash
abdullah@fedora:~$ echo "This iss a test 123 !" | tr -d [:digit:]
This iss a test  !
```

---

## 4. Squeezing Repeated Characters with `-s`

The **`-s`** (squeeze) flag replaces consecutive duplicate instances of a character with a single occurrence.

Reduce repeated `s` characters down to one:

```bash
abdullah@fedora:~$ echo "This iss a test 123 !" | tr -s 's'
This is a test 123 !
```
The double `ss` in `"iss"` was squeezed into a single `s`.

---

## 5. Streaming Files into `tr`

Since `tr` cannot take a file argument directly, use `cat` to stream file contents into `tr` over a pipe:

Convert the entire contents of `/etc/hosts` into uppercase using POSIX character classes:

```bash
abdullah@fedora:~$ cat /etc/hosts | tr [:lower:] [:upper:]
127.0.0.1 LOCALHOST
127.0.1.1 FEDORA

# THE FOLLOWING LINES ARE DESIRABLE FOR IPV6 CAPABLE HOSTS
::1       IP6-LOCALHOST IP6-LOOPBACK
FE00::0   IP6-LOCALNET
FF00::0   IP6-MCASTPREFIX
FF02::1   IP6-ALLNODES
FF02::2   IP6-ALLROUTERS
```

---

## 6. Common Character Classes Reference

Instead of writing manual ranges, `tr` provides standard bracketed classes:

```text
┌──────────────┬────────────────────────────────────────────────────────┐
│ Class        │ Matches                                                │
├──────────────┼────────────────────────────────────────────────────────┤
│ [:lower:]    │ All lowercase letters (equivalent to a-z)              │
│ [:upper:]    │ All uppercase letters (equivalent to A-Z)              │
│ [:digit:]    │ All numbers 0 through 9                                │
│ [:alpha:]    │ All alphabetic characters (both lower and upper)       │
│ [:space:]    │ Whitespace characters (spaces, tabs, newlines)         │
└──────────────┴────────────────────────────────────────────────────────┘
```

---

## Key Takeaways

- **Strictly Reads `stdin`:** `tr` cannot open files directly; it always operates on an incoming stream from a pipe (`|`) or redirection (`<`).
- **Basic Translation:** Maps characters from the first set directly into the corresponding positions of the second set.
- **`-d` (Delete):** Strips all occurrences of the specified characters from the output stream.
- **`-s` (Squeeze):** Deduplicates repeated consecutive characters into a single character.
- **POSIX Classes:** Supports standardized sets like `[:lower:]`, `[:upper:]`, and `[:digit:]`.