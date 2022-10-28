
namespace Lab2
{
    abstract class Game
    {
        public readonly Account Winner;
        public readonly Account Looser;
        public int gameRating { get; set; }
        private static uint globalID;
        public readonly uint ID;

        public Game(Account winner, Account looser)
        {
            Winner = winner;
            Looser = looser;
            ID = globalID++;
        }

    }
}
