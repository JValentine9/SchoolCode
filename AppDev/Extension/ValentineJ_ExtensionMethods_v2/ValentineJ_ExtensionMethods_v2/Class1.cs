using System;
using System.Collections.Generic;
using System.Linq;
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

            foreach (var item in input)
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
        /// Returns a long of the extended int to the power of the chosen exponent
        /// </summary>
        /// <param name="input">The number being affected</param>
        /// <param name="exponent">The power to which the input is being raised</param>
        /// <returns>Returns a long which is the input to the power of the exponent</returns>
        public static long ToPower(this int input, int exponent)
        {
            int ret = 1;
            while (exponent != 0)
            {
                if ((exponent & 1) == 1)
                    ret *= input;
                input *= input;
                exponent >>= 1;
            }
            return ret;
        }

        /// <summary>
        /// Tests to see if a string is a palindrome
        /// </summary>
        /// <param name="input">The string to be tested</param>
        /// <returns>Returns a boolean stating wether or not a string is a palindrome</returns>
        public static bool IsPalindrome(this String input)
        {
            string revStr = "";
            int Length;
            input = input.Replace(" ", String.Empty);
            input = input.ToLower();

            Length = input.Length - 1;
            while (Length >= 0)
            {
                revStr = revStr + input[Length];
                Length--;
            }

            return input.Equals(revStr);


        }

        /// <summary>
        /// Shifts the value of a string by the amount of ShiftValue
        /// </summary>
        /// <param name="input">The string being shifted</param>
        /// <param name="ShiftValue">The amount the string is to shift</param>
        /// <returns>Returns the newly shifted string</returns>
        public static string Shift(this String input, int ShiftValue)
        {
            var s = input.ToCharArray();
            int NewVal;
            string output;

            for(int i = 0; i < s.Length; i++)
            {
                NewVal = (s[i] + ShiftValue);
                if (NewVal > 127)
                {
                    NewVal -= 96;
                    s[i] = (char)NewVal;
                }
                else
                {
                    s[i] = (char)NewVal;
                }
            }
            output = string.Join("", s);
            return output;

        }
    }
}
