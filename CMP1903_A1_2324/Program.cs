using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating an instance of the class Game
            Game newGame = new Game();
            // Using the method DiceRolling to roll the "dice"
            newGame.RollDice();
            // Testing the classes with debug.assert
            Testing test1 = new Testing();
        }

    }
}
