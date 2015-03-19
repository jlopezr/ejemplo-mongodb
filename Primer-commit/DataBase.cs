using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using GeoJSON;
using GeoJSON.Net.Geometry;
using GeoJSON.Net.Converters;

namespace Classes
{
    public class DataBase
    {
        public void AddLog(String address, double value, double latitude, double longitude)
        {
            // This connects to the server
            var connectionString = "mongodb://127.0.0.1";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("DatosAereos");

            // This builds a new instance
            Entity e = new Entity();
            e.Address = address;
            e.Value = value;
            e.Position = new GeographicPosition(latitude, longitude);
            e.Time = DateTime.Now.AddHours(1);
            e.SearchTime = (e.Time.Hour-1) * 3600 + e.Time.Minute * 60 + e.Time.Second;

            
            // This adds it to MongoDB
            var collection = database.GetCollection<Entity>("log");            
            collection.Insert(e);
            var id = e.Id;
        }

        public void AddLogs(List<Entity> LogList)
        {
            // This connects to the server
            var connectionString = "mongodb://127.0.0.1";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("DatosAereos");
            
            // This loops through the list entered so that every Entity is added
            for (int i = 0; i < LogList.Count; i++)
            {
                // This builds a new instance
                Entity e = new Entity();
                e.Address = LogList.ElementAt(i).Address;
                e.Value = LogList.ElementAt(i).Value;
                e.Position = LogList.ElementAt(i).Position;
                e.Time = LogList.ElementAt(i).Time;

                // This adds it to MongoDB
                var collection = database.GetCollection<Entity>("log");
                collection.Insert(e);
                var id = e.Id;
            }
        }

        public List<Entity> SearchByTime(double LowTime, double HighTime)
        {
            // This connects to the server and gets the desired collection
            var connectionString = "mongodb://127.0.0.1";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("DatosAereos");
            var collection = database.GetCollection<Entity>("log");

            // This creates the query to search for addresses within the desired time interval
            var query = Query.And(Query.GTE("SearchTime", LowTime), Query.LTE("SearchTime", HighTime));
            var resultsCursor = collection.Find(query).SetSortOrder("SearchTime");

            // This sends the results to a list
            var results = resultsCursor.ToList();
            
            // This returns the list
            return results;

        }

        public List<Entity> SearchByAddress(string address)
        {
            // This connects to the server and gets the desired collection
            var connectionString = "mongodb://127.0.0.1";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("DatosAereos");
            var collection = database.GetCollection<Entity>("log");

            // This creates the query to search for the log(s) with the desired address
            var query = Query.EQ("Address", address);
            var resultsCursor = collection.Find(query).SetSortOrder("Value");

            // This sends the results to a list
            var results = resultsCursor.ToList();

            // This returns the list
            return results;
        }
        
        public void RemoveAll()
        {
            // This connects to the server and gets the desired collection
            var connectionString = "mongodb://127.0.0.1";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("DatosAereos");
            var collection = database.GetCollection<Entity>("log");

            // This deletes all the content inside the collection
            collection.RemoveAll();
        }

        public List<Entity> NearQuery(double Lat, double Long)
        {
            // This merges Lat and Long into a GeographicPosition
            var GeoPos = new GeographicPosition(Lat, Long);
            // This creates a Point with the coordinates
            Point pt = new Point(GeoPos);
            int i = 1;
            List<Entity> lol = new List<Entity>();
            return lol;
        }

    }
}

