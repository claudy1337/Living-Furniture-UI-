using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace The_Living_Furniture_UI.Db
{
    public class Basket
    {
        public List<Db.ModifyProducts> Product { get; set; } = new List<Db.ModifyProducts>();
        public static List<Basket> ShowProductsInCategory(string category)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("User");
            var collection = database.GetCollection<Basket>(category);
            return collection.Find(x => true).ToList();
        }

    }
    
}
