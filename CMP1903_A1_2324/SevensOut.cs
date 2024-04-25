using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Game
{
    internal class SevensOut : Game
    {
        // Properties

        private new int _playerOneScore;
        private new int _playerTwoScore;

        // Constructor 
        public SevensOut(string UserName)
        {
            _playerTotal = 0;

            _diceList = new List<Die>();
            for (int i = 0; i < 2; i++)
            {
                _diceList.Add(new Die());
            }

            userName = UserName;
            userName2 = computerUserName;
            base._isComputer = true;

            StartGame();
        }

        public SevensOut(string UserName, string UserName2)
        {
            _playerTotal = 0;

            _diceList = new List<Die>();
            for (int i = 0; i < 2; i++)
            {
                _diceList.Add(new Die());
            }

            userName = UserName;
            userName2 = UserName2;
            base._isComputer = false;

            StartGame();
        }

        //Methods
        protected override void StartGame()
        {
            if (base._isComputer)
            {
                int playerScore = RollTwoDie();

                Console.WriteLine("-------------------------------");

                int computerScore = ComputerRollTwoDie();

                Console.WriteLine("{0} finished the game with a total of {1}", userName, playerScore);
                Console.WriteLine("{0} finished the game with a total of {1}", userName2, computerScore);
                _statistics.WorstSevensOut(playerScore);
                _statistics.WorstSevensOut(computerScore);

                WhoWon(playerScore, base.userName, computerScore, computerUserName);
                _statistics.AddSevensOut();

                base.Menu();
            }
            else
            {
                int playerScore = RollTwoDie();

                Console.WriteLine("-------------------------------");

                int playerScore2 = RollTwoDie();

                Console.WriteLine("{0} finished the game with a total of {1}", userName, playerScore);
                Console.WriteLine("{0} finished the game with a total of {1}", userName2, playerScore2);
                _statistics.WorstSevensOut(playerScore);
                _statistics.WorstSevensOut(playerScore2);



                WhoWon(playerScore, base.userName, playerScore2, base.userName2);
                _statistics.AddSevensOut();


                base.Menu();
            }
        }

        public int RollTwoDie()
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

            Console.WriteLine("Your total is: {0}", total);

            SevenChecker(total, diceValues);

            return _playerTotal;
        }

        private int ComputerRollTwoDie()
        {
            int[] diceValues = new int[2];

            foreach (var die in _diceList)
            {
                int index = _diceList.IndexOf(die);
                int roll = die.Roll();
                diceValues[index] = roll;
            }

            int total = diceValues.Sum();
            ComputerSevenChecker(total, diceValues);

            return _playerTotal;
        }

        private void SevenChecker(int total, int[] diceValues)
        {
            if (total != 7)
            {
                if (diceValues[0] == diceValues[1])
                {
                    Console.WriteLine("Whoops you rolled a double... Har Har");
                    _playerTotal += (total * 2);
                    RollTwoDie();
                }
                else
                {
                    _playerTotal += total;
                }
                RollTwoDie();

            }

        }

        private void ComputerSevenChecker(int total, int[] diceValues)
        {
            if (total != 7)
            {
                if (diceValues[0] == diceValues[1])
                {
                    _playerTotal += (total * 2);
                    ComputerRollTwoDie();
                }
                else
                {
                    _playerTotal += total;
                    ComputerRollTwoDie();
                }
            }
        }

        private void WhoWon(int scoreOne, string userOne, int scoreTwo, string userTwo)
        {

            if (scoreOne == scoreTwo)
            {
                Console.WriteLine("You both drew, points for neither!");
            }
            else if (scoreOne < scoreTwo)
            {
                Console.WriteLine("{0} won with {1}", userName, scoreOne);
                _playerOneScore++;
            }
            else
            {
                Console.WriteLine("{0} won with {1}", userName2, scoreTwo);
                _playerTwoScore++;
            }
        }
    }
}
