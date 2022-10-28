
namespace Lab2
{
    internal class RaitingGame : Game
    {
        public RaitingGame(Account winner, Account looser, int rating) : base(winner, looser)
        {
            if (rating < 0) throw new ArgumentOutOfRangeException("Rating must be greater than 0");
            gameRating = rating;
            winner.addGame(this);
            looser.addGame(this);
        }
    }
}
