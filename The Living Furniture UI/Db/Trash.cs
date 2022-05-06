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
        public Trash(string name, string price)
        {
            Price = price;
            Name = name;
        }
        public string Name { get; set; }
        public string Price { get; set; }
    }

}
