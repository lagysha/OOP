
namespace Lab2
{
    internal class TrainingGame : Game
    {
        public TrainingGame(Account winner, Account looser) : base(winner, looser)
        {
            GameRaiting = 0;
            winner.AddGame(this);
            looser.AddGame(this);
        }
    }
}
