// Number 79 looks like a simple integer,
// but in reality it stores multiple pieces of data (permissions).
// This is called a "bitmask".

// In binary, 79 = 01001111
// Each bit (0 or 1) represents if a permission is ON (1) or OFF (0).

// Example of permissions mapping:
// bit 0 (value 1)   -> Show Client List
// bit 1 (value 2)   -> Add New Client
// bit 2 (value 4)   -> Delete Client
// bit 3 (value 8)   -> Update Client
// bit 4 (value 16)  -> Find Client
// bit 5 (value 32)  -> Transactions
// bit 6 (value 64)  -> Manage Users
// bit 7 (value 128) -> Show Login Register

// So, number 79 means the user has:
// Show Client List, Add New Client, Delete Client, Update Client, Manage Users.

// Why use binary for this?
// - Space Complexity: Instead of storing each permission as a separate variable
//   (which would take more memory), we pack all of them inside ONE integer.
// 
// - Data Structure: This is an efficient way to store and organize multiple
//   boolean values in a single number.
// 
// - Operations: We can quickly check, add, or remove permissions using bitwise
//   operations (AND, OR, NOT).

// - Time Complexity: using one if-statement to check permissions, will be faster than using loops or whatever.
// big o notation will be O(1) which is fast.
