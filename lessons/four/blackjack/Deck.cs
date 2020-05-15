using System;
using System.Collections.Generic;

public class Deck {

    private static string[] Suits = {
        "♣️",
        "♦",
        "❤",
        "♠️"
    };

    private static string[] Faces = {
        "2", 
        "3", 
        "4", 
        "5", 
        "6", 
        "7", 
        "8", 
        "9", 
        "10",
        "Jack", 
        "Queen", 
        "King",
        "Ace"
    };

    public Deck() {

        int handlePtr = 0;
        this.CardDefinitions = new Dictionary<int, CardDefinition>{};
        this.Cards = new List<Card>();

        // Create fresh card definitions and handles.
        for (int suit = 0; suit < 4; suit++) {
            for (int face = 0; face < 13; face++) {

                int pointValue = (face == 12) ? 11 : Math.Min(10, face);

                //Creating card definition.
                this.CardDefinitions[handlePtr] = new CardDefinition( 
                        Suits[suit], 
                        Faces[face],
                        pointValue
                );

                //Creating card handles.
                this.Cards.Add(new Card(handlePtr, this));
                handlePtr++;
            }
        }
    }

    public void Shuffle() {

        Random rng = new Random();

        for (int firstInd = 51; firstInd > 0; firstInd--)  {
            int rngInd = rng.Next(0, firstInd);
            Card toSwap = this.Cards[firstInd];
            this.Cards[firstInd] = this.Cards[rngInd]; 
            this.Cards[rngInd] = toSwap;
        }
    }

    public Card Draw() {
        Card c = this.Cards[0];
        this.Cards.RemoveAt(0);
        return c;
    }

    public void Return(Card c) {
        this.Cards.Add(c);
    }

    private Dictionary<int, CardDefinition> CardDefinitions;
    private List<Card> Cards;

    protected struct CardDefinition {

        private readonly string suit;
        private readonly string face;
        private readonly int value;

        public CardDefinition(string s, string f, int v) {
            suit = s;
            face = f;
            value = v;
        }

        public string Face { get { return $"[{face}{suit}]"; } }
        public int Value { get { return value; } }
    }


    public struct Card {

        private readonly int Key;
        private Deck Parent;

        public Card(int key, Deck parent) {
            Key = key;
            Parent = parent;
        }

        public string Face {
            get { return Parent.HandleFace(Key); }
        }
        public int Value() {
            return Parent.HandleValue(Key);
        }
    }

    protected string HandleFace(int handle) {
        return this.CardDefinitions[handle].Face;
    }
    protected int HandleValue(int handle) {
        return this.CardDefinitions[handle].Value;
    }
}

