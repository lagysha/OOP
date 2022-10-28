
namespace Lab2
{
    internal class DonaterAccount : Account
    {
        public DonaterAccount(string userName) : base(userName)
        {
            ratingCoeficient = 2;
        }

    }
}
