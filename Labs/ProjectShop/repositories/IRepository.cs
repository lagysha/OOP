using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShop.repositories
{
    internal interface IRepository<T>
    {
        void Save(T objectT);
        List<T> FindAll();
        T FindByName(string name);

        void Delete(T objectT);
    }
}
