using System;
using ExtMethods;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "taco cat";

            //testing the IsEven method
            if (8.IsEven())
            {
                Console.WriteLine("IsEven works");
            }
            else
            {
                Console.WriteLine("IsEven failed");
            }

            //Testing the IsPrime method
            if (13.IsPrime())
            {

                Console.WriteLine("IsPrime works");
            }
            else
            {
                Console.WriteLine("IsPrime failed");
            }

            //Testing the ToPower method
            Console.WriteLine($"3 yto the power of 3 is {3.ToPower(3)}");

            //testing the IsPalindrome method
            if (test.IsPalindrome())
            {
                Console.WriteLine("IsPalindrome works.");
            }
            else
            {
                Console.WriteLine("IsPalindrome failed");
            }

            //testing the Shift method
            Console.WriteLine(test.Shift(3));

            Console.Write("Press any key to return...");
            Console.ReadLine();
        }
    }
}

