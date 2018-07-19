using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ValentineJ_DelegatePractice
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="nums"></param>
    public delegate void Mathematician(params int[] nums);

    class Program
    {
        public static Mathematician Einstein;
        public static string input;

        static void Main(string[] args)
        {
            Einstein += ParamMath.Add;
            Einstein += ParamMath.Subtract;
            Einstein += ParamMath.Multiply;
            Einstein += ParamMath.Divide;
            Einstein += ParamMath.Mod;

            GetNumbers();
            Einstein(ConvertToStringArray());
            Console.Write("Press Any Key To Return...");
            Console.ReadLine();
            
        }

        static void GetNumbers()
        {
            Console.Write("Please input a number of valid integers seperated by commas and spaces: ");
            input = Console.ReadLine();
        }

        static int[] ConvertToStringArray()
        {
            input.Trim(',');
            input.Replace(" ", "");
            int[] nums = input.Split(',').Select(str => int.TryParse(str, out int val) ? val : 0).Cast<int>().ToArray();
            return nums;
        }
    }

    /// <summary>
    /// A class for doing math based upon an unknown number of integers
    /// </summary>
    class ParamMath
    {
        /// <summary>
        /// A method to add an unknown number of integers together. Goes from first to last, in the order they are entered. Prints the sum at the end of the task
        /// </summary>
        /// <param name="nums">The integers to be added together, from first to last</param>
        public static void Add(params int[] nums)
        {
            long ans = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                ans += nums[i];
            }

            Console.WriteLine($"Sum: {ans}");
        }

        /// <summary>
        /// A method to subtract an unknown number of integers from each other. Goes from first to last, in the order they are entered. Prints the difference at the end of the task.
        /// </summary>
        /// <param name="nums">The numbers to be subtracted from each other, from first to last</param>
        public static void Subtract(params int[] nums)
        {
            int ans = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                ans -= nums[i];
            }

            Console.WriteLine($"Difference: {ans}");
        }

        /// <summary>
        /// A method to multiply an unknown number of integers by each other. Goes from first to last, in the order they are entered. Prints the product at the end of the task.
        /// </summary>
        /// <param name="nums">The numbers to be multiplied by each other, from first to last</param>
        public static void Multiply(params int[] nums)
        {
            long ans = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                ans *= nums[i];
            }

            Console.WriteLine($"Product: {ans}");
        }

        /// <summary>
        /// A method to divide an unknown number of integers by each other. Goes from first to last, in the order they are entered. Prints the quotient at the end of the task.
        /// </summary>
        /// <param name="nums">The numbers to be divided by each other, from first to last</param>
        public static void Divide(params int[] nums)
        {
            double ans = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    ans /= nums[i];
                }
                else
                {
                    throw new DivideByZeroException();
                }
            }

            Console.WriteLine($"Quotient: {ans}");
        }

        /// <summary>
        /// A method to modulate an unknown number of integers by each other. Goes from first to last, in the order they are entered. Prints the remainder at the end of the task.
        /// </summary>
        /// <param name="nums">The numbers to be modulated by each other, from first to last.</param>
        public static void Mod(params int[] nums)
        {
            double ans = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    ans %= nums[i];
                }
                else
                {
                    throw new DivideByZeroException();
                }
            }

            Console.WriteLine($"Remainder: {ans}");
        }
    }
}
