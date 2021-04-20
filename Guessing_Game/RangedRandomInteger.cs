//Alessandro de Jesus - April 20, 2021
using System;
namespace Guessing_Game
{
     class RangedRandomInteger : RandomInteger
    {
        private int randomValue = 1;
        private int minimum = 1;
        private int maximum = 1000;

        public RangedRandomInteger() //default constructor
        {

        }

        public RangedRandomInteger(int min, int max) //overload constructor
        {
            setMinimum(min);
            setMaximum(max);
        
        }

        public new int GenerateRandomNumber()
        {
            randomValue = random.Next(minimum, maximum);
            return randomValue;
        }


        public void setMinimum(int min)
        {
            if (min >= minimum) this.minimum = min;
        }

        public void setMaximum(int max)
        {
            if (max <= maximum) this.maximum = max;
        }

        public int getMinimum() { return minimum; }
        public int getMaximum() { return maximum; }
    }
}
