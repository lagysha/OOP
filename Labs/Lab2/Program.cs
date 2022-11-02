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

        Play(accounts.ElementAt(0), accounts.ElementAt(1), GameType.Raiting, 80);
        Play(accounts.ElementAt(1), accounts.ElementAt(2), GameType.Raiting, 80);
        Play(accounts.ElementAt(2), accounts.ElementAt(0), GameType.Raiting, 80);

        Play(accounts.ElementAt(0), accounts.ElementAt(1), GameType.Training, 80);
        Play(accounts.ElementAt(1), accounts.ElementAt(2), GameType.Training, 80);
        Play(accounts.ElementAt(2), accounts.ElementAt(0), GameType.Training, 80);

        Play(accounts.ElementAt(0), accounts.ElementAt(1), GameType.DoubleRaiting, 80);
        Play(accounts.ElementAt(1), accounts.ElementAt(2), GameType.DoubleRaiting, 80);
        Play(accounts.ElementAt(2), accounts.ElementAt(0), GameType.DoubleRaiting, 80);

        gameAccountOne.GetStats();
        gameAccountTwo.GetStats();
        gameAccountThree.GetStats();
        Console.WriteLine();
    }
    public static void Play(Account firstAccount,Account secondAccount,GameType gameType,uint rating)
    {
        GameFactory gameFactory = new GameFactory();

        gameFactory.Create(gameType, firstAccount, secondAccount, rating);
    }
}