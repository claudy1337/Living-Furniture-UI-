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
    [BsonIgnoreExtraElements]
    public class Trash
    {
        public ObjectId Id { get; set; }
        public List<Test> Products = new List<Test>();


        public static async void AddToCliensCart(string login, string name, string price)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<User>("User");
            var filterCheck = Builders<Db.User>.Filter.Where(u => u.Login == login);
            var update = Builders<User>.Update.PushEach(x => x.Trash.Products, new[]{
                new Test{Name = name, Price = price }
            });
            await collection.UpdateOneAsync(filterCheck, update);
        }

        public static async Task<IEnumerable<Test>> GetProducts()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Test>("User");
            var cursor = await collection.Find(x => true).ToListAsync();
            //var entity = cursor.FirstOrDefaultAsync().ConfigureAwait(false);
            return cursor;

        }
        public static void Method()
        {
            GetProducts().GetAwaiter().GetResult();
        }
    }
    public class Test
    {
        public string Name { get; set; }
        public string Price { get; set; }

    }
}
