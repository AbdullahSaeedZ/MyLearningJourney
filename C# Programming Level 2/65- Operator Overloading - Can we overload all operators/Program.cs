/*
================================================================================
 C# OPERATOR OVERLOADING REFERENCE GUIDE (COMPREHENSIVE)
================================================================================

 1. OPERATORS THAT CAN BE OVERLOADED
 -------------------------------------------------------------------------------
 * Unary Operators            :  +  ,  -  ,  !  ,  ~  ,  ++  ,  --  ,  true  ,  false
 * Binary Operators           :  +  ,  -  ,  * ,  /  ,  %  ,  &  ,  |  ,  ^  ,  <<  ,  >>  ,  >>>
 * Comparison Operators       :  == ,  != ,  <  ,  >  ,  <= ,  >=  (Must be paired)


 2. OPERATORS WITH RESTRICTIONS & IMPLICIT BEHAVIOR
 -------------------------------------------------------------------------------
 * Compound Assignment        :  += ,  -= ,  *= ,  /= ,  %= ,  &= ,  |= ,  ^= ,  <<= ,  >>= ,  >>>=
   - Cannot be explicitly overloaded. Overloading the base binary operator 
     (e.g., '+') automatically enables the compound version (e.g., '+=').

 * Indexing Operator [ ]      :  
   - Cannot be directly overloaded. Handled by creating an Indexer property:
     e.g., public T this[int index] { get; set; }

 * Type Conversions ( Cast )  :  
   - Handled via user-defined conversion operators using 'implicit' or 'explicit'.


 3. COMPLETE LIST OF OPERATORS THAT CANNOT BE OVERLOADED
 -------------------------------------------------------------------------------
 * Member Access & Evaluation :  .  ,  ?.  ,  () (Method invocation)
 * Conditional / Ternary      :  && ,  || ,  ?: ,  ?? ,  ??=
 * Assignment                 :  =
 * Type & Size Metadata       :  typeof  ,  sizeof  ,  nameof
 * Type Checking & Casting    :  is  ,  as
 * Memory & Allocation        :  new  ,  stackalloc  ,  with (Record mutation)
 * Contexts                   :  checked  ,  unchecked
 * Lambda / Expressions       :  =>
 * Pointers (Unsafe Code)     :  ->  ,  * (indirection)  ,  & (address-of)
================================================================================
*/