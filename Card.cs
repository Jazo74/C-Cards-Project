using System;
using System.Collections.Generic;
namespace Cardgame
{
    public class Card
    { 
        public string Brand { get; }
        public string Type { get; }
        public string Country {get; }
        public Dictionary<string, float> paramDict = new Dictionary<string, float>();

        public Card(string brand, string type, string country, float cylinders, float enginecap, float horsepower, float maxspeed, float consumption)
        {
            Brand = brand; 
            Type = type;
            Country = country;
            paramDict.Add("Cylinders", cylinders);
            paramDict.Add("EngineCap", enginecap);
            paramDict.Add("HorsePower", horsepower);
            paramDict.Add("MaxSpeed", maxspeed);
            paramDict.Add("Consumption", consumption);
        }

        public override string ToString()
        {
            return Brand + " - " + Type + " - " + Country + " - " + paramDict["Cylinders"] + " - " + paramDict["EngineCap"] + " - " + paramDict["HorsePower"] + " - " + paramDict["MaxSpeed"] + " - " + paramDict["Consumption"]; ;
        }
    }
}
