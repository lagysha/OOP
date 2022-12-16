using ProjectShop.models;
using ProjectShop.repositories;
using ProjectShop.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShop.Services
{
    internal class UsersService
    {
        private UsersRepository UsersRepository { get; set; }
        private ProductsRespository ProductsRespository { get; set; }
        public UsersService(DBContext dBContext)
        {
            UsersRepository = new UsersRepository(dBContext);
            ProductsRespository = new ProductsRespository(dBContext);
        }

        public User FindByName(string name)
        {
            return UsersRepository.FindByName(name);
        }

        public void Save(User user)
        {
            UsersRepository.Save(user);
        }

        public User AuthenticateUser(User user)
        {
            User userFromDB = UsersRepository.FindByName(user.UserName);
            if (userFromDB == null || !userFromDB.Password.Equals(user.Password))
            {
                throw new BadCredentialsException("Bad Credentials");
            }
            return userFromDB;
        }

        public void ReplenishBalance(User user, double money)
        {
            if (money < 0)
            {
                throw new ArgumentException("Not supported action. Please enter positive value");
            }
            user.Balance = user.Balance + money;
        }

        public void BuyProduct(User user, int productId)
        {
            Product retrievedProduct = ProductsRespository.FindById(productId);
            if (user.Balance - retrievedProduct.Price < 0)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("Not enough money to buy product. ")
                    .Append("You have " + user.Balance + ". ")
                    .Append("You need " + retrievedProduct.Price + "\n")
                    .Append("Please replenish balance");
                throw new NotEnoughManeyException(stringBuilder.ToString());
            }
            user.Balance = user.Balance - retrievedProduct.Price;
            user.PurchaseHistory.Add(retrievedProduct);
            ProductsRespository.Delete(retrievedProduct);
        }
    }
}
