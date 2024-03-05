using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Testing
    {

        // Testing constructor 
        public Testing() 
        {
            DieTesting();
            GameTesting();
        }

        /// <summary>
        /// This method tests the die class and checks that the value is between 1 - 6
        /// </summary>

        //Method
        public void DieTesting()
        {
            Die dice1 = new Die();
            int die1value = dice1.Roll();

            Debug.Assert(die1value <= 6 && die1value >= 1, "The dice rolled higher or lower than a 6 sided die can roll");
        }

        /// <summary>
        /// This method tests the Game class and checks that the total of the three die are within the logical 6 sided die range
        /// </summary>  

        public void GameTesting()
        {
            Game testGame = new Game();
            Console.WriteLine("-------------------------------");
            int testGameTotal = testGame.DiceRolling();

            Debug.Assert(testGameTotal <= 18 && testGameTotal >= 3, "The total of the dies is outside the logical range");
        }
    }
}
