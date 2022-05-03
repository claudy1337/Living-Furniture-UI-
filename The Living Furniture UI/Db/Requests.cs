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
        public Requests(string name, string material, string type, string size, User user, bool ischeck)
        {
            Name = name;
            Material = material;
            Type = type;
            Size = size;
            User = user;
            isCheck = ischeck;
        }
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public bool isCheck { get; set; }
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
        public static Requests GetisRequest(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Requests>("Request");
            var foundedUser = collection.Find(x => x.Name == name).FirstOrDefault();
            return foundedUser;
        }
        public static void EditRequests(bool IsCheeck, string login)
        {
            var std = new MongoClient("mongodb://localhost");
            var database = std.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Db.Requests>("Request");
         
            var updateCheck = Builders<Db.Requests>.Update.Set(x => x.isCheck, IsCheeck);
            collection.UpdateOne(x => x.User.Login == login, updateCheck);//редактирование
           
        }
    }
}
