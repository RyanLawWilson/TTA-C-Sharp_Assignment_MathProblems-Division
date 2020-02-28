using System;
using System.Collections.Generic;

// Page 147
// I can't think of anything creative for this assigment.

namespace MathProblems_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing the Lists
            List<double> dividedList = new List<double>();
            List<int> numbers = getRandomNumberList(50);

            // Game loop
            bool playGame = true;
            while (playGame)
            {
                displayList(numbers);

                // Catch any format or divide by zero exceptions.
                try
                {
                    awesomeWrite("What integer to you want to divide this list by?  ");
                    int divisor = Convert.ToInt32(Console.ReadLine());

                    // For every number in the list, divide by divisor and add to dividedList.
                    foreach (int num in numbers)
                    {
                        double k = (double)num / divisor;
                        // If the number is infinity, throw an exception.
                        if (Double.IsInfinity(k))
                        {
                            throw new DivideByZeroException();
                        }
                        dividedList.Add(k);
                    }

                    displayList(dividedList);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("You can't insert letters... try again | Error: " + ex.Message);
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("You can't divide by zero... try again | Error: " + ex.Message);
                }
                Console.WriteLine("EXITED TRY / CATCH");

                // Ask the user if they want to play again.
                Console.Write("Do you want to play again? (y or n)  ");
                string playAgainChoice = Console.ReadLine();
                if (playAgainChoice == "y")
                {
                    awesomeWrite("Awesome!  ", 50);
                    System.Threading.Thread.Sleep(500);
                    awesomeWrite("Building number list...\n\n\n", 75);
                    System.Threading.Thread.Sleep(250);
                    numbers = getRandomNumberList(50);
                    dividedList.Clear();
                }
                else
                {
                    playGame = false;
                }
            }

            awesomeWrite("\nHave a nice day!", 50);
            Console.ReadLine();
        }

        // Makes a certain number of random numbers, adds them to a list, and returns the list back to main.
        static List<int> getRandomNumberList(int amount)
        {
            List<int> nums = new List<int>();
            Random rand = new Random();
            for (int i = 0; i < amount; i++)
            {
                nums.Add(rand.Next(0, 1001));
            }
            return nums;
        }

        // A nice way of displaying integer lists
        static void displayList(List<int> numbers)
        {
            int columns = 10;

            // The top border =========
            for (int i = 0; i < columns; i++)
            {
                Console.Write("======");
            }
            Console.WriteLine("==");

            int cell = 0;
            
            foreach (int num in numbers)
            {
                awesomeWrite(String.Format("{0,6}",num), 3);
                if (cell % columns == columns - 1 || numbers[numbers.Count - 1] == num)
                {
                    Console.WriteLine();
                }

                cell++;
            }

            // The bottom border =========
            for (int i = 0; i < columns; i++)
            {
                Console.Write("======");
            }
            Console.WriteLine("==\n");
        }

        // A nice way of displaying double lists
        static void displayList(List<double> numbers)
        {
            int columns = 10;

            // The top border =========
            for (int i = 0; i < columns; i++)
            {
                Console.Write("========");
            }
            Console.WriteLine("==");

            int cell = 0;

            foreach (double num in numbers)
            {
                awesomeWrite(String.Format("{0,8:F2}", num), 2);
                if (cell % columns == columns - 1 || numbers[numbers.Count - 1] == num)
                {
                    Console.WriteLine();
                }

                cell++;
            }

            // The bottom border =========
            for (int i = 0; i < columns; i++)
            {
                Console.Write("========");
            }
            Console.WriteLine("==\n");
        }

        // A method that types your string letter by letter.
        static void awesomeWrite(string text)
        {
            char[] letters = text.ToCharArray();
            foreach (char letter in letters)
            {
                System.Threading.Thread.Sleep(10);
                Console.Write(letter);
            }
        }

        // Overloaded method.  Allows you to change the speed that characters appear.  Bigger number = slower. 1 < speed < 100
        static void awesomeWrite(string text, int speed)
        {
            if (speed < 1 || speed > 100)
            {
                speed = 10;
            }
            char[] letters = text.ToCharArray();
            foreach (char letter in letters)
            {
                System.Threading.Thread.Sleep(speed);
                Console.Write(letter);
            }
        }
    }
}
