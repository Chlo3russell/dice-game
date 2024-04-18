using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Dice Game!\nWould you like to play against a friend or the computer?");
            bool repeat = true;
            int answer = 0;

            while (repeat)
            {
                try
                {
                    answer = Convert.ToInt32(Console.ReadLine());

                    if (answer == 1 || answer == 2)
                    {
                        repeat = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid user input, please enter a valid answer");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input string is not a sequence of digits.");
                }

            }
            
            if (answer == 1)
            {
                Console.WriteLine("Player 1 - What is your username?");
                string userName1 = Console.ReadLine();

                Console.WriteLine("Player 2 - What is your username?");
                string userName2 = Console.ReadLine();


                // Creating an instance of the class Game
                Game newGame = new Game(userName1, userName2);



            }
            else
            {
                Console.WriteLine("Player 1 - What is your username?");
                string userName1 = Console.ReadLine();

                Game npcGame = new Game(userName1);
            }

            Console.ReadLine();

        }

    }
}
