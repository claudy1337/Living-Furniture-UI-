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
        public Consultation(string name, string number)
        {
            Name = name;
            Number = number;

        }
        public ObjectId _id { get; set; }
        public string Name{ get; set; }
        public string Number { get; set; }
        public static void SendToConsultation(Db.Consultation consultation)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Consultation>("Consultation");
            collection.InsertOne(consultation);
        }
    }
    
}
