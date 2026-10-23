# Shell Variables and Parameter Expansion

In the previous lesson, we saw how the `$` symbol acts as the universal trigger for substitution. In this lesson, we explore **Shell Variables** and **Parameter Expansion**—the mechanism used to store temporary values in the shell's memory and retrieve them anywhere on the command line.

---

## 1. Defining and Expanding Variables

A variable is a named storage slot allocated inside the memory space of your current shell process.

### Rules for Assigning Variables:
* Syntax: `NAME=value`
* **Critical Rule:** There must be **NO spaces** around the `=` sign.
    * `var2=test` (Valid assignment)
    * `var2 = test` (Fails: the shell treats `var2` as a command to execute and `=` as an argument)

### Inspecting the Value:
To retrieve what is stored inside a variable, prefix its name with the `$` expansion operator:

```bash
var2=test
echo $var2
```
Output:
```text
test
```

---

## 2. Parameter Expansion Syntax: `$var` vs. `${var}`

You can retrieve a variable using two notations:
1. Short notation: `$var1`
2. Explicit notation (with curly braces): `${var1}`

```bash
echo $var1
echo ${var1}
```
Both commands produce the exact same output:
```text
10
10
```

### Why Do Curly Braces Matter?
Braces explicitly delimit the variable name from adjacent text. Without braces, the shell cannot determine where the variable name ends:

* `echo "$var1_file"` $\rightarrow$ The shell looks for a nonexistent variable named `var1_file` and prints nothing.
* `echo "${var1}_file"` $\rightarrow$ The shell cleanly extracts `var1` (`10`) and outputs `10_file`.

---

## 3. Handling Unset Variables and Fallback Values

What happens when you expand a variable that does not exist?

```bash
echo $var3
```
Output:
```text

```
By default, the shell prints a blank line (it substitutes an unset variable with an empty string).

### Providing a Default Fallback (`${VAR-default}`)
Parameter expansion allows you to define a fallback string if the variable is unset, using the dash (`-`) syntax:

```bash
echo ${var3-unset}
```
Output:
```text
unset
```

```bash
echo ${var3-novariable}
```
Output:
```text
novariable
```

If `var3` is not defined in memory, the shell substitutes the text following the hyphen instead of leaving an empty space.

---

## 4. Assigning Calculations and Command Output

Variables can store not just static words, but the results of other substitutions.

### A. Arithmetic into a Variable: Modern `$((...))` vs. Legacy `$[...]`
In bash, you can store calculations into variables:

```bash
var3=$[1 + 2]
echo $var3
```
Output:
```text
3
```

> **Note on Syntax:**  
> The `$[1 + 2]` syntax is an older, deprecated form of arithmetic expansion. Modern POSIX shells and standard Bash prefer `$((1 + 2))` because it conforms to official standards, though you will still encounter `$[...]` in legacy scripts.

---

### B. Command Substitution into a Variable: `$(command)`
You can execute any terminal command, capture its stdout stream, and lock it into a variable using **Command Substitution** (`$(...)`):

```bash
var4=$(date)
```

Now inspect the value:
```bash
echo $var4
echo $var4
echo $var4
```
Output:
```text
Wed Mar 13 11:30:41 PM CDT 2024
Wed Mar 13 11:30:41 PM CDT 2024
Wed Mar 13 11:30:41 PM CDT 2024
```

### Key Observation: Static vs. Dynamic
Notice that printing `$var4` three consecutive times outputs the exact same timestamp.
* The `date` binary executed **once** at the moment the variable was created.
* Its printed output was converted into a static string and stored in RAM.
* Calling `$var4` simply reads that saved string—it does not re-run the `date` command.

---

## 5. Scope: Variables Belong to the Shell Process

The variables defined here (`var1`, `var2`, `var3`, `var4`) are **local shell variables**.

```text
+-------------------------------------------------------------+
| Active Bash Process (PID: 18420)                            |
|                                                             |
|   Private Memory Table:                                     |
|   ┌──────────────────────┬──────────────────────────────┐   |
|   │ var1                 │ 10                           │   |
|   │ var2                 │ test                         │   |
|   │ var4                 │ Wed Mar 13 11:30:41 PM ...   │   |
|   └──────────────────────┴──────────────────────────────┘   |
+-------------------------------------------------------------+
```

They exist strictly inside the current shell process. If you close your terminal window or spawn a child shell, these variables are completely invisible to external programs—setting the stage for our next topic: **Environment Variables and `export`**.

---

## Key Takeaways

* **Assignment:** Use `NAME=value` with strictly **no spaces** around the equals sign.
* **Brace Syntax (`${VAR}`):** Protects the boundary of the variable name from surrounding text.
* **Default Values (`${VAR-default}`):** Prevents blank output by substituting a fallback string when the variable is unset. * **Arithmetic Assignment:** Saves computed numbers into variables (`var=$((1 + 2))` or legacy `var=$[1 + 2]`). * **Command Substitution (`$(...)`):** Freezes the live output of a command into a static string variable at the time of execution.
* **Local Isolation:** Shell variables live only inside the memory of the specific shell session that created them.