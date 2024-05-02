using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dice_Game
{
    internal class ThreeOrMore : Game
    {
        // Properties
        private bool _isWinner;

        private new int _playerOneScore;
        private new int _playerTwoScore;

        private List<Die> _threeDiceList;
        private int _amountOfRounds {  get; set; }

        // Constructors
        public ThreeOrMore()
        {
            _diceList = new List<Die>();
            for (int i = 0; i < 5; i++)
            {
                _diceList.Add(new Die());
            }

            _threeDiceList = new List<Die>();
            for (int i = 0; i < 3; i++)
            {
                _threeDiceList.Add(new Die());
            }
        }
        // The constructor sets up anything needed for the game
        public ThreeOrMore(string UserName, string UserName2)
        {
            // Checking if the username is the default computer name, if true sets our _isComputer variable to true
            if (UserName2 == "Dice Bot")
            {
                _isComputer = true;
            }
            // Resetting the scores
            _playerOneScore = 0;
            _playerTwoScore = 0;
            _isWinner = false;
            // Creating a list of die objects
            _diceList = new List<Die>();
            // Adding new die to this list
            for (int i = 0; i < 5; i++)
            {
                _diceList.Add(new Die());
            }

            _threeDiceList = new List<Die>();
            for (int i = 0; i < 3; i++)
            {
                _threeDiceList.Add(new Die());
            }
            // Setting the paramters to the properties
            this.userName = UserName;
            this.userName2 = UserName2;
            // Calling my StartGame method
            StartGame();
        }

        // Methods
        /// <summary>
        /// This is my public multiple checker, it uses LINQ to check for multiples
        /// It will either allocate the score or call the KeepDouble method
        /// </summary>
        /// <param name="user"> I pass the username here to be able to create my computer player</param>
        /// <returns> The rolls score </returns>
        public int AnyMultiples(int[] diceValues, string user)
        {
            int playerScore = 0;
            // Using LINQ to group my rolls into seperate groups by value and then convert the groups to a dictoary and getting the total count
            var diceCounts = diceValues.GroupBy(x => x)
                           .ToDictionary(g => g.Key, g => g.Count());

            if (diceCounts.ContainsValue(5))
            {
                playerScore = 12;
            }
            else if (diceCounts.ContainsValue(4))
            {
                playerScore = 6;
            }
            else if (diceCounts.ContainsValue(3))
            {
                playerScore = 3;
            }
            else if (diceCounts.ContainsValue(2))
            {
                // Using LINQ again to find the first keyvalue with a value of two
                var diceWithValueTwo = diceCounts.First(kv => kv.Value == 2).Key;

                if (_isComputer && user == "Dice Bot")
                {
                    playerScore = ComputerRollFiveDie(user);
                }
                else
                {
                    // If the player is a not a computer, It creates a new array with the two keyvalue pairs.
                    playerScore = KeepTwoDice(new[] { diceWithValueTwo, diceWithValueTwo }, user);
                }
            }

            return playerScore;
        }
        /// <summary>
        /// Again overrrided inherited method.
        /// While _isWinner equals false it will continue to rollFiveDie until a users score is over 20 
        /// </summary>
        protected override void StartGame()
        {
            _amountOfRounds = 0;

            while (_isWinner == false)
            {
                Console.WriteLine("{0}, its your turn...", userName);
                _playerOneScore += RollFiveDie(userName);
                Console.WriteLine("{0} your current score is {1}", userName, _playerOneScore);

                if (_playerOneScore >= 20)
                {
                    Console.WriteLine("Congrats {0}, you made it too {1}! You win!", userName, _playerOneScore);
                    _isWinner = true;
                    break;
                }

                Console.WriteLine("-------------------------------");

                if (_isComputer == true)
                {
                    _playerTwoScore += ComputerRollFiveDie(userName2);
                    Console.WriteLine("{0} score is {1}", userName2, _playerTwoScore);
                }
                else
                {
                    Console.WriteLine("{0}, its your turn...", userName2);
                    _playerTwoScore += RollFiveDie(userName2);
                    Console.WriteLine("{0} your current score is {1}", userName2, _playerTwoScore);
                }

                if (_playerTwoScore >= 20)
                {
                    Console.WriteLine("Congrats {0}, you made it too {1}! You win!", userName2, _playerTwoScore);
                    _isWinner = true;
                    break;
                }

                Console.WriteLine("-------------------------------");

            }

            _statistics.AddThreeOrMore();
            _statistics.LongestThreeOrMore(_amountOfRounds);
            base.Menu();
        }
        /// <summary>
        /// These method creates an array of integers, and then loops through the die in _diceList
        /// Rolls the die then adds the value to the array
        /// </summary>
        /// <param name="user"> I need to pass the username here for the AnyMultiples </param>
        /// <returns> It returns the players score </returns>
        private int RollFiveDie(string user)
        {
            int playerScore = 0;

            int[] diceValues = new int[5];
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

            playerScore = AnyMultiples(diceValues, user);

            return playerScore;

        }
        private int ComputerRollFiveDie(string user)
        {
            int playerScore = 0;

            int[] diceValues = new int[5];

            Console.WriteLine("Dice Bot rolled: ");
            foreach (var die in _diceList)
            {
                int index = _diceList.IndexOf(die);
                int roll = die.Roll();
                diceValues[index] = roll;
                Console.WriteLine(diceValues[index]);
            }

            playerScore = AnyMultiples(diceValues, user);

            return playerScore;
        }
        /// <summary>
        /// This creates an array of integers, and then loops through the die in _diceList
        /// Rolls the die then adds the value to the array
        /// Then concatanates the two arrays for the AnyMultiplies
        /// </summary>
        private int RollThreeDie(int[] doubleDie, string user)
        {
            int playerScore = 0;

            int[] diceValues = new int[3];

            Console.WriteLine("You rolled a: ");
            foreach (var die in _threeDiceList)
            {
                int index = _threeDiceList.IndexOf(die);
                int roll = die.Roll();
                diceValues[index] = roll;
            }

            int[] fiveDie = doubleDie.Concat(diceValues).ToArray();

            foreach (var die in fiveDie)
            {
                Console.WriteLine(die);
            }

            playerScore = AnyMultiples(fiveDie, user);

            return playerScore;
        }

        /// <summary>
        /// Asks the user whether or not they would like to keep the double
        /// </summary>
        private int KeepTwoDice(int[] listOfDiceValues, string user)
        {
            Console.WriteLine("You rolled a double, would you like to;\n1. Re-roll all of them or, \n2. Keep the double? ");

            int playerScore = 0;
            bool repeat = true;
            int answer = 0;

            while (repeat)
            {
                try
                {
                    answer = Convert.ToInt32(Console.ReadLine());

                    if (answer == 1 || answer == 2)
                    {
                        repeat = false;
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid option! Please choose again!");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input string is not a sequence of digits.");
                }
            }
            if (answer == 1)
            {
                playerScore = RollFiveDie(user);
            }
            else
            {
                playerScore = RollThreeDie(listOfDiceValues, user);
            }

            return playerScore;
        }
    }
}
