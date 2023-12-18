using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_24
{
    public class Source
    {
        public int playerId { get; set; }
        public string playerName { get; set; }
        public double playerSalary { get; set; }

    }
    public class Destination
    {
        public int playerId { get; set; }
        public string playerName { get; set; }
        public int playerAge { get; set; }
        public string playerType { get; set; }
        public string playerTeam { get; set; }
    }

    public class Program
    {
        static void MapProperties(Source source, Destination destination)
        {
            PropertyInfo[] sourceProp = typeof(Source).GetProperties();
            PropertyInfo[] destProp = typeof(Destination).GetProperties();
            foreach (var sprop in sourceProp)
            {
                foreach (var dprop in destProp)
                {
                    if (sprop.Name == dprop.Name && sprop.PropertyType == dprop.PropertyType)
                    {
                        dprop.SetValue(destination, sprop.GetValue(source));
                        break;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Source source = new Source { playerId = 100, playerName = "Virat Kohli", playerSalary = 400000 };
            Destination destination = new Destination { playerId = 0, playerName = "", playerAge = 35, playerType = "Batsman", playerTeam = "RCB" };
            MapProperties(source, destination);
            Console.WriteLine("Mapped Properties in Destination are as follows");
            Console.WriteLine($"Player ID: {destination.playerId}");
            Console.WriteLine($"Player Name: {destination.playerName}");
            Console.WriteLine($"Player Age: {destination.playerAge}");
            Console.WriteLine($"Type of Player: {destination.playerType}");
            Console.WriteLine($"Team of the player: {destination.playerTeam}");
            Console.ReadKey();
        }
    }
}
