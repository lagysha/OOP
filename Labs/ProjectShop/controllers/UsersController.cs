using ProjectShop.models;
using ProjectShop.Services;
using ProjectShop.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShop.controllers
{
    internal class UsersController
    {
        private UsersService UsersService { get; set; }
        private ProductsService ProductsService { get; set; }
        private UsersValidator UsersValidator { get; set; }
        public User CurrentUser { get; set; }
        public UsersController(DBContext dBContext)
        {
            ProductsService = new ProductsService(dBContext);
            UsersValidator = new UsersValidator(dBContext);
            UsersService = new UsersService(dBContext);
        }
        
        public void ShowHistory()
        {
            Console.WriteLine("Purchace History");
            CurrentUser.PurchaseHistory.ForEach(e => Console.WriteLine("Product:\t" + e.Name + "\t Price: " + e.Price));
        }

        public void RegistryUser()
        {
            User user = GetUserFromConsole();
            try
            {
                UsersValidator.Validate(user);
            }
            catch (UserAlreadyExistsException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Try again");
            }
            UsersService.Save(user);
            Console.WriteLine("Registration is Succeful!");
        }

        public void Login()
        {
            User user = GetUserFromConsole();
            try
            {
                CurrentUser = UsersService.AuthenticateUser(user);
                Console.WriteLine("Login is Succeful");
            }
            catch (BadCredentialsException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Try again");
            }
        }

        public void ReplenishBalance()
        {
            Console.WriteLine("Enter amount of money");
            try
            {
                double money = Double.Parse(Console.ReadLine());
                UsersService.ReplenishBalance(CurrentUser, money);
                Console.WriteLine("Replenished successfuly");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("Try again");
                Console.WriteLine("Please enter number");
            }
        }

        public void BuyProduct()
        {
            Console.WriteLine("All avaliable products");
            int number = 1;
            ProductsService.FindAll().ForEach(e => Console.WriteLine("Number: " + (number++) + " Product:\t" + e.Name + "\t Price: " + e.Price));
            Console.WriteLine("Enter number of product to buy");
            try
            {
                int productId = int.Parse(Console.ReadLine());
                UsersService.BuyProduct(CurrentUser, --productId);
                Console.WriteLine("Thank you for buying our products");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("No such product is avaliable");
            }
            catch (NotEnoughManeyException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Try again");
                Console.WriteLine("Please enter number");
            }
        }
        private static User GetUserFromConsole()
        {
            Console.WriteLine("Enter UserName");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();
            User user = new User(username, password);
            return user;
        }
    }
}
