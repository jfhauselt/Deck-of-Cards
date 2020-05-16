using System;
using System.Collections.Generic;
using System.Linq;

namespace Deck_of_Cards
{
    class Card
    {
        
        public string suit;
        public string rank;

        public void show()
        {
            Console.WriteLine($"{suit} {rank}");
        }
    }

    class Deck
    {
        public List<Card> deckorder = new List<Card>();
        //returns the card on "top" and removes it from the deck
        public Card draw()
        {
            //gets the index of the last item in the list (efficent) removes and returns it
            int len = deckorder.Count();
            Card output = deckorder[len - 1];
            deckorder.RemoveAt(len - 1);
            return output;
        }
        //sinec t
        public void addcard(Card C)
        {
            deckorder.Add(C);
        }
        public void shuffle()
        {
            Deck temp = new Deck();
            Random rnd = new Random();
            int length = deckorder.Count;
            while (length > 1)
            {
                length = deckorder.Count;
                int index = rnd.Next(0, length);
                temp.addcard(deckorder[index]);
                deckorder.RemoveAt(index);
            }
            deckorder = temp.deckorder;

        }
        //idk what i'm doing
        //public IEnumerator enumerator()
        //{
         //   return deckorder.GetEnumerator();
        //}
       

    }
    static class utilities
    {
        public static Deck createDeck() 
        {
            Deck D = new Deck();
            List<string> suits = new List<string>()
            {
                "clubs",
                "spades",
                "hearts",
                "diamonds"
            };

            List<string> ranks = new List<string>()
            {
                "A","2","3","4","5","6","7","8","9","10","J","Q","K"
            };
            foreach(string s in suits)
            {
                foreach(string r in ranks)
                {
                    Card C = new Card();
                    C.suit = s;
                    C.rank = r;
                    D.addcard(C);
                }
            }
            return D;
        }
        //creates a new hand, simplified code by making a hand just a deck of 5 cards as they do basically the same things and 
        // I am struggling with poker terminology
        public static Deck drawHand(Deck mainDeck)
        {
            Deck hand = new Deck();
            int i = 5;
            while (i >0)
            {
                hand.addcard(mainDeck.draw());
                i--;
            }
            return hand;
        }
    }
}

