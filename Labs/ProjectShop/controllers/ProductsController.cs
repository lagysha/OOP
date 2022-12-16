using ProjectShop.models;
using ProjectShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShop.controllers
{
    internal class ProductsController
    {
        private ProductsService ProductsService { get; set; }

        public ProductsController(DBContext dBContext)
        {
            ProductsService = new ProductsService(dBContext);
        }

        public void ShowAllProducts()
        {
            Console.WriteLine("All avaliable products");
            int number = 1;
            ProductsService.FindAll().ForEach(e => Console.WriteLine("Number: " +(number++)+ " Product:\t" +e.Name + "\t Price: " + e.Price));
        }
    }
}
