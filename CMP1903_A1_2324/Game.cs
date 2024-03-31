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

        private int _diceValue { get; set; }
        private int _dieTotal { get; set; }
        private float _dieAverage { get; set; }


        // Methods

        /// <summary>
        /// DiceRolling creates three dice objects, displays the die number and the roll valueand  adds the three amounts to a running total
        /// </summary>
        /// <returns> The method returns the private die value </returns>
        public int RollDice()
        {
            
            Die newDice = new Die(); // Instantiating the object
            Console.WriteLine("Your roll equals {0}", _diceValue = newDice.Roll()); // Outputting the number of dice rolled and the roll value
            
            return _dieTotal;
        }

    }
}
