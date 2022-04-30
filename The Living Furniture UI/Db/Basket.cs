﻿using System;
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
    public class Basket
    {
        public Basket(List<Product> product, User user)
        {
            Product = product;
            User = user;

        }
        public ObjectId _id { get; set; }
        public List<Product> Product{ get; set; }
        public User User { get; set; }

        public static void BasketAddToDB(Db.Basket basket)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Basket>("Basket");
            collection.InsertOne(basket);
        }
        public static List<Db.Basket> BasketIsExists()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Basket>("Basket");
            return collection.Find(x => true).ToList();
        }

        public static void EditBasket(List<Product> product,List<Product> newProduct)
        {
            var std = new MongoClient("mongodb://localhost");
            var database = std.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Db.Basket>("Basket");
            var filterCheck = Builders<Db.Basket>.Filter.Eq("Product", product);
            var updateCheck = Builders<Db.Basket>.Update.Set(x => x.Product, newProduct);
            collection.UpdateOne(filterCheck,updateCheck);
        }



    }

}
