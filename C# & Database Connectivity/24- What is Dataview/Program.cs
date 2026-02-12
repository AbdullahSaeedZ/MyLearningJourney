// DataTable:
// - Stores the actual data (rows + columns).
// - Owns the data, constraints, relations, and schema.
// - Used for inserts, updates, deletes, and structural changes.
// - Heavier in memory and operations.

// DataView:
// - A lightweight view (wrapper) over a DataTable.
// - Does NOT copy data; works on references.
// - Used mainly for sorting, filtering, and searching.
// - Ideal for display and querying, especially with data binding.
// - Sorting/filtering reorders indexes, not rows.
// - Can have multiple Views from the same dataTable for multiple controls.

// Key differences:
// - DataTable = data owner.
// - DataView = data viewer (lens over the table).
// - DataView is better for UI binding and fast filtering/sorting.
// - DataTable is better for complex data manipulation and persistence.

// Rule of thumb:
// - Need to modify data or schema → use DataTable.
// - Need to display, filter, or sort data → use DataView.
