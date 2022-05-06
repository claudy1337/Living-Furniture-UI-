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
        public static async void AddProductToBasket(string login, ObjectId id, string category, string name, int price,int width, int height, string color, bool structure, string material, string photo)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<User>("User");
            var filterCheck = Builders<Db.User>.Filter.Where(u => u.Login == login);
            var update = Builders<User>.Update.PushEach(x => x.Basket.Product, new[]{
                new ModifyProducts{_id = id, Category = category, Name = name, Price = price, Color = color, Height = height, Width=width, Material = material, Structure = structure, Photo = photo}
            });
            await collection.UpdateOneAsync(filterCheck, update);
        }
        public static void Edit(Object ischeck, string login)
        {
            var std = new MongoClient("mongodb://localhost");
            var database = std.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Db.User>("User");

            var updateCheck = Builders<Db.User>.Update.Set(x => x.Basket.Product, ischeck);
            collection.UpdateOne(x => x.Login == login, updateCheck);

        }

    }
    public class ModifyProducts
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
    }

}
