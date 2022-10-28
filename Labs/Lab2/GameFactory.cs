
namespace Lab2
{
    public enum GameType
    {
        Raiting,Training,DoubleRaiting
    }

    class GameFactory
    {
        public Game create(GameType gameType,Account gameAccountOne,Account gameAccountTwo,int rating)
        {
            return gameType switch
            {
                GameType.Raiting => new RaitingGame(gameAccountOne, gameAccountTwo, rating),
                GameType.DoubleRaiting => new DoubleRaitingGame(gameAccountOne, gameAccountTwo, rating),
                _ => new TrainingGame(gameAccountOne, gameAccountTwo),
            };
        }
    }
}

