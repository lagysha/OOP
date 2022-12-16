using ProjectShop.models;
using ProjectShop.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShop.Services
{
    internal class ProductsService
    {
        private ProductsRespository ProductsRepository { get; set; }
        public ProductsService(DBContext dBContext)
        {
            ProductsRepository = new ProductsRespository(dBContext);
        }

        public List<Product> FindAll()
        {
            return ProductsRepository.FindAll();
        }
    }
}
