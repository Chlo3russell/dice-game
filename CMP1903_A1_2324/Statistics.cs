using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dice_Game
{
    internal class Statistics
    {
        // Properties

        public int totalGameScore;
        public int playerOneScore;
        public int playerTwoScore;

        private int _amountOfGamesEver;
        private int _sevensOutWorstGame;
        private int _totalGamesPlayed;

        private string _filePathway = "C:\\Users\\chloe\\source\\repos\\dice-game\\CMP1903_A1_2324\\GameHighScores.txt";
        private string[] _arrayOfLines;

        //Constructor

        public Statistics() 
        {
            _arrayOfLines = File.ReadAllLines(_filePathway);
        }


        //Methods
        public void AddThreeOrMore()
        {
            int numberToIncrease = Int32.Parse(_arrayOfLines[7]);
            numberToIncrease += 1;

            _arrayOfLines[7] = numberToIncrease.ToString();
            File.WriteAllLines(_filePathway, _arrayOfLines);
        }

        public void AddSevensOut()
        {
            int numberToIncrease = Int32.Parse(_arrayOfLines[5]);
            numberToIncrease += 1;

            _arrayOfLines[5] = numberToIncrease.ToString();
            File.WriteAllLines(_filePathway, _arrayOfLines);
        }

        public void WorstThreeOrMore(int amountOfRounds)
        {

            int currentReccord = Int32.Parse(_arrayOfLines[12]);

            if (currentReccord <= amountOfRounds)
            {
                currentReccord = amountOfRounds;
            }

            _arrayOfLines[12] = currentReccord.ToString();
            File.WriteAllLines(_filePathway, _arrayOfLines);
        }

        public void WorstSevensOut(int playerScore)
        {
            int currentReccord = Int32.Parse(_arrayOfLines[10]);

            if (currentReccord <= playerScore)
            {
                currentReccord = playerScore;
            }
  
            _arrayOfLines[10] = currentReccord.ToString();
            File.WriteAllLines(_filePathway, _arrayOfLines);
        }

        public void DisplayStatistics()
        {
            int numberOfGames = Int32.Parse(_arrayOfLines[5]);
            int numberOfGames2 = Int32.Parse(_arrayOfLines[7]);

            int numberToAdd = numberOfGames + numberOfGames2;

            _arrayOfLines[3] = numberToAdd.ToString();
            File.WriteAllLines(_filePathway, _arrayOfLines);

            string line;

            try
            {

                StreamReader textReader = new StreamReader(_filePathway);
                line = textReader.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    line = textReader.ReadLine();
                }

                textReader.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void Wipe()
        {
            Console.WriteLine("Wiped ALL SCORES :((");

            int numberToChange = 0;
            int numberToChange1 = 0;
            int numberToChange2 = 0;
            int numberToChange3 = 0;

            _arrayOfLines[5] = numberToChange.ToString();
            _arrayOfLines[7] = numberToChange1.ToString();
            _arrayOfLines[10] = numberToChange2.ToString();
            _arrayOfLines[12] = numberToChange3.ToString();

            File.WriteAllLines(_filePathway, _arrayOfLines);

        }
    }
}
