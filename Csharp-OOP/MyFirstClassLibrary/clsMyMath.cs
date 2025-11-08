using System;

// When you build the project, the compiler converts the code into CIL (Intermediate Language).
// The final file type depends on the project type:
//
// - If the project has an entry point (Main), the output is an .exe (executable application).
// - If the project is a Class Library (no Main), the output is a .dll (library).
//
// .exe → can run by itself.
// .dll → cannot run by itself; it must be referenced and used by another project.

// Both .exe and .dll are each called Assemblies.
// Each assembly is a single compiled output in CIL (not a container of others).


// so we build this project and use its .dll in other solution by referencing it 

namespace MyLibrary
{

    public class clsMyMath
    {

        public int Sum(int x, int y)
        {
            return x + y;
        }

        public int Sum(int x, int y, int z)
        {
            return x + y + z;
        }
    }

}

