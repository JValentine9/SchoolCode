using StructDemo_A.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructDemo_A
{
    class Program
    {
        static void Main(string[] args)
        {
            Dragon smaug = new Dragon() { Name = "Smaug, The Terrible", Age = 171 };
            Dragon othrDrgn = smaug;

            Console.WriteLine(smaug);
            othrDrgn.Name = "Phteven";
            Console.WriteLine(othrDrgn);


        }
    }
}
