using System;
using System.Collections.Generic;
using System.IO;

namespace Cardgame
{
    public class Deck : IDeck
    {
        List<Card> listOfCard = new List<Card>();
        public Deck(string fileName)
        {
            LoadCSV(fileName);
        }

        public void LoadCSV(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] split = line.Split(";");
                string country = split[0];
                string brand = split[1];
                string type = split[2];
                float cylinders = float.Parse(split[3]);
                float enginecap = float.Parse(split[4]);
                float horsepower = float.Parse(split[5]);
                float maxspeed = float.Parse(split[6]);
                float consumption = float.Parse(split[7]);
                Card card = new Card(brand,type,country,cylinders,enginecap,horsepower,maxspeed,consumption);
                listOfCard.Add(card);
            }

            
        }

        

        public int GetNumberOfCards()
        {
            throw new NotImplementedException();
        }

        public Card GetTopCard()
        {
            throw new NotImplementedException();
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }
    }
}
