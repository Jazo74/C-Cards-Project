﻿using System;
using System.Collections.Generic;
namespace Cardgame.Core
{
    public interface IConnect
    {
        public void AddCard(Card card);
        public void YouWon(List<Card> cards);
        public string ChooseParameter();
    }
}
