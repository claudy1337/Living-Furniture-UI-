using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace The_Living_Furniture_UI.Db
{
    public class Consultation
    {
        public Consultation(string name, string number, bool ischeck)
        {
            Name = name;
            Number = number;
            isCheck = ischeck;
        }
        public ObjectId _id { get; set; }
        public string Name{ get; set; }
        public string Number { get; set; }
        public bool isCheck { get; set; }

        public static void SendToConsultation(Db.Consultation consultation)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Consultation>("Consultation");
            collection.InsertOne(consultation);
        }
        public static List<string> GetConsList()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Consultation>("Consultation");
            var listUsersFromDB = collection.Find(x => x.isCheck == false).ToList();
            List<string> listToReturn = new List<string>();
            foreach (var item in listUsersFromDB)
            {
                listToReturn.Add(item.Number);
            }
            return listToReturn;
        }
        public static Consultation GetisCheckCons(string number)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Db.Consultation>("Consultation");
            var foundedUser = collection.Find(x => x.Number == number).FirstOrDefault();
            return foundedUser;
        }
        public static List<string> GetAllConsList()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Consultation>("Consultation");
            var listUsersFromDB = collection.Find(x=> true).ToList();
            List<string> listToReturn = new List<string>();
            foreach (var item in listUsersFromDB)
            {
                listToReturn.Add(item.Number);
            }
            return listToReturn;
        }
        public static void UpdateCons(Consultation consultation, string number)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Consultation>("Consultation");
            collection.ReplaceOne(x => x.Number == number, consultation);
        }
    }
    
}
