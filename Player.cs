using System;
using System.Collections.Generic;
namespace Cardgame
{
    public class Player : IDeck, IConnect
    {
        List<Card> hand;
        public string Name { get; }
        public string Type { get; }
        Random rnd = new Random();

        public Player(string name, string type )
        {
            hand = new List<Card>();
            Name = name;
            Type = type;
        }

        public int GetNumberOfCards()
        {
            return hand.Count;
        }

        public Card GetTopCard()
        {
            Card card = hand[0];
            hand.RemoveAt(0);
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
                tempList.Add(hand[index2]);
            }
            hand = tempList;
        }
    
    }
}
