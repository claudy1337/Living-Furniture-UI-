using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace The_Living_Furniture_UI.Db
{
    class User
    {
        public User(string login, string password, string name, string country, int card, string address )
        {
            Login = login;
            Password = password;    
            Name = name;
            Country = country;
            Card = card;
            Address = address;

        }
        public ObjectId _id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Card { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public static void usrAddToDB(User user)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<User>("User");
            collection.InsertOne(user);
        }
    }
    
}
