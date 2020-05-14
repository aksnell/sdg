interface IOpCode {
    byte Read();
}

interface IPlayer
{
    IOpCode Step(IOpCode opcode);
}


class Inst: IOpCode {
    byte id;
    public byte Read() {
        return id;
    }
}

class Human: IPlayer {
    public IOpCode Step(IOpCode i) {
        return i;
    }
}

class AI: IPlayer {
    public IOpCode Step(IOpCode i) {
        return i;
    }
}

class Deck
{
}

class Card: IOpCode
{
    private Inst Id;
    private string Text;
    public byte Read() {
        return Id.Read();
    }
}
