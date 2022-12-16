using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShop.models
{
    internal class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
        public List<Product> PurchaseHistory  { get; set; }
        public User(string username,string password)
        {
            UserName = username;
            Password = password;
            PurchaseHistory = new List<Product>();
        }

    }
}
