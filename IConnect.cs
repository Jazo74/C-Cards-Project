using System;
using System.Collections.Generic;
namespace Cardgame
{
    public interface IConnect
    {
        public void AddCard(Card card);
        public void YouWon(List<Card> cards);
        public string ChooseParameter();
    }
}
