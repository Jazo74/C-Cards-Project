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

        public Card(string brand, string type, string country, float weight, float enginecap, float horsepower, float maxspeed, float consumption)
        {
            Brand = brand; 
            Type = type;
            Country = country;
            paramDict.Add("Weight", weight);
            paramDict.Add("EngineCap", enginecap);
            paramDict.Add("HorsePower", horsepower);
            paramDict.Add("MaxSpeed", maxspeed);
            paramDict.Add("Consumption", consumption);
        }

        public override string ToString()
        {
            return Brand.PadRight(14)
                + Type.PadRight(22)
                + " from " + Country.PadRight(13) + " : "
                + (paramDict["Weight"] + " kg. - ").PadRight(8)
                + (paramDict["EngineCap"] + " cm3 - ").PadLeft(11)
                + (paramDict["HorsePower"] + " LE - ").PadLeft(9)
                + (paramDict["MaxSpeed"] + " kmh - ").PadLeft(10)
                + (paramDict["Consumption"] + " l").PadLeft(6); 
        }
    }
}
