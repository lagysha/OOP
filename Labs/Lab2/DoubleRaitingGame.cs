
namespace Lab2
{
    class DoubleRaitingGame : RaitingGame
    {
        public DoubleRaitingGame(Account winner, Account looser, int rating) : base(winner, looser,2*rating)
        {
        }
    }
}
