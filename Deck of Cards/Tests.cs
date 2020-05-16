using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Deck_of_Cards
{
    class Program
    {
        public static void Main()
        {
            //Runs tests
            //Initial program tests
            //ProgramTests();
            //tests to check if the hand comparisons work at all
            //PokerTests();

            //Infinite testing is a way to constantly create new hands to watch it
            //infinteTesting();

            //Test for is created to stop at a specific function call
            stopTest(BasicPokerGame.isRoyalFlush);
        }

        public static void ProgramTests()
        {
            Deck myDeck = utilities.createDeck();
            myDeck.shuffle();
            foreach (Card c in myDeck.deckorder)
            {
                c.show();
            }
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
            Console.Clear();
            Deck myHand = utilities.drawHand(myDeck);
            foreach (Card c in myHand.deckorder)
            {
                c.show();
            }
            Console.WriteLine($"The hand{myHand} is pair: {BasicPokerGame.isPair(myHand)}");
            Console.WriteLine($"The hand{myHand} is two pair: {BasicPokerGame.isTwoPair(myHand)}");
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
            Console.Clear();
        }
        //semi irrelevant due to stop test
        public static void PokerTests()
        {
            string exampleSuit = "clubs";
            List<string> ranks = new List<string>()
            {
                "A","A"
            }; 
            List<string> ranks2 = new List<string>()
            {
                "A","A","2","2"
            };
            Deck myPairHand = new Deck();
            Deck myTwoPairHand = new Deck();
            foreach(string s in ranks)
            {
                Card c = new Card();
                c.suit = exampleSuit;
                c.rank = s;
                myPairHand.addcard(c);
            }
            foreach(string s in ranks2)
            {
                Card c = new Card();
                c.suit = exampleSuit;
                c.rank = s;
                myTwoPairHand.addcard(c);
            }
            Console.WriteLine($"The hand{myPairHand} is pair: {BasicPokerGame.isPair(myPairHand)}");
            Console.WriteLine($"The hand{myPairHand} is two pair: {BasicPokerGame.isTwoPair(myPairHand)}");
            
            Console.WriteLine($"The hand{myTwoPairHand} is pair: {BasicPokerGame.isPair(myTwoPairHand)}");
            Console.WriteLine($"The hand{myTwoPairHand} is two pair: {BasicPokerGame.isTwoPair(myTwoPairHand)}");

            Deck myThreeHand = new Deck();
            List<string> ranks3 = new List<string>()
            {
                "A","A","A"
            };
            foreach(string s in ranks3)
            {
                Card c = new Card();
                c.suit = exampleSuit;
                c.rank = s;
                myThreeHand.addcard(c);
            }
            Console.WriteLine($"The hand{myThreeHand} is pair: {BasicPokerGame.isPair(myThreeHand)}");
            Console.WriteLine($"The hand{myThreeHand} is two pair: {BasicPokerGame.isTwoPair(myThreeHand)}");
            Console.WriteLine($"The hand{myThreeHand} is three of a kind: {BasicPokerGame.isThreeOfAKind(myThreeHand)}");
            Console.WriteLine($"The hand{myThreeHand} is flush: {BasicPokerGame.isFlush(myThreeHand)}");
            Console.WriteLine("Press Enter to Continue");

            //in theory a full deck should work as a full hand
            Deck myStraight = utilities.createDeck();
            Console.WriteLine($"The hand {myStraight} is straight: {BasicPokerGame.isStraight(myStraight)}");
            Console.ReadLine();


        }
        public static void infinteTesting()
        {
            Console.Clear();
            //creates a hand and does tests on it
            //all random
            string response = "1";
            while (response != "0")
            {
                Console.Clear();
                Deck myDeck = utilities.createDeck();
                myDeck.shuffle();
                Deck myHand = utilities.drawHand(myDeck);
                foreach (Card c in myHand.deckorder)
                {
                    c.show();
                }
                Console.WriteLine($"The hand is pair: {BasicPokerGame.isPair(myHand)}");
                Console.WriteLine($"The hand is two pair: {BasicPokerGame.isTwoPair(myHand)}");
                Console.WriteLine($"The hand is three of a kind: {BasicPokerGame.isThreeOfAKind(myHand)}");
                Console.WriteLine($"The hand is a four of a kind: {BasicPokerGame.isFourofAKind(myHand)}");
                Console.WriteLine($"The hand is a flush: {BasicPokerGame.isFlush(myHand)}");
                Console.WriteLine($"The hand is a straight: {BasicPokerGame.isStraight(myHand)}");
                Console.WriteLine("Enter 0 to quit and anything else to contine");
                response = Console.ReadLine();

            }
        }
        //passes a function that returns T/F meant to use the Poker functions
        public static void stopTest(Func<Deck, bool> myFunction)
        {
            int count = 0;
            string response = "1";
            while (response != "0")
            {
                count += 1;
                Deck myDeck = utilities.createDeck();
                myDeck.shuffle();
                Deck myHand = utilities.drawHand(myDeck);
                if (myFunction(myHand))
                {
                    Console.WriteLine($"Had to create: {count} number of hands");
                    foreach (Card c in myHand.deckorder)
                    {
                        c.show();
                    }
                    count = 0;
                    Console.WriteLine("\nEnter 0 to quit and anything else to contine");
                    response = Console.ReadLine();
                }
            }
        }

        
    }
}
