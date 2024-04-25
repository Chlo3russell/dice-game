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
        public ThreeOrMore(string UserName)
        {
            _playerOneScore = 0;
            _playerTwoScore = 0;
            _isWinner = false;

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

            this.userName = UserName;
            this.userName2 = base.computerUserName;
            this._isComputer = true;

            StartGame();
        }

        public ThreeOrMore(string UserName, string UserName2)
        {
            _playerOneScore = 0;
            _playerTwoScore = 0;
            _isWinner = false;

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

            userName = UserName;
            userName2 = UserName2;
            base._isComputer = false;

            StartGame();
        }

        // Methods

        public int RollFiveDie(string user)
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

        public int RollThreeDie(int[] doubleDie, string user)
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

        public int ComputerRollFiveDie(string user)
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

        private int AnyMultiples(int[] diceValues, string user)
        {
            int playerScore = 0;
            int noOf1 = 0, noOf2 = 0, noOf3 = 0, noOf4 = 0, noOf5 = 0, noOf6 = 0;
            _amountOfRounds++;

            for (int i = 0; i < diceValues.Length; i++)
            {
                switch (diceValues[i])
                {
                    case 1:
                        noOf1++;
                        break;
                    case 2:
                        noOf2++;
                        break;
                    case 3:
                        noOf3++;
                        break;
                    case 4:
                        noOf4++;
                        break;
                    case 5:
                        noOf5++;
                        break;
                    case 6:
                        noOf6++;
                        break;
                }
            }

            if ((noOf1 == 5) || (noOf2 == 5) || (noOf3 == 5) || (noOf4 ==  5) || ( noOf5 == 5) || (noOf6 == 5))
            {
                playerScore = 12;
            }
            else if ((noOf1 == 4) || (noOf2 == 4) || (noOf3 == 4) || (noOf4 == 4) || (noOf5 == 4) || (noOf6 == 4))
            {
                playerScore = 6;
            }
            else if ((noOf1 == 3) || (noOf2 == 3) || (noOf3 == 3) || (noOf4 == 3) || (noOf5 == 3) || (noOf6 == 3))
            {
                playerScore = 3;
            }
            else if ((noOf1 == 2) || (noOf2 == 2) || (noOf3 == 2) || (noOf4 == 2) || (noOf5 == 2) || (noOf6 == 2))
            {
                if ((_isComputer == true) && (user == "Dice Bot"))
                {
                    playerScore = ComputerRollFiveDie(user);
                }
                else
                {
                    playerScore = KeepTwoDice(diceValues, user);
                }
            }

            return playerScore;
        }

        private int KeepTwoDice(int[] listOfDiceValues, string user )
        {
            Console.WriteLine("You rolled a double: ");
            Console.WriteLine("Would you like to;\n1. Re-roll all of them or, \n2. Keep the double?");

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
                int noOf1 = 0, noOf2 = 0, noOf3 = 0, noOf4 = 0, noOf5 = 0, noOf6 = 0;
                bool diceAppearedTwice = false;

                for (int i = 0; i < listOfDiceValues.Length; i++)
                {
                    switch (listOfDiceValues[i])
                    {
                        case 1:
                            noOf1++;
                            if (noOf1 == 2 && diceAppearedTwice == false)
                            {
                                int[] newArray = { 1, 1};
                                playerScore = RollThreeDie(newArray, user);
                                diceAppearedTwice = true;
                            }
                            break;
                        case 2:
                            noOf2++;
                            if (noOf2 == 2 && diceAppearedTwice == false)
                            {
                                int[] newArray = { 2, 2 };
                                playerScore = RollThreeDie(newArray, user);
                                diceAppearedTwice = true;
                            }
                            break;
                        case 3:
                            noOf3++;
                            if (noOf3 == 2 && diceAppearedTwice == false)
                            {
                                int[] newArray = { 3, 3 };
                                playerScore = RollThreeDie(newArray, user);
                                diceAppearedTwice = true;
                            }
                            break;
                        case 4:
                            noOf4++;
                            if (noOf4 == 2 && diceAppearedTwice)
                            {
                                int[] newArray = { 4, 4 };
                                playerScore = RollThreeDie(newArray, user);
                                diceAppearedTwice = true;
                            }
                            break;
                        case 5:
                            noOf5++;
                            if (noOf5 == 2 && diceAppearedTwice == false)
                            {
                                int[] newArray = { 5, 5 };
                                playerScore = RollThreeDie(newArray, user);
                                diceAppearedTwice = true;
                            }
                            break;
                        case 6:
                            noOf6++;
                            if (noOf6 == 2 && diceAppearedTwice == false)
                            {
                                int[] newArray = { 6, 6 };
                                playerScore = RollThreeDie(newArray, user);
                                diceAppearedTwice = true;
                            }
                            break;
                    }
                }
            }

            return playerScore;
        }

        protected override void StartGame()
        {
            _amountOfRounds = 0;

            if (base._isComputer)
            {
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

                    _playerTwoScore += ComputerRollFiveDie(userName2);
                    Console.WriteLine("{0} score is {1}", userName2, _playerTwoScore);

                    if (_playerTwoScore >= 20)
                    {
                        Console.WriteLine("Congrats {0}, you made it too {1}! You win!", userName2, _playerTwoScore);
                        _isWinner = true;
                        break;
                    }

                    Console.WriteLine("-------------------------------");

                }
                _statistics.AddThreeOrMore();
                _statistics.WorstThreeOrMore(_amountOfRounds);
            }
            else
            {
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

                    Console.WriteLine("{0}, its your turn...", userName2);
                    _playerTwoScore += RollFiveDie(userName2);
                    Console.WriteLine("{0} your current score is {1}", userName2, _playerTwoScore);

                    if (_playerTwoScore >= 20)
                    {
                        Console.WriteLine("Congrats {0}, you made it too {1}! You win!", userName2, _playerTwoScore);
                        _isWinner = true;
                        break;
                    }

                    Console.WriteLine("-------------------------------");

                }
                _statistics.AddThreeOrMore();
                _statistics.WorstThreeOrMore(_amountOfRounds);
            }

            base.Menu();
        }
    }
}
