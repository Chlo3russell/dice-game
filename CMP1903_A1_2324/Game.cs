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
        // In order: public, protected, private
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

        public Game(string UserName, string UserName2)
        {

        }

        //Methods
        // Any methods that both the games share that cannot have a default value I have set to abstract
        protected abstract void StartGame();

        // Any methods that both games share, that can be overloaded I have given the virtual keyword
        /// <summary>
        /// The Menu Method is the base for both games, it is how both games share the the usernames and the computer values
        /// </summary>
        protected virtual void Menu()
        {
            Console.WriteLine("What do you want to do?\n1. Play Sevens Out\n2. Play Three or More\n3. View Game Stats\n4. Test the Game\n5. Quit game");
            bool repeat = true;
            // Getting an answer whilst error checking to make sure it is an integer
            while (repeat)
            {
                try
                {
                    _answer = Convert.ToInt32(Console.ReadLine());

                    if (_answer >= 1 && _answer <= 5)
                    {
                        repeat = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid user input, please enter a number betweeen 1 - 5");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a number.");
                }
                // Switch statment which iterates through all the options
                switch (_answer)
                {
                    case 1:
                        SevensOut sevensOut = new SevensOut(userName, userName2);
                        break;
                    case 2:
                        ThreeOrMore threeOrMore = new ThreeOrMore(userName, userName2);
                        break;
                    case 3:
                        _statistics.DisplayStatistics();
                        Menu();
                        break;
                    case 4:
                        Testing newTest = new Testing(userName);
                        Menu();
                        break;
                    case 5:
                        Console.WriteLine("Thanks for Playing!");
                        Console.ReadLine();
                        break;
                }
            }
        }

    }
}
