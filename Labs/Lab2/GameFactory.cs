
namespace Lab2
{
    public enum GameType
    {
        Raiting,Training,DoubleRaiting
    }

    class GameFactory
    {
        public Game Create(GameType gameType,Account gameAccountOne,Account gameAccountTwo,uint rating)
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

