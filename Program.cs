using System;

namespace Cardgame
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = "15,2";
            float y = float.Parse(x);
            Console.WriteLine("ok");
            Deck deck = new Deck("cards.csv");
            Console.ReadLine();
        }
        
        
    }
}
    
