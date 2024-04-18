using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dice_Game
{
    internal class ThreeOrMore : Game
    {
        // Properties
        //private bool _isWinner;
        private int _playerOneScore { get; set; }
        private int _playerTwoScore { get; set; }

        // Constructor
        public ThreeOrMore() 
        {
            _playerTotal = 0;
            _isWinner = false;


            _diceList = new List<Die>();
            for (int i = 0; i < 5; i++)
            {
                _diceList.Add(new Die());
            }

            /*if (base._isComputer)
            {
                while (_isWinner == false)
                {
                    _playerOneScore += RollFiveDie(_playerOneScore);

                    if (_playerOneScore >= 20)
                    {
                        Console.WriteLine("Congrats {0}, you made it too {1}! You win!", userName, _playerOneScore);
                        _isWinner = true;
                        break;
                    }

                    Console.WriteLine("-------------------------------");

                    _playerTwoScore += RollFiveDie(_playerTwoScore);

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
                    _playerOneScore += RollFiveDie(_playerOneScore);

                    if (_playerOneScore >= 20)
                    {
                        Console.WriteLine("Congrats {0}, you made it too {1}! You win!", userName, _playerOneScore);
                        _isWinner = true;
                        break;
                    }

                    Console.WriteLine("-------------------------------");

                    _playerTwoScore += RollFiveDie(_playerTwoScore);

                    if (_playerTwoScore >= 20)
                    {
                        Console.WriteLine("Congrats {0}, you made it too {1}! You win!", userName2, _playerTwoScore);
                        _isWinner = true;
                        break;
                    }
                }
            }

            base.Menu();*/

        }

        // Methods

        protected override void WinnerChecker(int total, int[] diceValues)
         {
            
            
         }


        public int RollFiveDie(int playerScore)
        {

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

            playerScore += AnyMultiples(diceValues);

            return playerScore;

        }


        private int AnyMultiples(int[] diceValues)
        {
            int playerScore = 0;
            int noOf1 = 0, noOf2 = 0, noOf3 = 0, noOf4 = 0, noOf5 = 0, noOf6 = 0;

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
                Console.WriteLine("YATZEE");
                playerScore = 12;
            }
            else if ((noOf1 == 4) || (noOf2 == 4) || (noOf3 == 4) || (noOf4 == 4) || (noOf5 == 4) || (noOf6 == 4))
            {
                Console.WriteLine("4 of a kind... nice");
                playerScore = 6;
            }
            else if ((noOf1 == 3) || (noOf2 == 3) || (noOf3 == 3) || (noOf4 == 3) || (noOf5 == 3) || (noOf6 == 3))
            {
                Console.WriteLine("3 of a kind!");
                playerScore = 3;
            }

            return playerScore;

        }


        /*
    If 2-of-a-kind is rolled, player may choose to rethrow all, or the remaining dice.
	3-of-a-kind: 3 points
	4-of-a-kind: 6 points
	5-of-a-kind: 12 points
	First to a total of 20.
         */




    }
}
