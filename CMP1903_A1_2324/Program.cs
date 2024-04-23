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
            
            bool computer = false;
            bool repeat = true;
            int answer = 0;
            string userName1;
            string userName2;

            Console.WriteLine("Welcome to the Dice Game!\nWould you like to play against;\n1. friend or \n2.The computer?");

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
                userName1 = Console.ReadLine();

                Console.WriteLine("Player 2 - What is your username?");
                userName2 = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Player 1 - What is your username?");
                userName1 = Console.ReadLine();
                userName2 = "Dice Bot";
                computer = true;
            }

            Console.WriteLine("What do you want to do?\n1. Play Sevens Out\n2. Play Three or More");
            bool repeat2 = true;
            int answer2 = 0;

            while (repeat2)
            {
                try
                {
                    answer2 = Convert.ToInt32(Console.ReadLine());

                    if (answer2 == 1 || answer2 == 2)
                    {
                        repeat2 = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid user input, please enter a valid answer hehe");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input string is not a sequence of digits.");
                }

            }

            if (answer2 == 1)
            {
                if (computer == false)
                {
                    SevensOut sevensOut2Player = new SevensOut(userName1, userName2);
                }
                else
                {
                    SevensOut sevensOut = new SevensOut(userName1);
                }
            }
            else 
            {
                if (computer == false)
                {
                    ThreeOrMore threeOrMore2Player = new ThreeOrMore(userName1, userName2);
                }
                else
                {
                    ThreeOrMore threeOrMore = new ThreeOrMore(userName1);
                }
            
            }
            Console.ReadLine();


        }

    }
}
