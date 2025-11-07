using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class  Person
{

    public int age { get; set; }

    // using partial keyword to prepare it for partial definition in another file
    // it is not a must to do the implementation, no error will be given if not defined yet.
    partial void printAge();

    public void birthday()
    {

        age++;

        // if printAge is implemented then it will be called, if not yet implemented then it is ignored
        printAge();
    }


}
