using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShop.util
{
    internal class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException(string? message) : base(message)
        {
        }
    }
}
