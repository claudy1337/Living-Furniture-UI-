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
    class Requests
    {
        public Requests(string name, string material, string type, string size, User user)
        {
            Name = name;
            Material = material;
            Type = type;
            Size = size;
            User = user;
        }
        public ObjectId _id { get; set; }
        public int id { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public string Number { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public User User { get; set; }

        public static void requestAddToDB(Requests requests)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Db.Requests>("Request");
            collection.InsertOne(requests);
        }
        public static List<string> GetRequestList()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Requests>("Request");
            var listUsersFromDB = collection.Find(x => true).ToList();
            List<string> listToReturn = new List<string>();
            foreach (var item in listUsersFromDB)
            {
                listToReturn.Add(item.Name);
            }
            return listToReturn;
        }
        public static Requests GetRequest(string number)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Requests>("Request");
           
            var foundedUser = collection.Find(x => x.Number == number).FirstOrDefault();
            return foundedUser;
        }
    }
}
