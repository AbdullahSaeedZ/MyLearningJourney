# The $ Symbol for Substitution (Arithmetic and Value Expansion)

In the previous lesson, we saw how the shell expands wildcard patterns (`*`, `?`, `[...]`) into filenames on disk. In this lesson, we introduce the most versatile character in the shell: the **`$`** symbol, the universal gateway to **Substitution**.

---

## 1. The Role of the `$` Symbol in the Shell

Normally, every character you type into a shell prompt is treated as literal text. The dollar sign (`$`) is a special trigger character known as the **substitution / expansion operator**.

When the shell encounters a `$`, it alters how it reads the subsequent token:
* **Without `$`:* The shell treats the characters literally as raw text strings.
* **With `$`:* The shell pauses, looks up or computes a value in memory, and **substitutes** that entire syntax block with the resulting data before the command line runs.

### The Three Forms of `$` Substitution:
```text
Syntax             Mechanism               Action
────────────────────────────────────────────────────────────────────────────────
$(( expression ))  Arithmetic Expansion     Calculates math and substitutes the result
$VAR or ${VAR}     Parameter Expansion      Retrieves the stored value of a variable
$( command )       Command Substitution     Runs a program and substitutes its output
```

In this lesson, we focus on the first practical application of `$`: **Arithmetic Expansion**.

---

## 2. Arithmetic Expansion: `$(( expression ))`

The double-parentheses pattern `$(( ... ))` tells the shell: *"Evaluate the mathematical expression inside, and substitute this whole block with the resulting number."*

Arithmetic substitution happens entirely in memory inside the shell process itself. It requires no disk reads and spawns no external programs.

```text
+-------------------------------------------------------------------------+
| STEP 1: USER INPUT                                                      |
| User types:               echo $(( 10 + 5 ))                            |
+-------------------------------------------------------------------------+
                                      │
                                      ▼
+-------------------------------------------------------------------------+
| STEP 2: SHELL EVALUATION & SUBSTITUTION                                 |
| The shell identifies:     $(( 10 + 5 ))                                 |
| Computes math in RAM:     10 + 5 = 15                                   |
| Substitutes the block:    echo 15                                       |
+-------------------------------------------------------------------------+
                                      │
                                      ▼
+-------------------------------------------------------------------------+
| STEP 3: COMMAND EXECUTION                                               |
| "echo" receives argument: "15"                                          |
| Prints output:            15                                            |
+-------------------------------------------------------------------------+
```

The command (`echo`) never sees the math formula. It receives only the final substituted string (`15`).

---

## 3. Supported Arithmetic Operators

Inside `$(( ... ))`, bash supports standard integer mathematical operators:

| Operator | Purpose | Example | Evaluates To |
| :--- | :--- | :--- | :--- |
| `+` | Addition | `echo $(( 7 + 3 ))` | `10` |
| `-` | Subtraction | `echo $(( 10 - 4 ))` | `6` |
| `*` | Multiplication | `echo $(( 6 * 7 ))` | `42` |
| `/` | Division (Integer only) | `echo $(( 20 / 3 ))` | `6` |
| `%` | Modulo (Remainder) | `echo $(( 20 % 3 ))` | `2` |
| `**` | Exponentiation (Power) | `echo $(( 2 ** 8 ))` | `256` |

Spaces inside `$(( ... ))` are cosmetic and ignored by the shell parser: `$((5+5))` and `$(( 5 + 5 ))` are identical.

---

## 4. The Integer Rule (No Decimals)

Bash arithmetic expansion handles **integers only**. It does not compute floating-point (decimal) values:

```bash
echo $(( 5 / 2 ))
```

Output:
```text
2
```

The shell drops (truncates) the decimal part rather than rounding up to `2.5`. If decimal arithmetic is required in a script, input must be piped to external calculation tools like `bc` or `awk`.

---

## 5. Grouping and Order of Precedence

Standard algebraic order of operations applies: multiplication and division take priority over addition and subtraction. Grouping operations with regular parentheses controls execution order:

```bash
echo $(( (5 + 3) * 2 ))
```

Output:
```text
16
```

---

## Key Takeaways

* **The `$` Symbol:** The shell's universal substitution operator. It instructs the shell to calculate or fetch data in memory rather than treating characters literally. * **Substitution Family:** `$((...))` handles math, `$VAR` retrieves stored variables, and `$(...)` captures command output.
* **Arithmetic Expansion:** Evaluated natively in memory by the shell before the command executes.
* **Integer Truncation:** Arithmetic expansion only produces integers; decimal remainders are discarded.