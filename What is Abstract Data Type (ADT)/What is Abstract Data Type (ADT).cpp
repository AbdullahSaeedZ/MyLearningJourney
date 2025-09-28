// -----------------------------------------------------------------------------------------
// ABSTRACT DATA TYPE (ADT) - SIMPLIFIED AND VECTOR-FOCUSED
// -----------------------------------------------------------------------------------------

// ADT is a THEORETICAL BLUEPRINT that defines a data type by its BEHAVIOR (what it does).
// It's the "contract" for a data structure.

// KEY CONCEPT: ABSTRACTION. The user only sees the available operations, not the complex code behind them.
// vectors is an ADT , cuz we just include it then use it with its methods with out caring about how it does that.
// -------------------
// THE LIST ADT (The Contract)
// -------------------

// The List ADT is the general IDEA for a resizable, ordered collection of items.
// It promises specific OPERATIONS (like adding or getting an item by index).
// This is the functional REQUIREMENT, independent of any programming language.

// -------------------
// std::vector IN C++ (The Implementation)
// -------------------

// The 'std::vector' is the C++ CONCRETE IMPLEMENTATION that fulfills the List ADT contract.
// We can say: "The vector REPRESENTS a List ADT."
// It uses a dynamic array internally to achieve the List's required behavior.

void use_vector_as_list_adt_example() {
    std::vector<int> numbers; // The concrete data type we use.

    // List ADT Operation: Insert element
    numbers.push_back(10);
    // ADT perspective: An item was successfully added to the List (The "what").
    // Implementation detail (hidden): The vector might have had to allocate new memory 
    // and copy all old elements over to handle the growth (The "how").

    // List ADT Operation: Access by index
    int value = numbers.at(0);
    // DT perspective: We can retrieve the item quickly from the List.
    // Implementation detail (hidden): The vector uses fast array indexing for O(1) access.
}

// Summary: ADT is the set of rules (e.g., "A List must have a way to add items"). 
//          std::vector is the class that FOLLOWS those rules perfectly.
// -----------------------------------------------------------------------------------------------------------------------------------------------