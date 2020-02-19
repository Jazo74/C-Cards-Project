using System;
using System.Collections.Generic;
using System.IO;

namespace Cardgame
{
    public class Deck : IDeck
    {
        List<Card> listOfCards = new List<Card>();
        Random rnd = new Random();

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
                listOfCards.Add(card);
            }
            sr.Close();
        }

        public int GetNumberOfCards()
        {
            return listOfCards.Count;
        }

        public List<string> GetParameters()
        {
            List<string> returnList = new List<string>();
            foreach (KeyValuePair<string, float> item in listOfCards[0].paramDict)
            {
                returnList.Add(item.Key);
            }
            return returnList;
        }

        public Card GetTopCard()
        {
            Card card = listOfCards[0];
            listOfCards.RemoveAt(0);
            return card;
        }

        public void Shuffle()
        {
            List<int> indexList = new List<int>();
            int index;
            while (indexList.Count < 30)
            {
                index = rnd.Next(0, 30);
                if (!indexList.Contains(index))
                {
                    indexList.Add(index);
                }
            }
            List<Card> tempList = new List<Card>();
            foreach (int index2 in indexList)
            {
                tempList.Add(listOfCards[index2]);
            }
            listOfCards = tempList;
        }
    }
}
