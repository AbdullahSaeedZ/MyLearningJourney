using System.Reflection;

namespace DemoNamespace
{
    // assembly is the basic unit of deployment, so we deploy assemblies to the clients, not the source code
    // and projects are not only code, projects have resources like images or other files, in this example it is json

    // in DVLD, it was the icons files that were embedded

    internal class Program
    {
        // i created a folder to put resources that will be embedded into this assembly
        // the resource is a json file containing countries info

        // after putting the file in the folder, from solution explorer, right click on the resource file (json in our case)
        // then click on properties, then in the Build Action property will define the nature of this file in our project
        // we choose Embedded Resource

        // then second option is the Copy to Output Directory, we choose do not copy,no need to have a copy in bin folder after it is embedded in the dll file

        // so after building the project, the source code is compiled an assembly containing IL + Metadata + Embeded Resources

        static void Main(string[] args)
        {
            // after embedding, we can access the resources in the assembly:
            Type thisClassType = typeof(Program);
            Assembly assembly = thisClassType.Assembly;

            // we open a stream to the resources file, we have two ways:  
            // using Stream? stream = assembly.GetManifestResourceStream(thisClassType, "ResourcesToEmbed.countries.json");
            // using Stream? stream = assembly.GetManifestResourceStream("dllFileName.ResourcesToEmbed.countries.json")  <- path of the json is followed by the folder name it was in before compilation

            // open the stream with the resources file that is embedded
            using Stream? stream = assembly.GetManifestResourceStream("Demo.ResourcesToEmbed.countries.json");

            // then the streamReader to catch the bytes from the stream and to be able to do operations on the data recieved
            using StreamReader reader = new StreamReader(stream);

            string jsonContent = reader.ReadToEnd();
            Console.WriteLine(jsonContent);
        }
    }
}
