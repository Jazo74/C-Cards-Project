using System;
using System.Collections.Generic;
using System.Text;

namespace Cardgame
{
    class Table
    {
        Dictionary<string, Card> TableDict = new Dictionary<string, Card>();

        public void PutTable(string playername, Card card)
        {
            TableDict.Add(playername, card);
        }
        public string GetWinner(string parameter)
        {
            string winner = "error";
            float max = 0;
            float min = 1000;

            foreach (KeyValuePair<string, Card> item in TableDict)
            {

                if (parameter == "Consumption")
                {
                    if (item.Value.paramDict[parameter] < min)
                    {
                        min = item.Value.paramDict[parameter];
                        winner = item.Key;
                    }
                }
                else
                {
                    if (item.Value.paramDict[parameter] > max)
                    {
                        max = item.Value.paramDict[parameter];
                        winner = item.Key;
                    }
                }
            }
            return winner;
        }
        public List<Card> GetTable()
        {
            List<Card> cards = new List<Card>();
            foreach (KeyValuePair<string, Card> item in TableDict)
            {
                cards.Add(item.Value);
            }
            return cards;
        }
        public void ResetTable()
        {
            TableDict.Clear();
        }
    }
}
