using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EjemploMongoDB
{
    class Program
    {
        public class Entity
        {
            public ObjectId Id { get; set; }

            public string Address { get; set; }

            public double Value { get; set; }
        }

        static void Main(string[] args)
        {
            // Esto se conecta al servidor
            var connectionString = "mongodb://10.211.55.1";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("DatosAereos");

            // Esto construye una nueva instancia
            Entity e = new Entity();
            e.Address = "altimeter";
            e.Value = 100;

            // Esto lo sube al mongodb
            var collection = database.GetCollection<Entity>("log");
            collection.Insert(e);
            var id = e.Id;
        }
    }
}
