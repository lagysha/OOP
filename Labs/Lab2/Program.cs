using Lab2;

class Program
{
    static void Main(string[] args)
    {
        Account gameAccountOne = new DonaterAccount("Billy Uarinhtons");
        Account gameAccountTwo = new LowPriorityAccount("Kirill Mulchukos");
        Account gameAccountThree = new Account("Baisanuk Jonsons");


        List<Account> accounts = new List<Account>();
        accounts.Add(gameAccountOne);
        accounts.Add(gameAccountTwo);
        accounts.Add(gameAccountThree);

        play(accounts.ElementAt(0), accounts.ElementAt(1), GameType.Raiting, 80);
        play(accounts.ElementAt(1), accounts.ElementAt(2), GameType.Raiting, 80);
        play(accounts.ElementAt(2), accounts.ElementAt(0), GameType.Raiting, 80);

        play(accounts.ElementAt(0), accounts.ElementAt(1), GameType.Training, 80);
        play(accounts.ElementAt(1), accounts.ElementAt(2), GameType.Training, 80);
        play(accounts.ElementAt(2), accounts.ElementAt(0), GameType.Training, 80);

        play(accounts.ElementAt(0), accounts.ElementAt(1), GameType.DoubleRaiting, 80);
        play(accounts.ElementAt(1), accounts.ElementAt(2), GameType.DoubleRaiting, 80);
        play(accounts.ElementAt(2), accounts.ElementAt(0), GameType.DoubleRaiting, 80);

        gameAccountOne.getStats();
        gameAccountTwo.getStats();
        gameAccountThree.getStats();
        Console.WriteLine();
    }
    public static void play(Account firstAccount,Account secondAccount,GameType gameType,int rating)
    {
        GameFactory gameFactory = new GameFactory();

        gameFactory.create(gameType, firstAccount, secondAccount, rating);
    }
}