 Big O Notation:
 A way to describe how many steps an algorithm takes as input size (n) grows.
 It doesn’t care and describe exact time, it just gives the relation of time and data when data gets larger.

	 ex: if i increase one student in my algorithm, it will take the program 1 extra sec, adding one more student will take the same 1 sec.
		 in worse algorith, adding one more student will take 10 secs, adding another will take 20 sec, third will take 30 secs.
		other worse algorith will take 1 sec, adding another student will take 1000 sec, adding one more will take 1000000 secs.

	 so the big O, is a tool to describe this relationship of input size and the time it will take, it describes the change of time(growth rate), not the exact time in seconds or else.


	 Big O tells us about the Efficiency of Algorithm.

 ------------------------
 Main Types:
 ------------------------

 O(1) → Constant Time
 Always takes the same number of steps, no matter how big n is.
 Example: Accessing arr[5] → you jump directly to the element in one step.

 O(log n) → Logarithmic Time
 Steps grow slowly as n increases (because you keep cutting the problem in half).
 Example: Binary Search → you check the middle, then half, then half again.
 Idea: even with 1,000,000 items, you find the answer in about 20 steps.

 O(n) → Linear Time
 Steps grow directly with n. If n doubles, steps double.
 Example: Linear Search → check every element one by one until you find it.

 O(n log n) → Linearithmic Time
 A bit slower than O(n), faster than O(n^2).
 Example: Merge Sort → split the list (log n times) and process all n elements.
 Idea: good balance, used by most efficient sorting algorithms.

 O(n^2) → Quadratic Time
 Steps grow with the square of n. If n doubles, steps become 4x.
 Example: Nested loops → compare every element with every other element.
 Idea: fine for small n, but terrible when n is large.

 ------------------------
 Higher (worse) complexities:
 ------------------------

 O(n^3) → Triple nested loops, like checking all triplets of items.
 O(2^n) → Exponential, like brute force recursion (e.g., Fibonacci naive).
 O(n!)  → Factorial, like generating all possible permutations.
 These blow up super fast and are usually impossible for big n.


	 //see the pdf file