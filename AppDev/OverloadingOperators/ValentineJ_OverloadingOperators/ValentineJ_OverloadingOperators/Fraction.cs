using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadingOperators
{
    public struct Fraction
    {
        private static int denominator;

        public static int WholeNumber { get; set; }
        public static int Numerator { get; set; }
        public static int Denominator { get; set; } // ==denominator, != 0, if set = 0 throew ArgumentException


        /*Constructor
         * public Fraction (int whole, int numerator, int denominator)
         * whole & numerator default 0, denominator default 1
         * WholeNumber = this.whole;
         * Numerator = this.numerator
         * denominator = this.denominator
         * Denominator = denominator
        */ 

            /// <summary>
            /// GCD returns the Greatest Common Denominator from the two numbers entered
            /// </summary>
            /// <param name="m">m is the first number entered</param>
            /// <param name="n">n is the second number entered</param>
            /// <returns>returns an int which is the GCD of m and n</returns>
        public static int GCD(int m, int n)
        {
            int remainder;
            while (n != 0)
            {
                remainder = m % n;
                m = n;
                n = remainder;
            }

            return m;
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Add(Fraction m, Fraction n)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Subtract(Fraction m, Fraction n)
        {

        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Multiply(Fraction m, Fraction n)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Divide(Fraction m, Fraction n)
        {

        }




    }
}
