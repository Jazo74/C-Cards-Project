using System;
using System.Collections.Generic;

namespace Cardgame
{
    public class AIPlayer : Player
    {
        Dictionary<string, float> minValues = new Dictionary<string, float>();
        Dictionary<string, float> maxValues = new Dictionary<string, float>();
        Dictionary<string, float> chance = new Dictionary<string, float>();
        Card topCard;

        public AIPlayer(string name, string type) : base(name, type) 
        {
        }

        public override Card GetTopCard()
        {
            topCard = base.GetTopCard();
            MachineLearning();
            return topCard;
        }
        private void MachineLearning()
        {
            foreach (KeyValuePair<string, float> item in topCard.paramDict)
            {
                if (!minValues.ContainsKey(item.Key)) { minValues.Add(item.Key, item.Value); }
                else
                {
                    if (item.Value < minValues[item.Key]) { minValues[item.Key] = item.Value; }
                }
                if (!maxValues.ContainsKey(item.Key)) { maxValues.Add(item.Key, item.Value); }
                else
                {
                    if (item.Value > maxValues[item.Key]) { maxValues[item.Key] = item.Value; }
                }
            }
        }
        public override string ChooseParameter()
        {
            chance.Clear();
            return AIChoice();
        }
        private void CalculateChance()
        {
            foreach (KeyValuePair<string, float> item in topCard.paramDict)
            {
                float min = item.Value - minValues[item.Key];
                float max = maxValues[item.Key] - minValues[item.Key];
                if (max == 0) { max = 1; }
                //Console.WriteLine(item.Key + " - " + min/max);
                chance.Add(item.Key, min / max);
            }
        }
        private string AIChoice()
        {
            float max = -1;
            string bestChoice = "";
            CalculateChance();
            foreach (KeyValuePair<string, float> item in chance)
            {
                if (item.Value > max)
                {
                    max = item.Value;
                    bestChoice = item.Key;
                }
            }
            chance.Clear();
            return bestChoice;
        }
    }
}
