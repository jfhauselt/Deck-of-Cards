using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Deck_of_Cards
{
    static class BasicPokerGame
    {
        //thought best way to check for pairs is to create a dictionary and the number of entires is the number of 
        public static int numberOfTuples(Deck Hand,int numberOf)
        {
            //realized that I can create a function that checks to see pair, triple or 4 of a kind by a helper function to make other functions easier
            Dictionary<string, int> pairTest = new Dictionary<string, int>();
            foreach(Card c in Hand.deckorder)
            {
                try
                {
                    pairTest.Add(c.rank, 1);
                }
                catch
                {
                    pairTest[c.rank]++;
                }

            }
            int pairNum = 0;
            foreach(int i in pairTest.Values)
            {
                if(i == numberOf)
                {
                    pairNum++;
                }
            }
            return pairNum;
        }
        public static bool isPair(Deck Hand)
        {
            return numberOfTuples(Hand,2) == 1;
        }
        public static bool isTwoPair(Deck Hand)
        {
            return numberOfTuples(Hand,2) == 2;
        }
        public static bool isThreeOfAKind(Deck Hand)
        {
            return numberOfTuples(Hand, 3) == 1;
        }
        public static bool isFourofAKind(Deck Hand)
        {
            return numberOfTuples(Hand, 4) == 1;
        }
        public static bool isFlush(Deck Hand)
        {
            Dictionary<string, int> flushTest = new Dictionary<string, int>();
            foreach (Card c in Hand.deckorder)
            {
                try
                {
                    flushTest.Add(c.suit, 1);
                }
                catch 
                {
                    if (flushTest.Count > 1)
                {
                    return false;
                }
                }
            }
            return flushTest.Count() == 1;

        }
        public static bool isStraight(Deck Hand)
        {
            List<String> SuitLst = new List<String>(){"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            List<int> testinglst = new List<int>();
            foreach(Card c in Hand.deckorder)
            {
                testinglst.Add(SuitLst.IndexOf(c.rank));
            }
            testinglst.Sort();
            int len = testinglst.Count() - 1;
            while (len > 0)
            {
                if (!(testinglst[len] == testinglst[len - 1] +1))
                {
                    return false;
                }
                len -= 1;
            }
            if (!(testinglst[0]==testinglst[1] - 1))
            {
                return false;
            }
            return true;
        }
        public static bool isFullHouse(Deck myHand)
        {
            return isPair(myHand) & isThreeOfAKind(myHand);
        }
        
        public static bool isStraightFlush(Deck myHand)
        {
            return isStraight(myHand) & isFlush(myHand);
        }

        public static bool isRoyalFlush(Deck myHand)
        {
            List<string> testlst = new List<string>();
            if (!(isFlush(myHand)))
            {
                return false;
            }
            foreach(Card c in myHand.deckorder)
            {
                testlst.Add(c.rank);
            }
            if (!(testlst.Contains("A")))
                {
                return false;
                }
            if (!(testlst.Contains("K")))
            {
                return false;
            }
            if (!(testlst.Contains("Q")))
            {
                return false;
            }
            if (!(testlst.Contains("J")))
            {
                return false;
            }
            if (!(testlst.Contains("10")))
            {
                return false;
            }
            return true;
        }

    
    }
}
