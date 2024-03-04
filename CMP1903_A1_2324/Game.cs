using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        //Properties
        private int _diceRolls { get; set; }
        private int _diceValue { get; set; }
        private int _dieTotal { get; set; }
        private float _dieAverage { get; set; }

        public int _noOf1s = 0;
        public int _noOf2s = 0;
        public int _noOf3s = 0;
        public int _noOf4s = 0;
        public int _noOf5s = 0;
        public int _noOf6s = 0;

        /// <summary>
        /// The method DieStats creates 3 die objects, uses the roll method and sums the total of the die.
        /// It then asks if you want to contimue rolling, and continues creating new objects, and totalling the total amount rolled
        /// </summary>

        // Method
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

        public void KeepRolling()
        {
            Console.WriteLine("------------------------------- \nDo you want to roll again, enter no to exit the loop?");
            // Defining a bool to create a condition for the while loop
            bool continueToRoll = true;
            string answer = Console.ReadLine();

            if (answer.ToLower() == "no")
            {
                continueToRoll = false;
            }

            while (continueToRoll == true) // The continous roller loopes until the input in no
            {
                _diceRolls++;
                //Creating a new object again
                Die newDice = new Die();
                Console.WriteLine("Dice {0} is {1}", _diceRolls, _diceValue = newDice.Roll());
                Amounts();
                // Die statistics
                _dieTotal += _diceValue;
                _dieAverage = _dieTotal / _diceRolls;
                Console.WriteLine("The total is {0} and the average roll is {1}", _dieTotal, _dieAverage);
                // Continuing the loop
                answer = Console.ReadLine();
                if (answer.ToLower() == "no")
                {
                    continueToRoll = false;
                }
            }
        }

        private void Amounts()
        {
            switch (_diceValue)
            {
                case 1:
                    _noOf1s++;
                    break;
                case 2:
                    _noOf2s++;
                    break;
                case 3:
                    _noOf3s++;
                    break;
                case 4:
                    _noOf4s++;
                    break;
                case 5:
                    _noOf5s++;
                    break;
                case 6:
                    _noOf6s++;
                    break;
                default:
                    break;
            }
        }

        public void DisplayAmounts()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Amount of 1s' {0}\nAmount of 2s' {1}\nAmount of 3s' {2}\nAmount of 4s' {3}\nAmount of 5s' {4}\nAmount of 6s' {5}", _noOf1s, _noOf2s, _noOf3s, _noOf4s, _noOf5s, _noOf6s);
        }

    }
}
