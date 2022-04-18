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
        public Consultation(string name, string number, bool isCheck)
        {
            Name = name;
            Number = number;
            IsCheck = isCheck;
           

        }
        public ObjectId _id { get; set; }
        public string Name{ get; set; }
        public string Number { get; set; }
        public bool IsCheck { get; set; }

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
            var database = client.GetDatabase("TeamCollection");
            var collection = database.GetCollection<Consultation>("Consultation");
            var listUsersFromDB = collection.Find(x => true).ToList();
            List<string> listToReturn = new List<string>();
            foreach (var item in listUsersFromDB)
            {
                listToReturn.Add(item.Name);
                
            }
            return listToReturn;
        }
    }
    
}
