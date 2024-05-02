using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dice_Game
{
    internal class Testing
    {
        private string _userName;
        private string _filePathway = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CMP1903_A1_2324/TestingLog.txt");

        private string[] _arrayOfLines;

        // Testing constructor 
        public Testing(string UserName) 
        {
            UserName = _userName;

            Console.WriteLine("Testing started");

            _arrayOfLines = File.ReadAllLines(_filePathway);

            SevensOutTest();
            ThreeOrMoreTest();
            DisplayTests();

        }

        //Method

        // Could use 
        private void SevensOutTest()
        {
            SevensOut sevensOutTest = new SevensOut();

            int[] exampleList = { 3, 4 };
            int dieTotal = exampleList.Sum();


            Console.WriteLine($"Testing the SevenChecker with a total roll value of {dieTotal} and a list of {exampleList}");
            bool isSeven = sevensOutTest.SevenChecker(dieTotal, exampleList);
            Debug.Assert(isSeven == true, " The Seven Checker is not working as expected");

            string[] stringToAdd = { $"{DateTime.Now} - The SevensOut class was tested by {_userName}" };
            string[] twoArrays = _arrayOfLines.Concat(stringToAdd).ToArray(); 

            File.WriteAllLines(_filePathway, twoArrays);
        }
        
        private void ThreeOrMoreTest()
        {

            ThreeOrMore threeOrMoreTest = new ThreeOrMore();

            int[] exampleList = { 5, 5, 5, 5, 5 };
            string user = "test";

            Console.WriteLine($"Testing the ThreeOrMore with a 5 of a kind and a username of {user}");
            int score = threeOrMoreTest.AnyMultiples(exampleList, user);
            Debug.Assert(score == 12, " The Seven Checker is not working as expected");

            int[] exampleList2 = { 5, 5, 5, 4, 2 };
            Console.WriteLine($"Testing the ThreeOrMore with a 3 of a kind and a username of {user}");
            int score2 = threeOrMoreTest.AnyMultiples(exampleList2, user);
            Debug.Assert(score2 == 3, " The Seven Checker is not working as expected");

            string[] stringToAdd = { $"{DateTime.Now} - The ThreeOrMore class was tested by {_userName}" };
            string[] twoArrays = _arrayOfLines.Concat(stringToAdd).ToArray();

            File.WriteAllLines(_filePathway, twoArrays);
        }

        public void DisplayTests()
        {
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
    }
}
