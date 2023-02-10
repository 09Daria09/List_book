using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_book
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library(1);
            library.Add();
            string str = library.ToString();
            Console.WriteLine(str);
           // library.Delete();
           // string str1 = library.ToString();
           // Console.WriteLine(str1);
            library.Faind();
        }
    }
}
