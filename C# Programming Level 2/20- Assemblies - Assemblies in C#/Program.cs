namespace _20__Assemblies_in_C_
{
    // Assembly is the basic unit of deployment in .NET

    // in old .NET like .NET Framework 4.8 where it is only for windows platdorm, once a project is built, source code will be compiled
    // into IL assembly with exe extention, or dll if it was a class lib.
    // that exe assembly is only one file where it has IL code + Launcher to launch CLR and run the app

    // but when .NET became cross-platform, they had to come up with a new way for other OS's to run the .NET apps
    // so they separated the compilation output into two files:

    // 1- first file is source code compiled into dll assembly
    // 2- second file is a launcher file that will call the CLR to run the dll assembly

    // so the second file is just a launcher, not an assembly, and this launcher is different
    // based on the OS where the code is developed, if windows then launcher is in exe, if linux then it is something else.

    // ======================= Metadata =====================================

    // once a source code is compiled into IL, a metadata will be generated inside the assembly
    // metadata is info about the code, ex: author, director and actors are the metadata of movies
    // so metadata will provide info about the classes names, methods names and parameters, memebrs and much more
    // metadata are used to make communication between assemblies easier, no need to see the IL code, metadata will provide data faster and easier.

    // ======================= Assembling, Disassembling and IL Code =====================================

    //         ildasm tool
    // how to see the assembly code in IL ?? in windows search > write comm then you will see Cross Tools Command Prompt for vs
    // run it then move through folders using cd command to reach the folder where the dll and exe files are.
    // then use the ildasm command which is the disassembler tool, like c:\users\asz14\assemblyTest>ildasm File_Name.dll

    // then u can navigate the namespace and classes and you will see the below methods and eveything in IL, whatever .NET lang used,
    // the output IL is the same we see when we run the disassembler.

    // in the disassembler tool we can create a new file of the dll but in IL code
    // fo to file > dump > check dump IL code, then save it in same folder

    // ========

    //        ilasm tool
    // now we use assembler tool to convert the IL to dll,
    // windows search > write comm then you will see Cross Tools Command Prompt for vs
    // run it then move through folders using cd command to reach the folder where the IL file is, then run the tool:
    //  c:\users\asz14\assemblyTest>ilasm File_Name.IL /dll /exe     <- this will convert the IL to exe (launcher) + dll assembly

    // if the ilasm is old then it will convert into one exe fiel (launcher + assembly), new ilasm needs to be installed by NuGet



    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Assemblies"); // <- will be show in the IL code after when dll is disassembled by ildasm
        }
    }
}
