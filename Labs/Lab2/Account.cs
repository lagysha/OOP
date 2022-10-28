
namespace Lab2
{
    class Account
    {
        public string userName { get; }
        protected double currentRating { get; set; }
        readonly List<Game> gamesHistory = new List<Game>();
        int gamesCount { get { return gamesHistory.Count; } }
        public double ratingCoeficient { get; set; }
        public Account(string userName)
        {
            this.userName = userName;
            currentRating = 1;
            ratingCoeficient = 1;
        }

        public void addGame(Game game)
        {
            if (game.Looser.Equals(this))
            {
                looseGame(game);
            }
            else
            {
                winGame(game);
            }
            gamesHistory.Add(game);
        }

        public virtual void winGame(Game game)
        {
            currentRating += ratingCoeficient * game.gameRating;
        }

        public virtual void looseGame(Game game)
        {
            if (game.gameRating > currentRating) currentRating = 1;
            else currentRating -= game.gameRating;
        }


            public void getStats()
        {
            Console.WriteLine(userName + "`s status" + "\tAccount type - " + this.GetType().Name + "\n");
            foreach (Game game in gamesHistory)
            {
                Console.Write("Winner - ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(game.Winner.userName);
                Console.ResetColor();
                Console.Write("\tLoser - ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(game.Looser.userName);
                Console.ResetColor();
                Console.WriteLine("\tRating - " + game.gameRating + "\tID - " + game.ID + "\tGame type - " + game.GetType().Name);
            }
            Console.WriteLine("\nGames played: " + gamesCount);
            Console.WriteLine("Current rating of " + this.userName + ": " + currentRating + "\n" );
        }
    }
}
