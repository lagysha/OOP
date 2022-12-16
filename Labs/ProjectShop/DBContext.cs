using ProjectShop.models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectShop
{
    internal class DBContext
    {
        private static int UserId { get; set; }

        private static int PersonId { get; set; }
        public List<Product> Products { get; set; }
        public List<User> Users { get; set; }
        public DBContext()
        {
            Products = new List<Product>();
            Product product1 = new Product("NVIDIA RTX 3060", 500);
            Product product2 = new Product("NVIDIA GTX 1060", 150);
            Product product3 = new Product("NVIDIA RTX 4090", 2500);
            Product product4 = new Product("NVIDIA RTX 1050", 50);
            Product product5 = new Product("NVIDIA GTX 2060", 200);
            Product product6 = new Product("RADEON RX 580", 140);
            AddProduct(product1);
            AddProduct(product2);
            AddProduct(product3);
            AddProduct(product4);
            AddProduct(product5);
            AddProduct(product6);
            Users = new List<User>();
            User user1 = new User("User1", "password1");
            User user2 = new User("User2", "password2");
            user2.Balance = 1000;
            AddUser(user1);
            AddUser(user2);
        }

        public void AddProduct(Product product)
        {
            product.Id = UserId++;
            Products.Add(product);
        }
        public void AddUser(User user)
        {
            user.Id = PersonId++;
            Users.Add(user);
        }
    }
}

