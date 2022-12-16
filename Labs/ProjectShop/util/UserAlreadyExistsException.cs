using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShop.util
{
    internal class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string? message) : base(message)
        {
        }
    }
}
