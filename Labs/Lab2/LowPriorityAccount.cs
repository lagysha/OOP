
namespace Lab2
{
    class LowPriorityAccount : Account
    {
        public LowPriorityAccount(string userName) : base(userName)
        {
            ratingCoeficient = 0.5;
        }
    }
}
