using System;
using System.Collections.Generic;

namespace blackjack {

    // Player wraps a Grip and can be registed with a Dealer
    // to join a game before it starts.
    public class Player {

    public Grip Grip;

    }

    // Dealer holds a Deck and a list of Players.
    // The Dealer encapsulate all Game State and
    // control flow, as well as mediating all access
    // to the card "database" through Grip(s) composited
    // into each player.
    public class Dealer {

        public Deck Deck;
        public List<Player> Players;

        public Dealer() {
            Deck = new Deck();
            Players = new List<Player>();
        }

        // Assigns a Grip with reference to the Dealer(s) Deck
        // to the Player and then adds Player to the Dealer's
        // list.
        public void JoinGame(Player p) {
            p.Grip = new Grip(Deck);
            Players.Add(p);
        }

        // Entry Point
        // A foreach loop in case I want to extend to multiple players.
        // Almost all the game logic is as simple as I could make it.
        public void Play() {
            Console.WriteLine("Lets play!");
            foreach (Player p in Players) {
                p.Grip.Hit();
                p.Grip.Hit();

                Console.WriteLine("Here is your opening hand.");
                Console.WriteLine($"Hand: {p.Grip.GetHandStr()}");
                Console.WriteLine($"Value: {p.Grip.GetHandValue()}");

                PromptPlayer(p);
            }
        }

        // Switch Point
        // Player is prompted to take game action, and the new state
        // is evaluated to determine if the player should be re-prompted
        // or to move to an exit condition such as DealerPlay or FoldPlayer.
        public void PromptPlayer(Player p) {

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("Choice: HIT or STOP");

            switch (Console.ReadLine()) {
                case "HIT":
                    p.Grip.Hit();

                    Console.WriteLine($"HITTING");
                    Console.WriteLine($"Hand: {p.Grip.GetHandStr()}");
                    Console.WriteLine($"Value: {p.Grip.GetHandValue()}");

                    EvaluatePlayer(p);
                    break;
                case "STOP":
                    Console.WriteLine("STOPPING");
                    DealerPlay();
                        break;
            }
        }

        // EvaluatePlayer evaluates the state of the passed player
        // to determine if control should be returned or to bust.
        public void EvaluatePlayer(Player p) {

            if (p.Grip.GetHandValue() > 21) {
                FoldPlayer(p);
            }

            if (p.Grip.GetHandValue() == 21) {
                Console.WriteLine("Blackjack!");
                DealerPlay();
            }
            PromptPlayer(p);
        }

        // Currently ignores passed player and simply calls Reset.
        // Called when EvalutePlayer sees a bust.
        public void FoldPlayer(Player p) {
            Console.WriteLine("Bust! Game over.");
            Reset();
        }

        // DealerPlay is called when either the Player responds STOP
        // or is automatically called if EvaluatePlayer sees a Blackjack.
        // It just dumbly simulates the Dealer's play, pulling two cards
        // and looping hit calls on its own Grip until a value of 17 or higher.
        public void DealerPlay() {
            Grip DealerGrip = new Grip(Deck);
            DealerGrip.Hit();
            DealerGrip.Hit();

            Console.WriteLine("Let's see if the Dealer can beat that!");
            Console.WriteLine($"Dealer Hand: {DealerGrip.GetHandStr()}");
            Console.WriteLine($"Dealer Value: {DealerGrip.GetHandValue()}");

            while (DealerGrip.GetHandValue() < 17) {

                Console.WriteLine("The dealer hits!");
                DealerGrip.Hit();
                Console.WriteLine($"Dealer Hand: {DealerGrip.GetHandStr()}");
                Console.WriteLine($"Dealer Value: {DealerGrip.GetHandValue()}");
            }
            if (DealerGrip.GetHandValue() > 21) {
                Console.WriteLine("The dealer busted! You win!");
                Reset();
            }
            if (DealerGrip.GetHandValue() > Players[0].Grip.GetHandValue()) {
                Console.WriteLine("The dealer beat you!");
            } else {
                Console.WriteLine("You beat the dealer!");
            }
            Reset();
        }
        
        // Reset returns all cards in the Player(s) Grip
        // and offers a chance to play again.
        public void Reset() {
            foreach (Player p in Players) {
                p.Grip.Fold();
            }
            Console.WriteLine("Do you want to play again?");
            Console.WriteLine("Choice: YES or NO");
            if (Console.ReadLine() == "YES") {
                    Play();
            } else {
                Console.WriteLine("Goodbye!");   
            }
        }
    }
}
