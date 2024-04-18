using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Game
{
    internal abstract class Game
    {
        // Properties
        // In order: public , protected, then private

        public string userName;
        public string userName2;
        public string computerUserName = "Dice Bot";

        protected bool _isComputer;
        protected bool _isWinner;
        protected int _answer;
        protected int _playerTotal;
        protected List<Die> _diceList;

        private int _playerOneScore = 0;
        private int _playerTwoScore = 0;
        private int _playerOneGameScore;
        private int _playerTwoGameScore;

        // Constructors
        public Game()
        {

        }

        public Game(string UserName)
        {
            this.userName = UserName;
            this.userName2 = computerUserName;
            this._isComputer = true;
            Menu();
        }

        public Game(string UserName, string UserName2)
        {
            this.userName = UserName;
            this.userName2 = UserName2;
            this._isComputer = false;
            Menu();
        }


        //Methods
        protected void Menu()
        {
            Console.WriteLine("What do you want to do?\n1. Play Sevens Out\n2. Play Three or More\n3. View score\n4. New Game\n5. Quit game");
            bool repeat = true;

            while (repeat)
            {
                try
                {
                    _answer = Convert.ToInt32(Console.ReadLine());

                    if (_answer >= 1 || _answer <= 4)
                    {
                        repeat = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid user input, please enter a valid answer");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input string is not a sequence of digits.");
                }

                MenuChoice(_answer);
            }
        }

        private void MenuChoice(int answer)
        {

            switch (answer)
            {
                case 1:
                    if (_isComputer)
                    {
                        SevensOut sevensOut = new SevensOut();
                        int playerScore = sevensOut.RollTwoDie();

                        Console.WriteLine("-------------------------------");

                        SevensOut sevensOut2 = new SevensOut();
                        int computerScore = sevensOut2.ComputerRollTwoDie();

                        Console.WriteLine("{0} finished the game with a total of {1}", userName, playerScore);
                        Console.WriteLine("{0} finished the game with a total of {1}", computerUserName, computerScore);

                        WhoWon(playerScore, userName, computerScore, computerUserName);

                        Menu();
                    }
                    else
                    {
                        SevensOut sevensOut = new SevensOut();
                        int playerScore = sevensOut.RollTwoDie();

                        Console.WriteLine("-------------------------------");

                        SevensOut sevensOut2 = new SevensOut();
                        int playerScore2 = sevensOut2.RollTwoDie();

                        Console.WriteLine("{0} finished the game with a total of {1}", userName, playerScore);
                        Console.WriteLine("{0} finished the game with a total of {1}", userName2, playerScore2);

                        WhoWon(playerScore, userName, playerScore2, userName2);

                        Menu();
                    }
                    break;
                case 2:
                    _isWinner = false;

                    if (_isComputer)
                    {
                        while (_isWinner == false)
                        {
                            ThreeOrMore game1 = new ThreeOrMore();
                            _playerOneGameScore += game1.RollFiveDie(_playerOneGameScore);

                            if (_playerOneScore >= 20)
                            {
                                Console.WriteLine("Congrats {0}, you made it too {1}! You win!", userName, _playerOneScore);
                                _isWinner = true;
                                break;
                            }

                            Console.WriteLine("-------------------------------");

                            ThreeOrMore game2 = new ThreeOrMore();
                            _playerTwoScore += game1.RollFiveDie(_playerTwoScore);

                            if (_playerTwoScore >= 20)
                            {
                                Console.WriteLine("Congrats {0}, you made it too {1}! You win!", userName2, _playerTwoScore);
                                _isWinner = true;
                                break;
                            }

                        }
                    }
                    else
                    {
                        while (_isWinner == false)
                        {
                            ThreeOrMore game1 = new ThreeOrMore();
                            _playerOneScore += game1.RollFiveDie(_playerOneScore);

                            if (_playerOneScore >= 20)
                            {
                                Console.WriteLine("Congrats {0}, you made it too {1}! You win!", userName, _playerOneScore);
                                _isWinner = true;
                                break;
                            }

                            Console.WriteLine("-------------------------------");

                            ThreeOrMore game2 = new ThreeOrMore();
                            _playerTwoScore += game1.RollFiveDie(_playerTwoScore);

                            if (_playerTwoScore >= 20)
                            {
                                Console.WriteLine("Congrats {0}, you made it too {1}! You win!", userName2, _playerTwoScore);
                                _isWinner = true;
                                break;
                            }
                        }
                    }

                    Menu();


                    break;
                case 3:
                    Console.WriteLine("{0}'s score is {1} and {2}'s score is {3}", userName, _playerOneScore, userName2, _playerTwoScore);

                    if (_playerOneScore == _playerTwoScore)
                    {
                        Console.WriteLine("You are drawing with {0} pointa!", _playerOneScore);
                        Menu();
                    }
                    else if (_playerOneScore > _playerTwoScore)
                    {
                        Console.WriteLine("{0} is winning with {1}", userName, _playerOneScore);
                        Menu();
                    }
                    else
                    {
                        Console.WriteLine("{0} is winning with {1}", userName2, _playerTwoScore);
                        Menu();
                    }
                    break;
                case 4:
                    break;
                case 5:
                    Console.WriteLine("Please choose the new players");
                    break;
                default:
                    Console.WriteLine("Thanks for playing");
                    break;
            }


        }

        protected virtual void WhoWon(int scoreOne, string userOne, int scoreTwo, string userTwo)
        {
            if (scoreOne == scoreTwo)
            {
                Console.WriteLine("You both drew, points for neither!");
                Menu();
            }
            else if (scoreOne < scoreTwo)
            {
                Console.WriteLine("{0} won with {1}", userOne, scoreOne);
                _playerOneScore++;
                Menu();
            }
            else
            {
                Console.WriteLine("{0} won with {1}", userTwo, scoreTwo);
                _playerTwoScore++;
                Menu();
            }
        }

        protected virtual void WinnerChecker(int total, int[] diceValues)
        {
           
        }

    }
}
