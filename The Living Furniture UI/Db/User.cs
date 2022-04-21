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
    public class User
    {
        public User(string login, string password, string name, int card, string address, Order order, Basket basket )
        {
            Login = login;
            Password = password;    
            Name = name;
            Order = order;
            Basket = basket;
            Card = card;
            Address = address;

        }
        public ObjectId _id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Card { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public Order Order { get; set; }
        public Basket Basket { get; set; }
        

        public static void usrAddToDB(Db.User user)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<User>("User");
            collection.InsertOne(user);
        }
        public async static void usrUpdate(Db.User user)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<User>("User");
           //var result = await collection.ReplaceOneAsync(new BsonDocument(user);
                
            //var people = await collection.Find(new BsonDocument()).ToListAsync();
        }
        public static List<string> GetAllUserList()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<User>("User");
            var listUsersFromDB = collection.Find(x => true).ToList();
            List<string> listToReturn = new List<string>();
            foreach (var item in listUsersFromDB)
            {
                listToReturn.Add(item.Login);
            }
            return listToReturn;
        }
        public static User GetUser(string login)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Db.User>("User");
            var foundedUser = collection.Find(x => x.Login == login).FirstOrDefault();
            return foundedUser;
        }

    }
    
}
