using ProjectShop.models;
using ProjectShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShop.util
{
    internal class UsersValidator
    {
        private UsersService UsersService { get; set; }

        public UsersValidator(DBContext dBContext)
        {
            UsersService = new UsersService(dBContext);
        }

        public void Validate(User user)
        {
            if(UsersService.FindByName(user.UserName) != null)
            {
                throw new UserAlreadyExistsException("This username is already taken");
            }
        }
    }
}
