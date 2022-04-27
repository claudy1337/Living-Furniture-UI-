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
    public class Product
    {
        public Product(string category, string name, int price, int raiting, int width, int height,string color, bool structure, string material, string logo, string photo, string sizeImage)
        {
            Category = category;
            Name = name;
            Price = price;
            Raiting = raiting;
            Width = width;
            Height = height;
            Color = color;
            Structure = structure;
            Material = material;
            Logo = logo;
            Photo = photo;
            SizeImage = sizeImage;
        }
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Raiting { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }
        public string Category { get; set; }
        public bool Structure { get; set; }
        public string Material { get; set; }
        public string Logo { get; set; }
        public string Photo { get; set; }
        public string SizeImage { get; set; }

        public static Product GetProduct(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Db.Product>("Product");
            var foundedProd = collection.Find(x => x.Name == name ).FirstOrDefault();
            return foundedProd;

        }
        public static void ProductAddtoDb(Db.Product product)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Product>("Product");
            collection.InsertOne(product);
        }

    }
    
}
