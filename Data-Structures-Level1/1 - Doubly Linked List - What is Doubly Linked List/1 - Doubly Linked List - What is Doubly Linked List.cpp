----SINGLY LINKED LIST:
// Each node contains data and a pointer to the next node
// Head pointer points to the first node in the list
// Last node's next pointer is NULL (end of list)
// Can only traverse in one direction (forward)
// Memory efficient - only one pointer per node

Structure:
// Head -> [Data|Next] -> [Data|Next] -> [Data|NULL]

Operations:
// Insert: Update next pointers to link new node
// Delete: Update previous node's next pointer to skip deleted node
// Search: Traverse from head until data found or reach NULL
// Access: Must traverse from head - no random access


----DOUBLY LINKED LIST:
// Each node contains data, next pointer, and previous pointer
// Head points to first node, tail points to last node
// Can traverse in both directions (forward and backward)
// More memory overhead - two pointers per node

Structure:
// NULL <- [Prev|Data|Next] <-> [Prev|Data|Next] <-> [Prev|Data|Next] -> NULL
//        ^Head                                                    ^Tail

Operations:
// Insert: Update both next and prev pointers of adjacent nodes
// Delete: Update both pointers of neighboring nodes to skip deleted node
// Search: Can start from head (forward) or tail (backward)
// Bidirectional traversal allows more efficient operations at both ends