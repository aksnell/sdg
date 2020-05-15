
namespace blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            // Minimum Viable Product
            // Only took one complete rewrite!
            Dealer d = new Dealer{};
            Player p = new Player{};
            d.JoinGame(p);
            d.Play();
        }
    }
}
