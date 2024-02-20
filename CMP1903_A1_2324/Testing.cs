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
        /*
         * This class should test the Game and the Die class.
         * Create a Game object, call the methods and compare their output to expected output.
         * Create a Die object and call its method.
         * Use debug.assert() to make the comparisons and tests.
         */

        //Method
        public int DieTesting()
        {
            Die dice1 = new Die();
            int die1value = dice1.Roll();
            Die dice2 = new Die();
            int die2value = dice2.Roll();
            Die dice3 = new Die();
            int dice3value = dice3.Roll();
            int dieTotal = die1value + die2value + dice3value;

            Debug.Assert(die1value <=6 && die1value >=1, "The dice rolled higher or lower than a 6 sided die can roll");
            //Debug.Assert(dieTotal >= 18 && dieTotal <= 3, "The total of the dies is outside the logical range");

            return die1value;
        }

        public int GameTesting()
        {
            Game testGame = new Game();
            Console.WriteLine("-------------------------------");
            int testGameTotal = testGame.DiceRolling();

            Debug.Assert(testGameTotal <= 18 && testGameTotal >= 3, "The total of the dies is outside the logical range");

            return testGameTotal;
        }


    }
}
