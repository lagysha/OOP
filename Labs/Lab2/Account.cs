
namespace Lab2
{
    class Account
    {
        public string UserName { get; }
        protected double CurrentRaiting { get; set; }
        readonly List<Game> GamesHistory = new List<Game>();
        int GamesCount { get { return GamesHistory.Count; } }
        public double RaitingCoeficient { get; set; }
        public Account(string userName)
        {
            this.UserName = userName;
            CurrentRaiting = 1;
            RaitingCoeficient = 1;
        }

        public void AddGame(Game game)
        {
            if (game.Looser.Equals(this))
            {
                LooseGame(game);
            }
            else
            {
                WinGame(game);
            }
            GamesHistory.Add(game);
        }

        public virtual void WinGame(Game game)
        {
            CurrentRaiting += RaitingCoeficient * game.GameRaiting;
        }

        public virtual void LooseGame(Game game)
        {
            if (game.GameRaiting > CurrentRaiting) CurrentRaiting = 1;
            else CurrentRaiting -= game.GameRaiting;
        }


            public void GetStats()
        {
            Console.WriteLine(UserName + "`s status" + "\tAccount type - " + this.GetType().Name + "\n");
            foreach (Game game in GamesHistory)
            {
                Console.Write("Winner - ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(game.Winner.UserName);
                Console.ResetColor();
                Console.Write("\tLoser - ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(game.Looser.UserName);
                Console.ResetColor();
                Console.WriteLine("\tRating - " + game.GameRaiting + "\tID - " + game.ID + "\tGame type - " + game.GetType().Name);
            }
            Console.WriteLine("\nGames played: " + GamesCount);
            Console.WriteLine("Current rating of " + this.UserName + ": " + CurrentRaiting + "\n" );
        }
    }
}
