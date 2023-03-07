using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        //Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
        //The 'set' methods for these properties could have some validation
        public int Value { get; set; }
        public int Suit { get; set; }

        public Card (int v, int s)
        {
            if (v > 13 || v < 1)
            {
                throw new ArgumentOutOfRangeException("Value must be in the range of 1-13 (inclusive).");
            }

            if (s > 4 || s < 1)
            {
                throw new ArgumentOutOfRangeException("Suit must be in the range of 1-4 (inclusive).");
            }

            if (v >= 1 && v <= 13 && s >= 1 && s <= 4)
            {
                Value = v;
                Suit = s;
            }
        }

        public override string ToString()
        {
            return Value + " of " + Suit;
        }
    }
}
