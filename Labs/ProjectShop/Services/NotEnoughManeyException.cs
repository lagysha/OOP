using System.Runtime.Serialization;

namespace ProjectShop.Services
{
    [Serializable]
    internal class NotEnoughManeyException : Exception
    {
        public NotEnoughManeyException(string? message) : base(message)
        {
        }
    }
}