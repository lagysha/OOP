
namespace Lab2
{
    internal class TrainingGame : Game
    {
        public TrainingGame(Account winner, Account looser) : base(winner, looser)
        {
            winner.AddGame(this);
            looser.AddGame(this);
        }
    }
}
