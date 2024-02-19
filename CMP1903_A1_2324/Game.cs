using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        //Properties
        private int _diceRolls {  get; set; }
        private int _diceValue { get; set; }
        private int _dieTotal {  get; set; }
        private float _dieAverage { get; set; }

        /// <summary>
        /// The method DieStats creates 3 die objects, uses the roll method and sums the total of the die.
        /// It then asks if you want to contimue rolling, and continues creating new objects, and totalling the total amount rolled
        /// </summary>

        // Method
        public void DiceRolling()
        {
            // while 3 or less die have been created it continues to create and "Roll" new die objects
            while (_diceRolls != 3)
            {
                _diceRolls++; // Incrementing the counter by one 
                Die newDice = new Die(); // Instantiating the object
                Console.WriteLine("Dice {0} is {1}", _diceRolls, _diceValue = newDice.Roll()); // Outputting the number of dice rolled and the roll value
                _dieTotal += _diceValue; // Adding the roll to the total
            }

            Console.WriteLine("This is the total of your three dice rolls {0}" , _dieTotal);
            Console.WriteLine("------------------------------- \nDo you want to roll again, enter no to exit the loop?");

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
    }
}
