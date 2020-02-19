using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Cardgame
{
    class Dealer
    {
        IDeck myDeck;
        List<Player> listOfPlayers = new List<Player>();
        Table table = new Table();
        Random rnd = new Random();
        List<string> param;

        public Dealer(Deck deck)
        {
            myDeck = deck;
        }

        private void Dealing()
        {
            while (myDeck.GetNumberOfCards() > 0)
            {
                foreach (Player player in listOfPlayers)
                {
                    player.AddCard(myDeck.GetTopCard());
                }
            }
        }
        private string ChooseFirtsPlayer()
        {
            return listOfPlayers[rnd.Next(0, listOfPlayers.Count - 1)].Name;
        }

        private void AddPlayers()
        {
            listOfPlayers.Clear();
            Console.WriteLine("Number of players?: ");
            int numberOfPlayers = int.Parse(Console.ReadLine());
            for (int number = 1; number < numberOfPlayers+1; number++)
            {
                Console.WriteLine("The type of the " + number.ToString() + ". player? ('human' or 'ai'): ");
                string typeOfPlayer = Console.ReadLine();
                Console.WriteLine("The name of the " + number.ToString() + ". player?: ");
                string nameOfPlayer = Console.ReadLine();
                if (typeOfPlayer.ToLower() == "human")
                {
                    listOfPlayers.Add(new Player(typeOfPlayer, nameOfPlayer));
                }
                else if (typeOfPlayer.ToLower() == "ai")
                {
                    listOfPlayers.Add(new AIPlayer(typeOfPlayer, nameOfPlayer));
                }
                else
                {

                }
            }
        }

        private void Play(string firstPlayer)
        {
            int round = 1;
            bool run = true;
            while (run)
            {
                string parameter = "error";
                string winner = "error";
                List<Card> loot = new List<Card>();
                foreach (Player player in listOfPlayers)
                {
                    if (player.Name == firstPlayer)
                    {
                        table.PutTable(player.Name, player.GetTopCard());
                        parameter = player.ChooseParameter();
                        if (parameter == "human")
                        {
                            parameter = ChooseParameterManual();
                        }
                        if (!param.Contains(parameter))
                        {

                        }
                    }
                }
                // showing the first player card
                Console.WriteLine("showing the first player card");
                foreach (Player player in listOfPlayers)
                {
                    if (player.Name != firstPlayer)
                    {
                        table.PutTable(player.Name, player.GetTopCard());
                    }
                }
                // showing the rest of the cards
                Console.WriteLine("showing the rest of the cards");

                foreach (Player player in listOfPlayers)
                {
                    if (player.GetNumberOfCards() == 0)
                    {
                        run = false;
                    }
                }
                winner = table.GetWinner(parameter);
                firstPlayer = winner;
                loot = table.GetTable();
                foreach (Player player in listOfPlayers)
                {
                    if (player.Name == winner)
                    {
                        player.YouWon(loot);
                    }
                }
                Console.WriteLine("The " + round.ToString() + ". winner is: " + winner);
                round++;
            }
        }
        private string ChooseParameterManual()
        {
            Console.WriteLine("Choose a winning parameter: ");
            return Console.ReadLine();
        }
        public void showMenu(string[] menupoints)
        {
            int index = 1;
            foreach (string point in menupoints)
            {
                Console.WriteLine("(" + index + ") " + point);
                index++;
            }
        }
        public void start()
        {
            string[] menupoints = new string[]
            {
                "(1) Play",
                "(0) End Program"
            };
            while (true)
            {
                showMenu(menupoints);
                Console.WriteLine("Type in your choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    case 1:
                        {
                            AddPlayers();
                            param = myDeck.GetParameters();
                            Dealing();
                            Play(ChooseFirtsPlayer());
                            break;
                        }
                }
            }
        }
    }
}
