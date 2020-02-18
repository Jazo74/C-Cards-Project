using System;
namespace Cardgame
{
    public class Card
    { 
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Country {get; set; }
        public float Cylinders { get; set; }
        public float EngineCap {get; set ;}
        public float HorsePower { get; set; }
        public float MaxSpeed { get; set; }
        public float Consumption { get; set; }



        public Card(string brand, string type, string country, float cylinders, float enginecap, float horsepower, float maxspeed, float consumption)
        {
            Brand = brand; 
            Type = type;
            Country = country;
            Cylinders = cylinders;
            EngineCap = enginecap;
            HorsePower = horsepower;
            MaxSpeed = maxspeed;
            Consumption = consumption;
            
        }
    }
}
