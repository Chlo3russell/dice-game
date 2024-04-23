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
        protected int _answer;
        protected int _playerTotal;
        protected List<Die> _diceList;

        protected int _playerOneScore;
        protected int _playerTwoScore;
        protected int _playerOneGameScore;
        protected int _playerTwoGameScore;

        protected Statistics _statistics = new Statistics();

        // Constructors
        public Game()
        {

        }

        public Game(string UserName)
        {
           
        }

        public Game(string UserName, string UserName2)
        {

        }


        //Methods
        protected virtual void Menu()
        {
            Console.WriteLine("What do you want to do?\n1. Play Sevens Out\n2. Play Three or More\n3. View score\n4. View Total Game Stats\n5. Quit game or Change Players");
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

                switch (_answer)
                {
                    case 1:

                        if (_isComputer)
                        {
                            SevensOut sevensOut = new SevensOut(userName);
                        }
                        else
                        {
                            SevensOut sevensOut = new SevensOut(userName, userName2);
                        }
                        break;
                    case 2:
                        if (_isComputer)
                        {
                            ThreeOrMore threeOrMore = new ThreeOrMore(userName);
                        }
                        else
                        {
                            ThreeOrMore threeOrMore = new ThreeOrMore(userName, userName2);
                        }
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
                        _statistics.DisplayStatistics();
                        Menu();
                        break;
                    case 5:
                        Console.WriteLine("Please choose the new players");
                        break;
                    default:
                        Console.WriteLine("Thanks for playing");
                        break;
                }
            }
        }

        protected virtual void WhoWon(int scoreOne, string userOne, int scoreTwo, string userTwo)
        {
            
        }

        protected virtual void WinnerChecker(int total, int[] diceValues)
        {
           
        }

        protected virtual void StartGame()
        {

        }

    }
}
