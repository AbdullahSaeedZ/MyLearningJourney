/*
   ================================================================================
   BitArray (System.Collections) — Explained for Beginners with Visual Diagrams
   ================================================================================
   
   1. THE PROBLEM (A NORMAL `bool[]` WASTES 7 OUT OF 8 BITS):
   - A `bool` only ever holds TWO possible answers: `true` (1) or `false` (0).
     In computer memory, 1 `true`/`false` answer only needs **1 single bit**.
   - However, CPUs cannot grab 1 bit at a time from RAM—the smallest chunk a CPU 
     reads is **1 byte = 8 bits**.
   - So when you make `bool[] flags = new bool[8]`, C# uses **8 full bytes (64 bits)** 
     to store just 8 answers—leaving **7 bits empty inside every single byte**!
   
     Visual Comparison (Storing 8 `true`/`false` answers: `T, F, T, T, F, F, T, F`):
   
     Normal `bool[8]` (Uses 8 Bytes = 64 bits):
     ┌──────────┬──────────┬──────────┬──────────┬──────────┬──────────┬──────────┬──────────┐
     │ 00000001 │ 00000000 │ 00000001 │ 00000001 │ 00000000 │ 00000000 │ 00000001 │ 00000000 │
     └──────────┴──────────┴──────────┴──────────┴──────────┴──────────┴──────────┴──────────┘
       Byte 0     Byte 1     Byte 2     Byte 3     Byte 4     Byte 5     Byte 6     Byte 7
       (7 wasted bits in EVERY byte!)
   
     `BitArray(8)` (Uses just 1 Byte of actual bit data — 8x smaller!):
     ┌─┬─┬─┬─┬─┬─┬─┬─┐
     │1│0│1│1│0│0│1│0│  ◄── All 8 answers packed tightly side-by-side!
     └─┴─┴─┴─┴─┴─┴─┴─┘
      0 1 2 3 4 5 6 7   (Bit index)
   
   
   2. CORE IDEA (THINK OF AN `int` AS AN EGG CARTON WITH 32 SLOTS):
   - C# has no built-in "bit array" type in hardware, so `BitArray` uses a clever 
     trick: it creates a hidden **`int[]`** array internally.
     
   - Normally, you store a single number in an `int` (like `int x = 5;`). Inside 
     the computer's RAM, that `int` is actually made of **32 tiny switches** 
     (bits), each set to `0` (OFF / `false`) or `1` (ON / `true`).
     
   - So `BitArray` treats 1 `int` = 1 box holding 32 boolean switches**:
   
     1 `int` box = 32 boolean switches:
     ┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐
     │0│0│0│0│0│0│0│0│0│0│0│0│0│0│0│0│0│0│0│0│0│0│0│0│0│0│0│0│0│0│0│0│
     └─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┘
      0 1 2 3 4 5 6 7 8 9 ...                                   30 31
      (32 switches total inside just ONE `int`!)
   
   - How many `int` boxes does `BitArray` allocate?
     * Want to store **10** booleans?  1 box (32 slots) is enough -> `int[]` of length **1**.
     * Want to store **32** booleans?  1 box (32 slots) is full   -> `int[]` of length **1**.
     * Want to store **33** booleans?  1 box isn't enough! You need a 2nd box -> `int[]` of length **2**.
     * Want to store **64** booleans?  2 boxes × 32 slots = 64   -> `int[]` of length **2**.
     * Want to store **65** booleans?  Need a 3rd box            -> `int[]` of length **3**.
   
     Visualizing `new BitArray(65)` (3 `int` boxes created behind the scenes):
     Box 0 (`int[0]`)               Box 1 (`int[1]`)               Box 2 (`int[2]`)
     ┌─────────────────────────┐    ┌─────────────────────────┐    ┌─────────────────────────┐
     │ Holds booleans 0 to 31  │    │ Holds booleans 32 to 63 │    │ Holds boolean 64        │
     │ (32 switches)           │    │ (32 switches)           │    │ (1 used, 31 unused)     │
     └─────────────────────────┘    └─────────────────────────┘    └─────────────────────────┘
   
   
   3. HOW `bits[35] = true` FINDS SWITCH #35 (STEP-BY-STEP):
   - `BitArray` has NO variable named `bit35`—it only has `int[0]`, `int[1]`, and `int[2]`.
   - When you write `bits[35] = true;`, it answers two simple questions to find 
     where index `35` lives:
   
     Question A: **Which `int` box is #35 inside?** (Divide by 32)
     - Box 0 holds `0..31` (the first 32 items).
     - Box 1 holds `32..63` (the next 32 items).
     - Math: `35 / 32 = 1` (integer division drops the remainder).
     - Answer: Go to **Box 1 (`int[1]`)**!
   
     Question B: **Where inside Box 1 is #35?** (Remainder `% 32`)
     - Box 1 starts counting at index `32`:
         * Slot `0` of Box 1 = `bits[32]`
         * Slot `1` of Box 1 = `bits[33]`
         * Slot `2` of Box 1 = `bits[34]`
         * Slot `3` of Box 1 = `bits[35]`  <-- HERE!
     - Math: `35 % 32 = 3` (how many steps past 32 we are).
     - Answer: Flip **Slot #3** inside `int[1]` from `0` to `1`!
   
     Visualizing the exact result in RAM:
     Box 0 (`int[0]`)                        Box 1 (`int[1]`)
     [ 0, 1, 2, ..., 31 ]                    Slot:   0    1    2    3    4  ...  31
     ┌──────────────────┐                    Bit #:  32   33   34   35   36 ...  63
     │ all 0s           │                    ┌─────┬────┬────┬────┬────┬───────┐
     └──────────────────┘                    │  0  │ 0  │ 0  │ 1  │ 0  │  ...  │
                                             └─────┴────┴────┴─▲──┴────┴───────┘
                                                               │
                                                      `bits[35] = true` flips this!
   
   
   4. BONUS SUPERPOWER (BULK OPERATIONS & RESIZING):
   - **32x Faster Bulk Bitwise Logic:** Because 32 switches sit inside one `int`, 
     calling `bitsA.And(bitsB)`, `bitsA.Or(bitsB)`, `bitsA.Xor(bitsB)`, or 
     `bitsA.Not()` compares **32 flags at the exact same time** in one CPU step 
     instead of looping 32 times.
     
   - **Dynamic Length:** Unlike normal arrays (`T[]`), you can change a `BitArray`'s 
     size anytime using `bits.Length = 100;`.
     
   - **When to Use vs. Avoid:** Use for large dense flag tables (Bloom filters, 
     prime sieves, seat/slot availability maps, permission masks); avoid for small 
     flag counts where `bool[]`, `List<bool>`, or a `[Flags] enum` is simpler.
   ================================================================================
   */