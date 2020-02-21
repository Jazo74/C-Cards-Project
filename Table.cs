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
            foreach (KeyValuePair<string, Card> card in TableDict)
            {
                if (card.Value.paramDict[parameter] > max)
                {
                    max = card.Value.paramDict[parameter];
                    winner = card.Key;
                }
            }
            return winner;
        }
        public Dictionary<string,Card> GetTable()
        {
            return TableDict;
        }
        public void ResetTable()
        {
            TableDict.Clear();
        }
    }
}
