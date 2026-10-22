# History of Terminals and Mainframes

In the early days of computing, a single computer filled an entire room. Understanding that setup explains why modern Linux still splits typing commands from running them.

---

## 1. The Story: Mainframes and Physical Terminals

Decades ago, computers were called **Mainframes**. They were massive, extremely expensive, and housed all the processing power, storage, and memory.

A company or university could not buy a computer for every worker, so multiple people shared the same central machine.

```text
       +--------------------+
       |   PHYSICAL TTY     |
       |   (Terminal)       |
       |                    |
       |    +----------+    |
       |    |  Screen  |    |
       |    +----------+    |
       |    [ Keyboard ]    |
       +---------+----------+
                 |
                 | (Physical Cable)
                 v
       +--------------------+
       |     MAINFRAME      |
       |                    |
       |  [CPU / Memory]    |
       +--------------------+
```

To let people use the mainframe, they placed standalone stations on desks called **Terminals** (or **TTY**, short for *Teletypewriter*).

* The terminal was just a keyboard and a screen.
* It had no CPU, no memory, and ran no operating system.
* Its entire job was simple: you press a key on the keyboard, the terminal sends that character down a wire to the mainframe, and when the mainframe replies, the terminal draws the text on the screen.

---

## 2. How a Command Traveled: Step by Step

Once your keystrokes reached the mainframe, the machine processed them through a chain of components:

```text
+----------+          +----------+          +----------+          +----------+
|          |          |          |          |          |          |          |
|   TTY    | =======> |  SHELL   | =======> |  KERNEL  | =======> |   H/W    |
|          |          |          |          |          |          |          |
+----------+          +----------+          +----------+          +----------+
```

Here is the exact journey of a command:

1. **The TTY captures your input:** You sit at the desk, type `date`, and hit Enter. The TTY transmits those raw text characters down the cable.
2. **The Shell receives the text:** Inside the mainframe, a program called the **Shell** receives the text `date`. It translates your human-readable command into instructions the system can process.
3. **The Kernel handles execution:** The shell hands those instructions over to the **Kernel** (the core manager of the operating system).
4. **The Hardware performs the work:** The kernel instructs the **H/W (Hardware)**—the CPU and memory—to run the task and retrieve the system time.

Once finished, the result traveled all the way back: Hardware $\rightarrow$ Kernel $\rightarrow$ Shell $\rightarrow$ TTY, where the terminal simply printed the answer on your screen.

---

## 3. Why This Still Matters

Even though today your screen, keyboard, and CPU all sit inside the same laptop or desktop case, Linux never threw away this four-part communication model:

* Your terminal window still acts as the **TTY** (taking input and drawing text).
* The prompt waiting inside that window is the **Shell** (reading and interpreting your commands).
* The operating system underneath remains the **Kernel** talking to your physical **Hardware**.

---

## Key Takeaways

* **Mainframe:** The central computer that did all the actual work.
* **TTY (Terminal):** The physical screen and keyboard used to send text into the mainframe.
* **The Communication Chain:**
  $$\text{TTY (Keystroke)} \longrightarrow \text{Shell (Translates)} \longrightarrow \text{Kernel (Directs)} \longrightarrow \text{H/W (Executes)}$$