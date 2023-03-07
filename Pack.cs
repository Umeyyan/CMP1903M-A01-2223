using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        List<Card> pack;

        public Pack()
        {
            this.pack = new List<Card>(52);

            for (int s = 1; s <= 4; s++)
            {
                for (int v = 1; v <= 13; v++)
                {
                    this.pack.Add(new Card(v, s));
                }
            }
        }

        public static bool shuffleCardPack(int typeOfShuffle)
        {
            if (typeOfShuffle == 3) //no shuffle
            {
                return true;
            }

            else
            {
                if (typeOfShuffle == 1) //Fisher-Yates Shuffle
                {
                    /*
                        "The Fisher–Yates shuffle is an algorithm for generating a random permutation of a finite sequence—in plain terms,
                        the algorithm shuffles the sequence. The algorithm effectively puts all the elements into a hat; it continually 
                        determines the next element by randomly drawing an element from the hat until no elements remain."

                        https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle

                        In short, draw cards at random until no cards are left to create a shuffled deck.
                    */

                    Random rand = new Random();
                    int j;

                    for (int i = 0; i < 51; i++)
                    {
                        j = rand.Next(i, 52);

                        (pack.pack[i], pack.pack[j]) = (pack.pack[j], pack.pack[i]);
                    }
                }

                else
                {
                    if (typeOfShuffle == 2) //Riffle Shuffle
                    {
                        /*
                            "A riffle shuffle permutation is one of the permutations of a set of n items that can be obtained by a 
                            single riffle shuffle, in which a sorted deck of n cards is cut into two packets and then the two packets 
                            are interleaved (e.g. by moving cards one at a time from the bottom of one or the other of the packets to 
                            the top of the sorted deck)."

                            https://en.wikipedia.org/wiki/Riffle_shuffle_permutation

                            In short, split the pack of cards evenly and alternate between taking the bottom card of half A and the bottom 
                            card of half B, eg A1, B1, A2, B2, etc. Continue this until no cards are left in both halves to create a 
                            shuffled deck.
                        */

                        ListL<Card> half_A = Pack.pack.GetRange(0, 26);
                        ListL<Card> half_B = Pack.pack.GetRange(26, 26);
                        ListL<Card> shuffledDeck = new List<Card>(52);

                        for (int i = 26; i >= 0; i--)
                        {
                            shuffledDeck.Add(half_A[i]);
                            shuffledDeck.Add(half_B[i]);
                        }

                        Pack.pack = shuffledDeck;
                    }
                }
            }

            return true;
        }
        public static Card deal()
        {
            //Deals one card
            Card c = Pack.pack[0];
            Pack.pack.RemoveAt(0);

            return c;
        }
        public static List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
            List<Card> hand = new List<Card>(amount);

            for (int i = 0; i < amount + 1; i++)
            {
                hand.Add(Pack.pack[i]);
            }

            Pack.pack.RemoveRange(0, amount);
        }
    }
}