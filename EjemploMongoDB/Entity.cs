using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using GeoJSON;
using GeoJSON.Net.Geometry;
using GeoJSON.Net.Converters;


namespace Classes
{
        public class Entity
        {
            public ObjectId Id { get; set; }

            public string Address { get; set; }

            public double Value { get; set; }

            public int SearchTime { get; set; }

            public DateTime Time { get; set; }    

            public GeographicPosition Position { get; set; }

        }

}

