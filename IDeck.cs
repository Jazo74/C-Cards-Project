using System;
namespace Cardgame
{
    public interface IDeck
    {
        public int GetNumberOfCards();
        public Card GetTopCard();
        public void Shuffle();
    }
}
