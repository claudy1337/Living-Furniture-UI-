using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace The_Living_Furniture_UI.Db
{
    public class ModifyProducts
    {
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
    }
}
