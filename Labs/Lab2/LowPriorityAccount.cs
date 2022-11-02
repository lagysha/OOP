
namespace Lab2
{
    class LowPriorityAccount : Account
    {
        public LowPriorityAccount(string userName) : base(userName)
        {
            RaitingCoeficient = 0.5;
        }
    }
}
