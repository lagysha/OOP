using ProjectShop.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShop.repositories
{
    internal class ProductsRespository : IRepository<Product>
    {

        DBContext DBContext { get; set; }
        public ProductsRespository(DBContext dBContext)
        {
            DBContext = dBContext;
        }

        public void Save(Product objectT)
        {
           DBContext.AddProduct(objectT);
        }

        public List<Product> FindAll()
        {
            return DBContext.Products;
        }
        public Product FindById(int id)
        {
            return DBContext.Products[id];
        }

        public Product FindByName(string name)
        {
            return DBContext.Products.FirstOrDefault(product => product.Name.Equals(name));
        }

        public void Delete(Product objectT)
        {
            DBContext.Products.Remove(DBContext.Products.FirstOrDefault(product => product.Name.Equals(objectT.Name)));
        }
    }
}
