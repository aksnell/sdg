using System;
using System.Collections.Generic;

public class Player {

    public string Name;
    private Action<Message> MessageDealer;

    private static List<string> ValidActions = new List<string>{"HIT"};

    private void SendMessage(Message m) {
        switch (m.Action)
        {
            case "TURN":
                this.RespondMessage();
                break;
            default:
                break;
        }
    }

    private void RespondMessage() {

        Console.WriteLine("What would you like to do?");
        string MyAction = Console.ReadLine();

        Message MyMessage = new Message(this.Name, MyAction);
        MessageDealer(MyMessage);

    }

}

