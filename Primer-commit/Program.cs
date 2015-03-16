using System;
using System.Collections.Generic;
using System.Linq;
using Classes;

namespace MongoDBExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type the number corresponding to the option you are willing to use:");
            Console.WriteLine("Type 1 to use AddLog.");
            Console.WriteLine("Type 2 to use AddLogs.");
            Console.WriteLine("Type 3 to research by Time.");
            Console.WriteLine("Type 4 to research by Name.");
            Console.WriteLine("Type 5 to remove all data stored");
            
            int choice = Convert.ToInt32(Console.ReadLine());
            
            if (choice == 1)
            {
                Console.WriteLine("Type an address.");
                string address = Console.ReadLine();
                Console.WriteLine("Type a value.");
                double value = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the latitude.");
                double lat = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the longitude.");
                double lon = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the altitude.");
                double alt = Convert.ToDouble(Console.ReadLine());

                // This creates the database and executes the AddLog function
                DataBase db = new DataBase();
                db.AddLog(address, value, lat, lon, alt);
            }
            else if (choice == 2)
            {
                List<Entity> LogList = new List<Entity>();

                int confirmation = 1;

                Console.WriteLine("Add as much paired addresses and values as you want.");
                
                // This keeps asking the user for address and value until he wants to stop
                while (confirmation != 0)
                {
                    Entity e = new Entity();
                    Console.WriteLine("Type an address.");
                    string address = Console.ReadLine();
                    e.Address = address;
                    Console.WriteLine("Type a value.");
                    double value = Convert.ToDouble(Console.ReadLine());
                    e.Value = value;
                    Console.WriteLine("Enter the latitude.");
                    double lat = Convert.ToDouble(Console.ReadLine());
                    e.Latitude = lat;
                    Console.WriteLine("Enter the longitude.");
                    double lon = Convert.ToDouble(Console.ReadLine());
                    e.Longitude = lon;
                    Console.WriteLine("Enter the altitude.");
                    double alt = Convert.ToDouble(Console.ReadLine());
                    e.Altitude = alt;

                    LogList.Add(e);

                    Console.WriteLine("Do you wish to continue? (Y=1/N=0)");
                    confirmation = Convert.ToInt32(Console.ReadLine());
                }

                // This creates the database and executes the AddLogs function
                DataBase db = new DataBase();
                db.AddLogs(LogList);
                Console.WriteLine("The logs have been added to the DataBase");

            }

            else if (choice == 3)
            {
                Console.WriteLine("Type the lower value limit");
                double lowlimit = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Type the higher value limit");
                double highlimit = Convert.ToInt32(Console.ReadLine());

                // This creates the database and executes the SearchByTime function
                DataBase db = new DataBase();
                List<Entity> LogList = db.SearchByTime(lowlimit, highlimit);

                int count = LogList.Count;

                // This prints the results of the function in the console
                for (int i = 0; i < count; i++)
                {
                    Entity e = new Entity();
                    e.Address = LogList.ElementAt(i).Address;
                    e.Value = LogList.ElementAt(i).Value;
                    e.Latitude = LogList.ElementAt(i).Latitude;
                    e.Longitude = LogList.ElementAt(i).Longitude;
                    e.Altitude = LogList.ElementAt(i).Altitude;
                    string print1 = Convert.ToString(e.Address);
                    string print2 = Convert.ToString(e.Value);
                    string print3 = Convert.ToString(e.Latitude);
                    string print4 = Convert.ToString(e.Longitude);
                    string print5 = Convert.ToString(e.Altitude);
                    Console.WriteLine("Address: {0}, Value: {1}, Latitude: {2}, Longitude: {3}, Altitude: {4}", print1, print2, print3, print4, print5);
                }
            }

            else if (choice == 4)
            {
                Console.WriteLine("Type the name you wish to search for");
                string name = Convert.ToString(Console.ReadLine());

                // This creates the database and executes the SearchByAddress function
                DataBase db = new DataBase();
                List<Entity> LogList = db.SearchByAddress(name);

                int count = LogList.Count;

                // This prints the results of the function in the console
                for (int i = 0; i < count; i++)
                {
                    Entity e = new Entity();
                    e.Address = LogList.ElementAt(i).Address;
                    e.Value = LogList.ElementAt(i).Value;
                    e.Latitude = LogList.ElementAt(i).Latitude;
                    e.Longitude = LogList.ElementAt(i).Longitude;
                    e.Altitude = LogList.ElementAt(i).Altitude;
                    string print1 = Convert.ToString(e.Address);
                    string print2 = Convert.ToString(e.Value);
                    string print3 = Convert.ToString(e.Latitude);
                    string print4 = Convert.ToString(e.Longitude);
                    string print5 = Convert.ToString(e.Altitude);
                    Console.WriteLine("Address: {0}, Value: {1}, Latitude: {2}, Longitude: {3}, Altitude: {4}", print1, print2, print3, print4, print5);
                }
            }

            else if (choice == 5)
            {
                // This creates the database and executes the RemoveAll function
                DataBase db = new DataBase();
                db.RemoveAll();
            }
        }
    }
}
