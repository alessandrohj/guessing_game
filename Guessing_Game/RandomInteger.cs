//Alessandro de Jesus - April 20, 2021

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Guessing_Game
{
    class RandomInteger
    {
        //Class used to generate a random number
        protected Random random = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
        protected int currentRandomNumber = 0;

        public RandomInteger()
        {

        }

        public int GenerateRandomNumber()
        {
            //method used to generate a random number
            currentRandomNumber = random.Next();
            return currentRandomNumber;
        }

        public int GetCurrentRandomNumber() { return currentRandomNumber; }

    }
}