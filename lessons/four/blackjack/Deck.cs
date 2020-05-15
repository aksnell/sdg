using System;
using System.Collections.Generic;

namespace blackjack {

    // Card wraps the state needed to define a card,
    // its value and its display string.
    public class Card
    {
        public string Suit;
        public string Face;
        public int Value { get; }

        public Card(string s, string f, int v) {
            Suit = s;
            Face = f;
            Value = v;
        }

        public string DisplayCard() {
            return $"[{Face}{Suit}]";
        }
    }

    // A Grip is the primary interface for storing, drawing and returning cards
    // to a refenced Deck. This is composited into the Player class by the
    // Dealer so the Dealer can mediate card interactions between arbitray Player(s)
    // and its own Deck.
    // WHY: I wanted a generic interface I could instanstiate or composite to 
    // handle most of the "database" access so I could bake it more into the Dealer, or 
    // better handle extra players, multiple decks, etc. Whether that happens is 
    // another story.
    public class Grip
    {
        // Your "hand"
        private List<Card> Cards;
        // The deck object to draw and return cards to.
        private Deck Parent;

        public Grip(Deck parent) {
            Cards = new List<Card>{};
            Parent = parent;
        }
        // Hit adds a card to the Hand. These cards are fully popped from the
        // referenced Deck by the Deck(s) Draw() function.
        public void Hit() {
            Cards.Add(Parent.Draw());
        }
        
        // Fold calls the Deck's return function to re-add these cards
        // to its own internal Card List.
        // I just like the idea of returning digital cards.
        public void Fold() {
            foreach (Card c in Cards) {
                Parent.Return(c);
            }
            Cards = new List<Card>{};
        }
        
        // Returns a formatted string representing the entire hand.
        public string GetHandStr() {
            string HandStr = "";
            foreach (Card c in Cards) {
                HandStr += c.DisplayCard() + " ";
            }
            return HandStr;
        }

        // Returns the total point value of the entire hand (Aces 11).
        public int GetHandValue() {
            int HandValue = 0;
            foreach (Card c in Cards) {
                HandValue += c.Value;
            }
            return HandValue;
        }
    }

    public class Deck
    {

        private List<Card> Cards = new List<Card>();

        // Building the deck and its initial cards.
        // Nothing new or exciting, just a different style because
        // having the two long lists looked ugly to me.
        public Deck() {
            foreach (string suit in new[] {"❤","♣️","♦","♣️"}) {
                for (int face = 1; face < 14; face++) {
                    switch (face) {
                        case 10:
                            Cards.Add(new Card(suit, "J", 10));
                            break;
                        case 11:
                            Cards.Add(new Card(suit, "Q", 10));
                            break;
                        case 12:
                            Cards.Add(new Card(suit, "K", 10));
                            break;
                        case 13:
                            Cards.Add(new Card(suit, "A", 11));
                            break;
                        default:
                            Cards.Add(new Card(suit, face.ToString(), face));
                            break;
                    }
                }
            }
        }

        // Draw shuffles the deck and then pops the card from its list, providing
        // it the caller.
        public Card Draw() {
            Shuffle();
            Card Drawn = Cards[0];
            Cards.RemoveAt(0);
            return Drawn;
        }

        // Takes a card and adds it back to its internal Cards list.
        // WHY: I think the idea of loaning out and returning digital cards is funny.
        public void Return(Card returned) {
            Cards.Add(returned);
        }

        //Same shuffle algo as before.
        public void Shuffle() {
            Random rng = new Random();
            for (int swapIndex = Cards.Count - 1; swapIndex > 0; swapIndex--) {
                int rndIndex = rng.Next(0, swapIndex);
                Card prevCard = Cards[swapIndex];
                Card swapCard = Cards[rndIndex];
                Cards[swapIndex] = swapCard;
                Cards[rndIndex] = prevCard;
            }
        }
    }
}
