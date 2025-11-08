using System;

namespace Data
{
    internal class Papers
    {
        public int Number { get; set; }


        // Books is public, so i can reach here in the same namespace and in other projects 
        Books book1 = new Books();

        public void bookMethod1()
        {
            book1.BookName = "book1";
        }

    }
}
