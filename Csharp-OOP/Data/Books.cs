using System;

namespace Data
{
    public class Books
    {
        public string BookName { get; set; }



        // since Papers is internal and in the same namespace , i can reach here, and only in the namesmace scope, not other projects
        Papers paper1 = new Papers();
        
        public void method1()
        {
            paper1.Number = 1;
        }
    }
}
