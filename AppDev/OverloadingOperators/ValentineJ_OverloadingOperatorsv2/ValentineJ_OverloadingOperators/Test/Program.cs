using OverloadingOperators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction f1 = new Fraction(4, 3, 4);
            Fraction f2 = new Fraction(6, 1, 3);
            Fraction f3 = new Fraction(4, 6, 8);
            Fraction f4 = new Fraction(1, 25, 6);

            Console.WriteLine($"{f2 - f1} Should be 1 7/12"); //subtract
            Console.WriteLine($"{f1 + f2} Should be 11 1/12"); //add
            Console.WriteLine($"{f1 * f2} Should be 30 1/12"); //multiply
            Console.WriteLine($"{f1 / f2} Should be 1 1/3"); //divide
            
            Console.WriteLine(f1.GetHashCode()); //gethashcode
            Console.WriteLine(f1.ToString()); //ToString

            if (f1 == f2) // == should fail
            {
                Console.WriteLine($"{f1.ToString()} equals {f2.ToString()}");
            }
            else
            {
                Console.WriteLine($"{f1.ToString()} does not equal {f2.ToString()}");
            }

            if (f3 == f2) // == should succeed
            {
                Console.WriteLine($"{f3.ToString()} equals {f2.ToString()}");
            }
            else
            {
                Console.WriteLine($"{f3.ToString()} does not equal {f2.ToString()}");
            }

            if (f1.Equals(f2)) //.equals() should fail
            {
                Console.WriteLine($"{f1.ToString()} equals {f2.ToString()}");
            }
            else
            {
                Console.WriteLine($"{f1.ToString()} does not equal {f2.ToString()}");
            }

            if (f3.Equals(f2)) //.equals should succeed
            {
                Console.WriteLine($"{f3.ToString()} equals {f2.ToString()}");
            }
            else
            {
                Console.WriteLine($"{f3.ToString()} does not equal {f2.ToString()}");
            }

            if (f1 != f2) //!= should succeed
            {
                Console.WriteLine($"{f1.ToString()} does not equal {f2.ToString()}");
            }
            else
            {

                Console.WriteLine($"{f1.ToString()} equals {f2.ToString()}");
            }

            if (f3 != f2) //!= should fail
            {
                Console.WriteLine($"{f3.ToString()} does not equal {f2.ToString()}");
            }
            else
            {
                Console.WriteLine($"{f3.ToString()} equals {f2.ToString()}");
            }
            Console.WriteLine("Press any key to close...");
            string input = Console.ReadLine();
        }
    }
}
    
