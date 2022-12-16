using ProjectShop.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShop.repositories
{
    internal class UsersRepository : IRepository<User>
    {
        DBContext DBContext { get; set; }
        public UsersRepository(DBContext dBContext)
        {
            DBContext = dBContext;
        }

        public void Save(User objectT)
        {
            DBContext.AddUser(objectT);
        }

        public List<User> FindAll()
        {
            return DBContext.Users;
        }

        public User FindByName(string name)
        {
            return DBContext.Users.FirstOrDefault(user => user.UserName.Equals(name));
        }

        public void Delete(User objectT)
        {
            DBContext.Users.Remove(DBContext.Users.FirstOrDefault(user => user.UserName.Equals(objectT.UserName)));
        }
    }
}
