using System;
using System.Collections.Generic;
namespace Cardgame.Core
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
