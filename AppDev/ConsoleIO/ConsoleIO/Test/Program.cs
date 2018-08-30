using System;
using System.Collections.Generic;
using CSC160_ConsoleMenu;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> menuList = new List<string>();

            menuList.Add("ducks");
            menuList.Add("cabbage");
            menuList.Add("monster trucks");
            menuList.Add("pizza");
            menuList.Add("Resident Evil 7");

            Console.WriteLine(CIO.PromptForMenuSelection(menuList, true));
            Console.WriteLine(CIO.PromptForBool("You like trains. True or false?", "true", "false"));
            Console.WriteLine(CIO.PromptForByte("Please enter a byte between 0 and 3", 0, 3));
            Console.WriteLine(CIO.PromptForShort("Enter a Short between 0 and 15", 0, 15));
            Console.WriteLine(CIO.PromptForChar("Please enter a valid char between 2 and 9", (char)2, (char)9));
            Console.WriteLine(CIO.PromptForDecimal("Please enter a decimal between 1 and 2", 1, 2));
            Console.WriteLine(CIO.PromptForDouble("Please enter a Double between 16 and 24", 16, 24));
            Console.WriteLine(CIO.PromptForFloat("Please enter a valid float between 78 and 98", 78, 98));
            Console.WriteLine(CIO.PromptForInput("Please Enter your Name", true));
            Console.WriteLine(CIO.PromptForLong("Please Enter a valid long between 987 and 1029234", 987, 1029234));
            Console.WriteLine(CIO.PromptForInt("Please enter an int between 1 and 10", 1, 10));

            Console.WriteLine("Press any key to continue...");
            string input = Console.ReadLine();
        }
    }
}
