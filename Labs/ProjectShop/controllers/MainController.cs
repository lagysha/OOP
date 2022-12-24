using ProjectShop.models;
using ProjectShop.repositories;
using ProjectShop.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShop.controllers
{
    internal class MainController
    {
        UsersController UsersController { get; set; }
        ProductsController ProductsController { get; set; }
        Dictionary<string, Delegate> Actions { get; set; }
        List<String> NameOfActions { get; set; }
        DBContext DBContext { get; set; }
        Serializer Serializer { get; set; }
        private readonly string FileName = "C:\\Users\\nikit\\source\\repos\\OOP\\Labs\\ProjectShop\\Data\\DBContext.json";
        public MainController()
        {
            Serializer = new Serializer();
            DBContext = Serializer.DeserializeData(FileName);
            UsersController = new UsersController(DBContext);
            ProductsController = new ProductsController(DBContext);
            Actions = new Dictionary<string, Delegate>();
            NameOfActions = new List<String>();
            NameOfActions.Add("show products");
            NameOfActions.Add("show history");
            NameOfActions.Add("replenish balance");
            NameOfActions.Add("buy product");
            Actions.Add("1", new Action(ProductsController.ShowAllProducts));
            Actions.Add("2", new Action(UsersController.ShowHistory));
            Actions.Add("3", new Action(UsersController.ReplenishBalance));
            Actions.Add("4", new Action(UsersController.BuyProduct));
        }

        public void Run()
        {
            RegistryAndLogin();
            ShowActions();
            Serializer.SerializeData(FileName, DBContext);
            Environment.Exit(0);
        }

        private void ShowActions()
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Your Balance:" + UsersController.CurrentUser.Balance);
                Console.WriteLine("List of actions:");
                int number = 1;
                NameOfActions.ForEach(e => Console.Write((number++)+" "+ e+"\n"));
                Console.WriteLine("\nChoose action by number:");
                Console.WriteLine("Type exit to close program");
                string choice = Console.ReadLine();
                if (choice.Equals("exit"))
                {
                    break;
                }
                if (!Actions.ContainsKey(choice))
                {
                    Console.WriteLine("Invalid operation");
                    continue;
                }
                Actions.GetValueOrDefault(choice).DynamicInvoke();
            }
        }

        private void RegistryAndLogin()
        {
            while (UsersController.CurrentUser == null)
            {
                Console.WriteLine("List of actions:");
                Console.WriteLine("1 registration");
                Console.WriteLine("2 login");
                Console.WriteLine("Choose action by number:");
                string choice = Console.ReadLine();
                if (!choice.Equals("1") && !choice.Equals("2"))
                {
                    Console.WriteLine("Invalid operation");
                    continue;
                }
                if (choice == "1")
                {
                   UsersController.RegistryUser();
                }
                else
                {
                    UsersController.Login();
                }
            }
        }
    }
}
