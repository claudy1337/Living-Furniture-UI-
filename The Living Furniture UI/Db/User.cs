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
        public User(string login, string password, string name, int card, string address,string photo, Order order, Basket basket)
        {
            Login = login;
            Password = password;    
            Name = name;
            Order = order;
            Card = card;
            Address = address;
            Photo = photo;
            Basket = basket;
            
        }
        public ObjectId _id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Card { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public Order Order { get; set; }
        public Basket Basket { get; set; }
        public static void usrAddToDB(Db.User user)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<User>("User");
            collection.InsertOne(user);
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
        public static List<string> SearchUser(string value, string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Db.User>("User");
            var listUsersFromDB = collection.Find(x => x.Login == value || x.Name == name).ToList();
            List<string> listToReturn = new List<string>();
            foreach (var item in listUsersFromDB)
            {
                listToReturn.Add(item.Login);
            }
            return listToReturn;
        }
        public static void EditUser(string login, string address)
        {
            var std = new MongoClient("mongodb://localhost");
            var database = std.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Db.User>("User");
            var update = Builders<Db.User>.Update.Set(x => x.Address, address);
            collection.UpdateOne(x => x.Login == login, update);//редактирование
        }
        public static List<Db.User> UserIsExists(string login, string password)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<User>("User");
            return collection.Find(x => x.Login == login && x.Password == password).ToList();
        }

    }
    
}
