using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Game
{
    internal class Die
    {
        //Properties
        private int _diceValue { get; set; }
        private static Random Rand = new Random();

        /// <summary>
        /// The encaspulated _diceValue property stores the random value between 1 to 6 inclusive
        /// </summary>
        /// <returns> The Roll methods returns the value of the dice </returns>

        //Method
        public int Roll()
        {
            _diceValue = Rand.Next(1, 7);
            // I have overloaded the random method .Next with a min and a max (1 and 7). The range works like this -- min<= value <max
            return _diceValue;
        }

    }
}
