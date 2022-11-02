
namespace Lab2
{
    internal class RaitingGame : Game
    {
        public RaitingGame(Account winner, Account looser, uint rating) : base(winner, looser)
        {
            GameRaiting = rating;
            winner.AddGame(this);
            looser.AddGame(this);
        }
    }
}
