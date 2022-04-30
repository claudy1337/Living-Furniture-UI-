using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using The_Living_Furniture_UI.Db;

namespace The_Living_Furniture_UI.Db
{
    public class Admin
    {
        public Admin(string name, string login ,string password, string role, string photo)
        {
            Name = name;
            Login = login;
            Password = password;
            Role = role;
            Photo = photo;

        }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string Role { get; set; }
        public string Photo { get; set; }

        public static List<Db.Admin> AdminIsExists(string login, string password)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("FurnitureBD");
            var collection = database.GetCollection<Db.Admin>("User");
            return collection.Find(x => x.Login == login && x.Password == password).ToList();
        }
    }
}
