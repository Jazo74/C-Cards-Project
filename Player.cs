using System;
using System.Collections.Generic;
namespace Cardgame
{
    public class Player : IDeck, IConnect
    {
        List<Card> hand;
        public string Name { get; }
        public string Type { get; }

        public Player(string type, string name )
        {
            hand = new List<Card>();
            Name = name;
            Type = type;
        }

        public int GetNumberOfCards()
        {
            return hand.Count;
        }

        public virtual Card GetTopCard()
        {
            Card card = hand[0];
            hand.RemoveAt(0);
            return card;
        }

        public void AddCard(Card card)
        {
            hand.Add(card);
        }

        public void YouWon(List<Card> cards)
        {
            foreach (Card card in cards)
            {
                hand.Add(card);
            }
        }

        public virtual string ChooseParameter()
        {
            return "human";
        }

        public void Shuffle() { }

        public List<string> GetParameters()

        {
            throw new NotImplementedException();
        }

        public void ResetDeck()
        {
            hand.Clear();
        }
    }
}
