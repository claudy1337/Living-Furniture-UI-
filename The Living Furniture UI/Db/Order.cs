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
    public class Order
    {
        public Order(User user, List<ModifyProducts> modifyProducts, DateTime time)
        {
            User = user;
            date = time;
            Products = modifyProducts;

        }
        public User User { get; set; }
        public List<ModifyProducts> Products { get; set; }
        public ObjectId _id { get; set; }
        public DateTime date { get; set; }
        public static void ProductAddToOrder(Order order)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Db.Order>("Order");
            collection.InsertOne(order);
        }
        public static List<string> GetOrderList(string login)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Order>("Order");
            var listUsersFromDB = collection.Find(x => x.User.Login == login).ToList();
            List<string> listToReturn = new List<string>();
            foreach (var item in listUsersFromDB)
            {
                listToReturn.Add(item._id.ToString());
            }
            return listToReturn;
        }
        public static List<string> GetAllOrderList()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Order>("Order");
            var listUsersFromDB = collection.Find(x => true).ToList();
            List<string> listToReturn = new List<string>();
            foreach (var item in listUsersFromDB)
            {
                listToReturn.Add(item.User.ToString());
            }
            return listToReturn;
        }
        
    }
}
