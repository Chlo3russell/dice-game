using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Game
{
    internal class SevensOut : Game
    {

        // Constructors
        public SevensOut()
        {
            _diceList = new List<Die>();
            for (int i = 0; i < 2; i++)
            {
                _diceList.Add(new Die());
            }
        }
        // The constructor sets up anything needed for the game
        public SevensOut(string UserName, string UserName2)
        {
            // Checking if the username is the default computer name, if true sets our _isComputer variable to true
            if (UserName2 == "Dice Bot")
            {
                _isComputer = true;
            }
            // Creating a list of die objects
            _diceList = new List<Die>();
            // Adding new die to this list 
            for (int i = 0; i < 2; i++)
            {
                _diceList.Add(new Die());
            }
            // Setting the parameters to the public properties
            this.userName = UserName;
            this.userName2 = UserName2;
            // Calling the StartGame method
            StartGame();
        }

        //Methods
        /// <summary>
        /// Ths method checks whether the total is seven.
        /// If it isn't it then works out the score using the diceValues
        /// </summary>
        /// <param name="total"> The total of the two rolls </param>
        /// <param name="diceValues"> The individual roll values </param>
        /// <returns> A bool, isSeven, to tell the rollTwoDie method to either continue rolling or stop</returns>
        public bool SevenChecker(int total, int[] diceValues)
        {
            bool isSeven = false;

            if (total != 7)
            {
                if (diceValues[0] == diceValues[1])
                {
                    _playerTotal += (total * 2);
                }
                else
                {
                    _playerTotal += total;
                }
            }
            else
            {
                isSeven = true;
            }
            return isSeven;
        }

        /// <summary>
        /// This is my overrided inherited method.
        /// It sets the players scores as zero, then the player total as zero
        /// Then it calls of the RollTwoDie method to get a total score for player one, and the same for player two (either player or computer)
        /// Then uses an if statement to determine the winner
        /// </summary>
        protected override void StartGame()
        {
            int playerScore = 0;
            int playerScore2 = 0;

            _playerTotal = 0;
            Console.WriteLine($"{userName}, it is your turn");
            playerScore = RollTwoDie();
            Console.WriteLine("-------------------------------");

            if (base._isComputer)
            {
                _playerTotal = 0;
                playerScore2 = RollTwoDie(_isComputer);
            }
            else
            {
                _playerTotal = 0;
                Console.WriteLine($"{userName2}, it is your turn");
                playerScore2 = RollTwoDie();
            }

            Console.WriteLine("{0} finished the game with a total of {1}", userName, playerScore);
            Console.WriteLine("{0} finished the game with a total of {1}", userName2, playerScore2);

            if (playerScore == playerScore2)
            {
                Console.WriteLine("You both drew!");
            }
            else if (playerScore > playerScore2)
            {
                Console.WriteLine("{0} won with {1}", userName, playerScore);
                _statistics.BestSevensOut(playerScore);
            }
            else
            {
                Console.WriteLine("{0} won with {1}", userName2, playerScore2);
                _statistics.BestSevensOut(playerScore2);
            }
            _statistics.AddSevensOut();
            base.Menu();
        }

        /// <summary>
        /// These method creates an array of integers, and then loops through the die in _diceList
        /// Rolls the die then adds the value to the array
        /// </summary>
        /// <returns> The players overalll score </returns>
        private int RollTwoDie()
        {
            int[] diceValues = new int[2];
            Console.WriteLine("Click anything to roll...");
            Console.ReadLine();

            Console.WriteLine("You rolled a: ");
            foreach (var die in _diceList)
            {
                int index = _diceList.IndexOf(die);
                int roll = die.Roll();
                diceValues[index] = roll;
                Console.WriteLine(diceValues[index]);
            }

            int total = diceValues.Sum();
            bool isSeven = SevenChecker(total, diceValues);

            if (isSeven == false)
            {
                RollTwoDie();
            }

            return _playerTotal;
        }

        private int RollTwoDie(bool computer)
        {
            int[] diceValues = new int[2];

            foreach (var die in _diceList)
            {
                int index = _diceList.IndexOf(die);
                int roll = die.Roll();
                diceValues[index] = roll;
            }

            int total = diceValues.Sum();
            bool isSeven = SevenChecker(total, diceValues);

            if (isSeven == false)
            {
                RollTwoDie(_isComputer);
            }

            return _playerTotal;
        }
    }
}
