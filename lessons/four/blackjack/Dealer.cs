using System;
using System.Collections.Generic;

public readonly struct Message {
    public readonly string Sender, Action;
    public Message(string sender, string action) {
        Sender = sender;
        Action = action;
    }
}

public class Hand {

}

public class State {

    public Deck Deck;
    public Dictionary<string, Player> Players;
    public Dictionary<string, List<Hand>> Hands;

    public List<Hand> RegisterPlayer(Player p) {
        this.Players[p.Name] = p;
        this.Hands[p.Name].Add(new Hand{});
        return this.Hands[p.Name];
    }
}

public class Dealer {

    private State GameState;

    public (Action<Message> channel, List<Hand> hand) JoinGame(Player p) {
        this.GameState.Players[p.Name] = p;
        return (this.DispatchMessage, this.GameState.RegisterPlayer(p));
    }

    public void DispatchMessage(Message m) {

    }
}

