using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using The_Living_Furniture_UI.Db;

namespace The_Living_Furniture_UI.Db
{
    public class Basket
    {
        public Basket(string name, string size, string material, string image)
        {
            Name = name;
            Size = size;
            Material = material;
            Image = image;
            
        }
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public string Image { get; set; }
       
        
        public static List<Product> GetBasketList()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Basket>("Basket");
            var listUsersFromDB = collection.Find(x => true).ToList();
            List<Product> listToReturn = new List<Product>();
            foreach (var item in listUsersFromDB)
            {
                
            }
            return listToReturn;
        }

        public static List<Product> Showprods()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Product>("Basket");
            return collection.Find(x => true).ToList();
        }
        public static Basket GetBasket(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Basket>("Basket");
            var foundedUser = collection.Find(x => x.Name == name).FirstOrDefault();
            return foundedUser;
        }
    }

}
