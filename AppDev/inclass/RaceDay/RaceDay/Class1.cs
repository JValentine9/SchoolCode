using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceDay
{
    public static class DemoExtensions
    {
        public static int GetRandom(this int max, int min = 1)
        {
            if(min>max)
            {
                throw new ArgumentException($"Min must not be greater than max");
            }
        }

    }


    public class Class1
    {
        public static void Rcce2()
        {
            string hw = "Hello World";

        }

        public static void Race3()
        {
            //randomly select a number between 17 and 59 and print it to the console
            Console.WriteLine(17.GetRandom(59));
        }
  
    }
}
