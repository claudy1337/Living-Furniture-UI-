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
    class Order
    {
        public Order(Product product, bool isOrder)
        {
            Product = product;
            IsOrder = isOrder;
        }
        public ObjectId _id { get; set; }
        public Product Product { get; set; }
        public bool IsOrder { get; set; }
    }
}
