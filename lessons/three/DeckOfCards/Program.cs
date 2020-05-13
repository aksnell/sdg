using System;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Dealer.Deck d = new Dealer.Deck();
            d.Shuffle();
            d.ShowTopX(2);
        }
    }
}
