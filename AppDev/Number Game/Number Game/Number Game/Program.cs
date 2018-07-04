using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Game
{
    class Program
    {
        public enum Difficulty { Easy, Medium, Hard };
        static Difficulty setDiff;
        static public int inMax;
        static public int inMin = 1;
        static public int input;

        static void Main(string[] args)
        {
            bool stillPlaying = true;
            int cont;

            while (stillPlaying)
            {
                Difficulty d;
                d = SetDifficulty();

                Game(d);
                Console.Write("Would you like to continue? 1. Yes 2. No");
                cont = int.Parse(Console.ReadLine());
                switch (cont)
                {
                    case 1:
                        stillPlaying = true;
                        break;
                    case 2:
                        stillPlaying = false;
                        break;
                    default:
                        Console.WriteLine("Can't decide? another game then.");
                        break;
                }
            }
        }

        static public Difficulty SetDifficulty()
        {
            bool valid = false;

            while (!valid)
            {
                Console.Write("Please set a difficulty by entering the associated number. 1. Easy 2. Medium 3. Hard");
                int caseSwitch = int.Parse(Console.ReadLine());
                switch (caseSwitch)
                {

                    case 1:
                        setDiff = Difficulty.Easy;
                        valid = true;
                        break;
                    case 2:
                        setDiff = Difficulty.Medium;
                        valid = true;
                        break;
                    case 3:
                        setDiff = Difficulty.Hard;
                        valid = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input");
                        break;
                }
            }
            return setDiff;
        }

        static public void Game(Difficulty d)
        {
            Random rnd = new Random();
            int ans;
            int input;
            bool correct = false;
            int attempts = 5;
            if (d == Difficulty.Easy)
            {
                ans = rnd.Next(1, 11);
                inMax = 10;
            }
            else if (d == Difficulty.Medium)
            {
                ans = rnd.Next(1, 51);
                inMax = 50;
            }
            else
            {
                ans = rnd.Next(1, 101);
                inMax = 100;
            }

            while (!correct && attempts > 0)
            {
                input = InputValidation();

                if (input < ans)
                {
                    Console.WriteLine("A little low.");
                    attempts--;
                    Console.WriteLine($"Attempts Remaining: {attempts}");
                }
                else if (input > ans)
                {
                    Console.WriteLine("A little high");
                    attempts--;
                    Console.WriteLine($"Attempts Remaining: {attempts}");
                }
                else
                {
                    Console.WriteLine("correct!");
                    correct = true;
                }
            }
            if (correct)
            {
                Console.WriteLine("You Win!");
                Console.WriteLine(($"Guesses Remaining: {attempts}"));
            }
            else if (attempts < 1)
            {
                Console.WriteLine("Better luck next time.");
            }
        }

        static public int InputValidation()
        {
            bool isInt = false;
            bool isValid = false;
            string inputTest;

            while (!isInt)
            {
                Console.Write($"Please enter a whole number between {inMin} and {inMax}: ");
                inputTest = Console.ReadLine();

                if (int.TryParse(inputTest, out input))
                {
                    if (input > inMax || input < inMin)
                    {
                        Console.WriteLine($"Your input must be between {inMin} and {inMax}.");
                    }
                    else
                    {
                        isValid = true;
                    }
                    isInt = true;
                }
                else
                {
                    Console.WriteLine($"You must input a valid integer between {inMin} and {inMax}.");
                }
            }
            return input;
        }
    }
}
