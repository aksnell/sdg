using System;
public static class Dealer
{
    
    // I want you to know that I looked up how to make an enum and typed
    // that out for both of these before I realized we needed actual strings.
    // Planning and reading instructions is what you might call a weakspot.
    private static string[] Suits = new string[4]{"Clubs", 
        "Diamonds", 
        "Hearts", 
        "Spades"};

    private static string[] Faces =  new string[13]{"Ace", 
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
        "King"};

    // I give up, everything can public.
    
    // Card wraps a byte indexing an interal Suit array and a byte indexing an interal Face array.
    // ID is pre-calced and shoved in there ahead of time because I assumed we would be sorting shuffled cards more
    // because I decided to not read the instructions.
    // This and deck will probably be seperated from Dealer when I do epic mode.
    public struct Card {
        byte Suit;
        byte Face;
        int ID;
        public Card(string suit, string face) {
            Suit = Convert.ToByte(Array.IndexOf(Suits, suit));
            Face = Convert.ToByte(Array.IndexOf(Faces, face));
            ID = Face << Suit; 
            // Why yes I did think we would be sorting card values, why yes I did plan out this card struct assuming we should be sorting cards.
            // Wh yes, I did not read the instructions. Also you are correct, I do barely know anything bitshifting or when its useful
            // I just know that 13 << 4 shouldn't overflow 256.
        }
        // Thanks MSDN Docs for reminding me that OO languages have magic function overriding. 
        public override string ToString() => $"{Dealer.Faces[Face]} of {Dealer.Suits[Suit]}";
    }
    // Deck wraps an array of 52 Cards and provides methods for interacting with them "securely"
    // in theory. Thinking about proper encapsulation and seperation is for suckers, everything public.
    public struct Deck {
        // I absolutely hate this, no const array, no constexpring a deck of cards.
        // Literally being forced against my will to generate this at runtime.
        private static Card[] Cards = new Card[52];

        static Deck() {
            Cards = new Card[52];
            int ptr = 0;
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Creating a new fresh ordered deck for you.");
            Console.WriteLine("------------------------------------------");
            
            for (byte suit = 0; suit < 4; suit++)
            {
                for (byte face = 0; face < 13; face++)
                {
                    Cards[ptr] = new Card(Suits[suit], Faces[face]);
                    Console.WriteLine($"\tCard Number: {ptr} | Card Face: {Cards[ptr].ToString()}");
                    ptr++;
                }            
            }
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"New {Cards.Length} card deck is completed.");
            Console.WriteLine($"This is a lot of responsibility, you can crash\nthis entire program with a stiff breeze.");
            Console.WriteLine("------------------------------------------");
        }
        // Fisher-Yates.
        public void Shuffle() {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Shuffling the deck as fairly as possible as\ndictated by the rules of the assignement.");
            Console.WriteLine("------------------------------------------");
            Random rnd = new Random();
            for (int i = 51; i > 1; i--) {
                int x = rnd.Next(0, i);
                Card first = Cards[i];
                Card second = Cards[x];
                Cards[i] = second;
                Cards[x] = first;
                Console.WriteLine($"Swapped: [CardNum {i}: {first}] with [CardNum {x}: {second}");
            }
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"If all goes well, there should be some\nlogical connection with that output and these \nnext two cards.");
            Console.WriteLine("------------------------------------------");
        }
        // Final requirement, minimal viable product achieved.
        public void ShowTopX(int x) {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Revealing the top {x} cards.");
            Console.WriteLine("------------------------------------------");
            for (int i=0; i != x; i++) 
            {
                Console.WriteLine(Cards[51-i]);
            }
        }
    }


}
