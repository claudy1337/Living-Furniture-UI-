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
        public List<Db.OrderedProduct> Product { get; set; } = new List<Db.OrderedProduct>();
        public static async void AddProductToOrder(string login, ObjectId id, string category, string name, int price, int width, int height, string color, bool structure, string material, string photo, int code, bool status)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<User>("User");
            var filterCheck = Builders<Db.User>.Filter.Where(u => u.Login == login);
            var update = Builders<User>.Update.PushEach(x => x.Order.Product, new[]{
                new OrderedProduct{_id = id, Category = category, Name = name, Price = price, Color = color, Height = height, Width=width, Material = material, Structure = structure, Photo = photo, OrderCode = code, Status = status}
            });
            await collection.UpdateOneAsync(filterCheck, update);
        }
       


    }
    public class OrderedProduct
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }
        public string Category { get; set; }
        public bool Structure { get; set; }
        public string Material { get; set; }
        public string Photo { get; set; }
        public int OrderCode { get; set; }
        public bool Status { get; set; }

    }
}
