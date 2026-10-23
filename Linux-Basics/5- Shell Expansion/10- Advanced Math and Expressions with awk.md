# Advanced Math and Expressions with `awk`

Bash's native arithmetic expansion (`$(( ... ))`) is strictly limited to integers. When your scripts need decimal calculations, floating-point precision, or condition checks without installing extra packages, **`awk`** is the universal tool.

---

## 1. Why `awk`?

* **Always Installed:** Available out of the box on every Linux distribution (Fedora, Debian, RHEL, Ubuntu, Alpine) and minimal Docker container.
* **No Dependencies:** Unlike `bc`, which is often missing on minimal installations, `awk` is a POSIX standard utility.
* **Decimal Support:** Evaluates floating-point numbers natively without truncating remainders.

---

## 2. Running Inline Expressions: The Two Syntaxes

`awk` expects an input stream by default. You can run one-off math expressions using either of two compact patterns:

### Pattern A: Using `BEGIN` (Self-Contained)
Runs immediately without reading any input data:

```bash
abdullah@fedora:~$ awk 'BEGIN { print 10 / 3 }'
3.33333
```

### Pattern B: The Short Syntax (Using `<<< ""`)
Feeds a blank string directly to `awk`, executing the action block immediately:

```bash
abdullah@fedora:~$ awk '{ print 10 / 3 }' <<< ""
3.33333
```

Both patterns produce the exact same result.

---

## 3. Precision Formatting with `printf`

To control the number of decimal places displayed, swap `print` for standard C-style `printf`:

```bash
abdullah@fedora:~$ awk 'BEGIN { printf "%.2f\n", 10 / 3 }'
3.33
```

---

## 4. Comparison Expressions

`awk` evaluates comparison statements directly. A true condition evaluates to **`1`**, and a false condition evaluates to **`0`**.

### Comparison Operators:
| Operator | Meaning | Example | Result |
| :--- | :--- | :--- | :--- |
| `>` | Greater than | `awk 'BEGIN { print (10.5 > 5.2) }'` | `1` |
| `<` | Less than | `awk 'BEGIN { print (10.5 < 5.2) }'` | `0` |
| `>=` | Greater than or equal to | `awk 'BEGIN { print (5.0 >= 5.0) }'` | `1` |
| `<=` | Less than or equal to | `awk 'BEGIN { print (3.2 <= 1.8) }'` | `0` |
| `==` | Equal to | `awk 'BEGIN { print (4.5 == 4.5) }'` | `1` |
| `!=` | Not equal to | `awk 'BEGIN { print (4.5 != 2.1) }'` | `1` |

### Logical Operators (`&&`, `||`):
```bash
abdullah@fedora:~$ awk 'BEGIN { print (10 > 5 && 3.5 < 4.0) }'
1

abdullah@fedora:~$ awk 'BEGIN { print (10 > 20 || 5 == 5) }'
1
```

---

## 5. Returning Custom Text with the Ternary Operator

Instead of displaying raw `1` or `0`, use the ternary operator (`condition ? true_val : false_val`) to return concise text:

```bash
abdullah@fedora:~$ awk 'BEGIN { print (10.5 > 5.2 ? "PASS" : "FAIL") }'
PASS
```

```bash
abdullah@fedora:~$ awk '{ print (9.8 >= 10.0 ? "VALID" : "INVALID") }' <<< ""
INVALID
```

---

## 6. Saving `awk` Output into Bash Variables

Use command substitution (`$(...)`) to store the computed value directly inside a shell variable:

```bash
abdullah@fedora:~$ result=$(awk 'BEGIN { printf "%.2f", 100 / 3 }')
abdullah@fedora:~$ echo $result
33.33
```

---

## Key Takeaways

* **Decimal Handling:** `awk` natively processes floating-point math where Bash `$(( ... ))` cannot. * **The Short Syntax:** Use `awk '{ print ... }' <<< ""` or `awk 'BEGIN { print ... }'` to run math without a file. * **Comparison Truth Values:** Conditions resolve directly to `1` (true) or `0` (false). * **Ternary Operator:** Format comparison outcomes cleanly using `condition ? "val1" : "val2"`. * **Variable Storage:** Capture calculations into Bash variables using standard `$(awk ...)`.