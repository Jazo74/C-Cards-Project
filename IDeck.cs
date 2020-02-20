using System;
using System.Collections.Generic;
namespace Cardgame
{
    public interface IDeck
    {
        public int GetNumberOfCards();
        public Card GetTopCard();
        public void Shuffle();
        public List<string> GetParameters();
        public void ResetDeck();
    }
}
