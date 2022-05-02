using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace The_Living_Furniture_UI.Db
{
    public class Basket
    {
        public List<Db.ModifyProducts> Product { get; set; } = new List<Db.ModifyProducts>(); 
    }
    

}
