using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Die
    {
        //Properties
        private int _diceValue { get; set; }
        private static Random Rand = new Random();

        /// <summary>
        /// The encaspulated _diceValue property stores the random value between 1 to 6 inclusive
        /// </summary>

        //Method
        public int Roll()
        {
            _diceValue = Rand.Next(1, 7);

            return _diceValue;
        }

    }
}
