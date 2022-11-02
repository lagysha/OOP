
namespace Lab2
{
    abstract class Game
    {
        public readonly Account Winner;
        public readonly Account Looser;
        public uint GameRaiting { get; set; }
        private static uint GlobalId;
        public readonly uint ID;

        public Game(Account winner, Account looser)
        {
            Winner = winner;
            Looser = looser;
            ID = GlobalId++;
        }

    }
}
