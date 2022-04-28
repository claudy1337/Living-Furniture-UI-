using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace The_Living_Furniture_UI.Db
{
    public class ImageCollection
    {
        public ImageCollection(string paths, string category)
        {
            Paths = paths;
            Category = category;
        }
        public ObjectId _id { get; set; }
        public string Paths { get; set; }
        public string Category { get; set; }
        public static ImageCollection GetisImage(string paths)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Db.ImageCollection>("Consultation");
            var foundedUser = collection.Find(x => x.Paths == paths).FirstOrDefault();
            return foundedUser;
        }
    }
}
