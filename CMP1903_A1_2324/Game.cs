using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        // Properties
        // In order: public , protected, then private
        protected int noOf1s = 0;
        protected int noOf2s = 0;
        protected int noOf3s = 0;
        protected int noOf4s = 0;
        protected int noOf5s = 0;
        protected int noOf6s = 0;

        private int _diceRolls { get; set; }
        private int _diceValue { get; set; }
        private int _dieTotal { get; set; }
        private float _dieAverage { get; set; }

        // Methods

        /// <summary>
        /// DiceRolling creates three dice objects, displays the die number and the roll valueand  adds the three amounts to a running total
        /// </summary>
        /// <returns> The method returns the private dietotal </returns>
        public int DiceRolling()
        {
            // while 3 or less die have been created it continues to create and "Roll" new die objects
            while (_diceRolls != 3)
            {
                _diceRolls++; // Incrementing the counter by one 
                Die newDice = new Die(); // Instantiating the object
                Console.WriteLine("Dice {0} is {1}", _diceRolls, _diceValue = newDice.Roll()); // Outputting the number of dice rolled and the roll value
                Amounts();
                _dieTotal += _diceValue; // Adding the roll to the total
            }
            // Displaying the the total of the three dice
            Console.WriteLine("This is the total of your three dice rolls {0}", _dieTotal);

            return _dieTotal;
        }

        /// <summary>
        /// This method creates a loop for the user to continue rolling.
        /// It uses the private method of amounts to tally how many of each die value we get and calculates the average roll
        /// There is no return value for this method hence the void
        /// </summary>
        public void KeepRolling()
        {
            Console.WriteLine("------------------------------- \nDo you want to roll again, enter no to exit the loop?");
            // Two local variables 
            bool continueToRoll;
            string answer = Console.ReadLine();
            // Short hand if statement using the following syntax -- variable = (condition) ? expressionTrue :  expressionFalse;
            continueToRoll = answer == "no" ? continueToRoll = false : continueToRoll = true;
            // A while loop
            do
            {
                _diceRolls++; // Incremening the counter
                Die newDice = new Die(); // Instantiating a new object
                Console.WriteLine("Dice {0} is {1}", _diceRolls, _diceValue = newDice.Roll());
                Amounts(); // Calling the amounts methods
                _dieTotal += _diceValue; // Adding to the running total
                _dieAverage = _dieTotal / _diceRolls; // Finding the average
                Console.WriteLine("The total is {0} and the average roll is {1}", _dieTotal, _dieAverage);

                Console.WriteLine("------------------------------- \nDo you want to roll again, enter no to exit the loop?");
                answer = Console.ReadLine();
                continueToRoll = answer.ToLower() != "no";
            } while (continueToRoll);
        }

        /// <summary>
        /// A method to display the amount of rolls with that value
        /// </summary>
        public void DisplayAmounts()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Amount of 1s' {0}\nAmount of 2s' {1}\nAmount of 3s' {2}\nAmount of 4s' {3}\nAmount of 5s' {4}\nAmount of 6s' {5}", noOf1s, noOf2s, noOf3s, noOf4s, noOf5s, noOf6s);
        }

        /// <summary>
        /// The private method Amounts loops through cases 1 - 6 and increments the amounts by one.
        /// </summary>
        private void Amounts()
        {
            switch (_diceValue)
            {
                case 1:
                    noOf1s++;
                    break;
                case 2:
                    noOf2s++;
                    break;
                case 3:
                    noOf3s++;
                    break;
                case 4:
                    noOf4s++;
                    break;
                case 5:
                    noOf5s++;
                    break;
                case 6:
                    noOf6s++;
                    break;
                default:
                    break;

            }
        }
    }
}
