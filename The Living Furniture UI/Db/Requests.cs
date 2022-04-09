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
        public Requests(string name, string number, string type, string size, User user)
        {
            Name = name;
            Number = number;
            Type = type;
            Size = size;
            User = user;
        }
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public User User { get; set; }

        public static void SendToDB(Requests request)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Requests>("Request");
            collection.InsertOne(request);
        }
    }
}
