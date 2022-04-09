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
    class Product
    {
        public Product(string name, int price, int raiting, string width, string height,string color, bool structure, string material, string logo, string photo)
        {
            Name = name;
            Price = price;
            Raiting = raiting;
            Width = width;
            Height = height;
            Height = height;
        }
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Raiting { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Color { get; set; }
        public bool Structure { get; set; }
        public string Material { get; set; }
        public string Logo { get; set; }
        public string Photo { get; set; }
    }
}
