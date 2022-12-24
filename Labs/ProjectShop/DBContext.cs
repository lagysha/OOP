using ProjectShop.models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectShop
{
    internal class DBContext
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public List<Product> Products { get; set; }
        public List<User> Users { get; set; }
        public DBContext()
        {
            Products = new List<Product>();
            Users = new List<User>();
        }

        public void AddProduct(Product product)
        {
            product.Id = ProductId++;
            Products.Add(product);
        }
        public void AddUser(User user)
        {
            user.Id = UserId++;
            Users.Add(user);
        }
    }
}

