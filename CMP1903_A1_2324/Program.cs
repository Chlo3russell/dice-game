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

            Console.WriteLine("Welcome to the Dice Game!\nWould you like to play against;\n1. A friend or \n2.The computer?");
            // Getting an answer from the user, converting it to an integer and catching any format exceptions
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
                        Console.WriteLine("Invalid user input, please enter 1 or 2");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please input a number.");
                }

            }

            if (answer == 1)
            {
                // Getting the two players usernames
                Console.WriteLine("Player 1 - What is your username?");
                userName1 = Console.ReadLine();

                Console.WriteLine("Player 2 - What is your username?");
                userName2 = Console.ReadLine();
            }
            else
            {
                // Getting one username and setting the computer bool to true
                Console.WriteLine("Player 1 - What is your username?");
                userName1 = Console.ReadLine();
                userName2 = "Dice Bot";
                computer = true;
            }

            Console.WriteLine("What do you want to do?\n1. Play Sevens Out\n2. Play Three or More");
            bool repeat2 = true;
            int answer2 = 0;
            // Asking the user/s what game they want to play whilst catching any formatting errors
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
                        Console.WriteLine("Invalid user input, please enter 1 or 2");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please input a number.");
                }

            }
          
            if (answer2 == 1)
            {
                if (computer == false)
                {
                    // If the bool is false the constructor gets overloaded and this sets up the game to play with two players
                    // Here I am instantiating the SevensOut class
                    SevensOut sevensOut2Player = new SevensOut(userName1, userName2);
                }
                else
                {
                    // If the bool is true the constructor takes the one username 
                    // Here I am instantiating the SevensOut class
                    SevensOut sevensOut = new SevensOut(userName1);
                }
            }
            else 
            {
                if (computer == false)
                {
                    // If the bool is false the constructor gets overloaded and this sets up the game to play with two players
                    // Here I am instantiating the ThreeOrMore class
                    ThreeOrMore threeOrMore2Player = new ThreeOrMore(userName1, userName2);
                }
                else
                {
                    // If the bool is true the constructor takes the one username 
                    // Here I am instantiating the ThreeOrMore class 
                    ThreeOrMore threeOrMore = new ThreeOrMore(userName1);
                }
            
            }
        }
    }
}
