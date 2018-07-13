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
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsEven(this int input)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsPrime(this int input)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        public static void Print<T>(this IEnumerable<T> input)
        {
            
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
