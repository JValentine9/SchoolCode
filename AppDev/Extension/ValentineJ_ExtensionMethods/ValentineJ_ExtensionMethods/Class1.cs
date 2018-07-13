using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExtMethods
{
    public static class Extensions
    {
        /// <summary>
        /// The IsEven method tests the int it's ran against is even by checking it's modulo remainder
        /// </summary>
        /// <param name="input">The int being tested</param>
        /// <returns>Returns a true or false response depending on wether or not an int is even.</returns>
        public static bool IsEven(this int input)
        {
            if (Math.Abs(input) % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Check to see wether or not an int is a prime.
        /// </summary>
        /// <param name="input">The int which is being tested for Prime status</param>
        /// <returns>Returns a boolean stating wether or not an int is prime.</returns>
        public static bool IsPrime(this int input)
        {
            int MInput = Math.Abs(input);

            if (MInput <= 1) return false;
            if (MInput == 2) return true;
            if (MInput % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(MInput));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (MInput % i == 0) return false;
            }

            return true;
        }

        /// <summary>
        /// Prints out the objects in any collection, separating each value with a comma and space while making sure there are NO dangling tail symbols.
        /// </summary>
        /// <param name="input">The IEnumerable on wich the method is being called to print</param>
        public static void Print<T>(this IEnumerable<T> input)
        {
            int length = input.Count();
            int count = 0;

            foreach(var item in input)
            {
                Console.Write(item);
                count++;

                if (count != length)
                {
                    Console.Write(", ");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="exponent"></param>
        /// <returns></returns>
        public static long ToPower(this int input, int exponent)
        {
            return 2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsPalindrome(this String input)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="ShiftValue"></param>
        /// <returns></returns>
        public static String Shift(this String input, int ShiftValue)
        {
            return "lol get rekt";
        }
    }
}
