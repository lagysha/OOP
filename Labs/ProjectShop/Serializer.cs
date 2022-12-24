using ProjectShop.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectShop
{
    internal class Serializer
    {
        public void SerializeData(String fileName, object o)
        {
            string jsonString = JsonSerializer.Serialize(o);
            File.WriteAllText(fileName, jsonString);
        }
        public DBContext DeserializeData(String fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            try
            {
                return JsonSerializer.Deserialize<DBContext>(jsonString);
            }
            catch
            {
                return new DBContext();
            }

        }
    }
}
