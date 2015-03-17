using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;



namespace Classes
{
        public class Entity
        {
            public ObjectId Id { get; set; }

            public string Address { get; set; }

            public double Value { get; set; }

            public double Latitude { get; set; }

            public double Longitude { get; set; }

            public double Altitude { get; set; }
            
            public IPosition Position { get; set; }

            // DateTime.Now
        }

}
