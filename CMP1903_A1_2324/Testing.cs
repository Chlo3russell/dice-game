using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Game
{
    internal class Testing
    {
        private string _user1 = "User 1";
        private string _user2 = "User 2";

        private int _playerTotal;

        // Testing constructor 
        public Testing() 
        {
            Console.WriteLine("Testing started");

            SevensOutTest();
            ThreeOrMoreTest();
        }

        //Method

        // Could use 
        private void SevensOutTest()
        {
            SevensOut sevensOut = new SevensOut(_user1, _user2);
            _playerTotal = sevensOut.RollTwoDie();

            Debug.Assert(_playerTotal <= 6 && _playerTotal >= 1, "The dice rolled higher or lower than a 6 sided die can roll");
        }
        
        private void ThreeOrMoreTest()
        {
            ThreeOrMore threeOreMore = new ThreeOrMore(_user1, _user2);
        }
        
    }
}
