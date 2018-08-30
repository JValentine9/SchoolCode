using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace CSC160_ConsoleMenu
{
    public static class CIO
    {
        static int intValue;
        static byte byteValue;
        static short shortValue;
        static long longValue;
        static float floatValue;
        static double doubleValue;
        static decimal decimalValue;
        static char charValue;
        static string input;
        static bool valid = false;

        /// <summary>
        /// Generates a console-based menu using the strings in options as the menu items.
        /// Automatically numbers each option starting at 1 and incrementing by 1.
        /// Reserves the number 0 for the "quit" option when withQuit is true.
        /// </summary>
        /// <param name="options">strings representing the menu options</param>
        /// <param name="withQuit">adds option 0 for "quit" when true</param>
        /// <returns>the int of the selection made by the user</returns>
        public static int PromptForMenuSelection(IEnumerable<string> options, bool withQuit)
        {
            valid = false;
            int count = 0;
            if (withQuit)
            {
                Console.WriteLine("0. Quit");
                foreach (string x in options)
                {
                    count++;
                    Console.WriteLine($"{count}. " + x);
                }
            }
            else
            {
                foreach (string x in options)
                {
                    Console.WriteLine($"{count}. " + x);
                    count++;
                }
            }
            intValue = PromptForInt("Please select a Menu Item", 0, options.Count());
            
            return intValue;
        }

        /// <summary>
        /// Generates a prompt that expects the user to enter one of two responses that will equate
        /// to a boolean value. The trueString represents the case insensitive response that will equate to true. 
        /// The falseString acts similarly, but for a false boolean value.
        /// 	Example: Assume this method is called with a trueString argument of "yes" and a falseString
        /// 	argument of "no". If the user enters "YES", the method returns true. If the user enters "no",
        /// 	the method returns false. All other inputs are considered invalid, the user will be informed, 
        /// 	and the prompt will repeat.
        /// </summary>
        /// <param name="message">the prompt to be displayed to the user</param>
        /// <param name="trueString">the case insensitive value that will evaluate to true</param>
        /// <param name="falseString">the case insensitive value that will evaluate to false</param>
        /// <returns>the boolean value</returns>
        public static bool PromptForBool(string message, string trueString, string falseString)
        {
            valid = false;;

            while (!valid)
            {
                Console.Write(message + ": ");
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == trueString || input == falseString)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine($"Please enter one of the provided response: {trueString} or {falseString}.");
                }
            }
            if (input == trueString)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Generates a prompt that expects a numeric input representing a byte value.
        /// This method loops until valid input is given.
        /// </summary>
        /// <param name="message">the prompt to be displayed to the user</param>
        /// <param name="min">the inclusive minimum boundary</param>
        /// <param name="max">the inclusive maximum boundary</param>
        /// <returns>the byte value</returns>
        public static byte PromptForByte(string message, byte min, byte max)
        {
            valid = false;

            while (!valid)
            {
                Console.Write(message + ": ");
                input = Console.ReadLine();

                if (byte.TryParse(input, out byteValue))
                {
                    if (byteValue >= min)
                    {
                        if (byteValue <= max)
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.WriteLine($"Input too high, enter a valid input less than {max}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Input too low, enter a valid input greater than {min}.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid byte");
                }
            }
            return byteValue;
        }

        /// <summary>
        /// Generates a prompt that expects a numeric input representing a short value.
        /// This method loops until valid input is given.
        /// </summary>
        /// <param name="message">the prompt to be displayed to the user</param>
        /// <param name="min">the inclusive minimum boundary</param>
        /// <param name="max">the inclusive maximum boundary</param>
        /// <returns>the short value</returns>
        public static short PromptForShort(string message, short min, short max)
        {
            valid = false;

            while (!valid)
            {
                Console.Write(message + ": ");
                input = Console.ReadLine();

                if (short.TryParse(input, out shortValue))
                {
                    if (shortValue < min)
                    {
                        if (shortValue > max)
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.WriteLine($"Input too high, enter a valid input less than {max}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Input too low, enter a valid input greater than {min}.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid short");
                }
            }
            return shortValue;
        }

        /// <summary>
        /// Generates a prompt that expects a numeric input representing a int value.
        /// This method loops until valid input is given.
        /// </summary>
        /// <param name="message">the prompt to be displayed to the user</param>
        /// <param name="min">the inclusive minimum boundary</param>
        /// <param name="max">the inclusive maximum boundary</param>
        /// <returns>the int value</returns>
        public static int PromptForInt(string message, int min, int max)
        {
            valid = false;

            while (!valid)
            {
                Console.Write(message + ": ");
                input = Console.ReadLine();
                
                if (Int32.TryParse(input, out intValue))
                {
                    if (intValue >= min)
                    {
                        if (intValue <= max)
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.WriteLine($"Input too high, enter a valid input less than {max}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Input too low, enter a valid input greater than {min}.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer");
                }
            }
            return intValue;
        }

        /// <summary>
        /// Generates a prompt that expects a numeric input representing a long value.
        /// This method loops until valid input is given.
        /// </summary>
        /// <param name="message">the prompt to be displayed to the user</param>
        /// <param name="min">the inclusive minimum boundary</param>
        /// <param name="max">the inclusive maximum boundary</param>
        /// <returns>the long value</returns>
        public static long PromptForLong(string message, long min, long max)
        {
            valid = false;

            while (!valid)
            {
                Console.Write(message + ": ");
                input = Console.ReadLine();

                if (long.TryParse(input, out longValue))
                {
                    if (longValue < min)
                    {
                        if (longValue > max)
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.WriteLine($"Input too high, enter a valid input less than {max}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Input too low, enter a valid input greater than {min}.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid long");
                }
            }
            return longValue;
        }

        /// <summary>
        /// Generates a prompt that expects a numeric input representing a float value.
        /// This method loops until valid input is given.
        /// </summary>
        /// <param name="message">the prompt to be displayed to the user</param>
        /// <param name="min">the inclusive minimum boundary</param>
        /// <param name="max">the inclusive maximum boundary</param>
        /// <returns>the float value</returns>
        public static float PromptForFloat(string message, float min, float max)
        {
            valid = false;

            while (!valid)
            {
                Console.Write(message + ": ");
                input = Console.ReadLine();

                if (float.TryParse(input, out floatValue))
                {
                    if (floatValue < min)
                    {
                        if (floatValue > max)
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.WriteLine($"Input too high, enter a valid input less than {max}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Input too low, enter a valid input greater than {min}.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid float");
                }
            }
            return floatValue;
        }

        /// <summary>
        /// Generates a prompt that expects a numeric input representing a double value.
        /// This method loops until valid input is given.
        /// </summary>
        /// <param name="message">the prompt to be displayed to the user</param>
        /// <param name="min">the inclusive minimum boundary</param>
        /// <param name="max">the inclusive maximum boundary</param>
        /// <returns>the double value</returns>
        public static double PromptForDouble(string message, double min, double max)
        {
            valid = false;

            while (!valid)
            {
                Console.Write(message + ": ");
                input = Console.ReadLine();

                if (double.TryParse(input, out doubleValue))
                {
                    if (doubleValue < min)
                    {
                        if (doubleValue > max)
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.WriteLine($"Input too high, enter a valid input less than {max}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Input too low, enter a valid input greater than {min}.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid double");
                }
            }
            return doubleValue;
        }

        /// <summary>
        /// Generates a prompt that expects a numeric input representing a decimal value.
        /// This method loops until valid input is given.
        /// </summary>
        /// <param name="message">the prompt to be displayed to the user</param>
        /// <param name="min">the inclusive minimum boundary</param>
        /// <param name="max">the inclusive maximum boundary</param>
        /// <returns>the decimal value</returns>
        public static decimal PromptForDecimal(string message, decimal min, decimal max)
        {
            valid = false;

            while (!valid)
            {
                Console.Write(message + ": ");
                input = Console.ReadLine();

                if (decimal.TryParse(input, out decimalValue))
                {
                    if (decimalValue < min)
                    {
                        if (decimalValue > max)
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.WriteLine($"Input too high, enter a valid input less than {max}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Input too low, enter a valid input greater than {min}.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid decimal");
                }
            }
            return decimalValue;
        }

        /// <summary>
        /// Generates a prompt that allows the user to enter any response and returns the string.
        /// When allowEmpty is true, empty responses are valid. When false, responses must contain
        /// at least one character (including whitespace).
        /// </summary>
        /// <param name="message">the prompt to be displayed to the user.</param>
        /// <param name="allowEmpty">when true, makes empty responses valid</param>
        /// <returns>the input from the user as a String</returns>
        public static string PromptForInput(string message, bool allowEmpty)
        {
            valid = false;

            while (!valid)
            {
                Console.WriteLine(message);
                input = Console.ReadLine();

                if (allowEmpty)
                {
                    valid = true;
                }
                else
                {
                    if (input == "")
                    {
                        Console.WriteLine("Please enter a valid input");
                    }
                    else
                    {
                        valid = true;
                    }
                }
            }
            return input;
        }

        /// <summary>
        /// Generates a prompt that expects a single character input representing a char value.
        /// This method loops until valid input is given.
        /// </summary>
        /// <param name="message">the prompt to be displayed to the user</param>
        /// <param name="min">the inclusive minimum boundary</param>
        /// <param name="max">the inclusive maximum boundary</param>
        /// <returns>the char value</returns>
        public static char PromptForChar(string message, char min, char max)
        {
            valid = false;

            while (!valid)
            {
                Console.Write(message + ": ");
                input = Console.ReadLine();

                if (char.TryParse(input, out charValue))
                {
                    if (charValue < min)
                    {
                        if (charValue > max)
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.WriteLine($"Input too high, enter a valid input less than {max}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Input too low, enter a valid input greater than {min}.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid char");
                }
            }
            return charValue;
        }
    }
}

