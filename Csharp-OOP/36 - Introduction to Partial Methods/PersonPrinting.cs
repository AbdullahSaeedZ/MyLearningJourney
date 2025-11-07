using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public partial class Person
{
    // here we define the method using partial keyword
    partial void printAge()
    {
        Console.WriteLine($"current age is {age}");
    }

}