using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Game
{
    internal class SevensOut : Game
    {

        // Constructor 
        public SevensOut()
        {

            _playerTotal = 0;


            _diceList = new List<Die>();
            for (int i = 0; i < 2; i++)
            {
                _diceList.Add(new Die());
            }

            /*if (base._isComputer)
            {
                int playerScore = RollTwoDie();

                Console.WriteLine("-------------------------------");

                int computerScore = ComputerRollTwoDie();

                Console.WriteLine("{0} finished the game with a total of {1}", userName, playerScore);
                Console.WriteLine("{0} finished the game with a total of {1}", computerUserName, computerScore);

                base.WhoWon(playerScore, userName, computerScore, computerUserName);
                base.Menu();
            }
            else
            {
                int playerScore = RollTwoDie();

                Console.WriteLine("-------------------------------");

                int playerScore2 = RollTwoDie();

                Console.WriteLine("{0} finished the game with a total of {1}", userName, playerScore);
                Console.WriteLine("{0} finished the game with a total of {1}", userName2, playerScore2);

                base.WhoWon(playerScore, userName, playerScore2, userName2);

                base.Menu();
            }*/

            // shorten this no another method

        }

        public SevensOut(int pNumber, string uName)
        {
            base.userName = uName;

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

            WinnerChecker(total, diceValues);

            return _playerTotal;
        }

        protected override void WinnerChecker(int total, int[] diceValues)
        {
            if (total == 7)
            {
                Console.WriteLine("Winner Winner!");
            }
            else
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
                    RollTwoDie();
                }
            }
        }


        public int ComputerRollTwoDie()
        {
            int[] diceValues = new int[2];
            
            foreach (var die in _diceList)
            {
                int index = _diceList.IndexOf(die);
                int roll = die.Roll();
                diceValues[index] = roll;
            }

            int total = diceValues.Sum();
            ComputerWinnerChecker(total, diceValues);

            return _playerTotal;
        }

        private void ComputerWinnerChecker(int total, int[] diceValues)
        {
            if (total == 7)
            {
                
            }
            else
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

    }
}
