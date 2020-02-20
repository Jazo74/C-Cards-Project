﻿using System;
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
        private void ShowCards(Dictionary<string,Card> cards)
        {
            string brands = "|";
            string types = "|";
            string countries = "|";
            string weights = "|";
            string enginecap = "|";
            string horsepower = "|";
            string maxspeed = "|";
            string consuption = "|";
            string line = " ";
            for (int count = 0; count < cards.Count; count++)
            {
                line += "-----------------------";
                for (int c = 0; c < count; c++)
                {
                    line += "-";
                }
                
            }
            foreach (KeyValuePair<string,Card> card in cards)
            {
                brands += card.Value.Brand.PadRight(22) + " | ";
                types += card.Value.Type.PadRight(22) + " | ";
                countries += card.Value.Country.PadRight(22) + " | ";
                weights += (card.Value.paramDict["Weight"].ToString() + " kg").PadRight(22) + " | ";
                enginecap += (card.Value.paramDict["EngineCap"].ToString() + " cm3").PadRight(22) + " | ";
                horsepower += (card.Value.paramDict["HorsePower"].ToString() + " LE").PadRight(22) + " | ";
                maxspeed += (card.Value.paramDict["MaxSpeed"].ToString() + " kmh").PadRight(22) + " | ";
                consuption += (card.Value.paramDict["Consumption"].ToString() + " l").PadRight(22) + " | ";
            }
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(brands);
            Console.WriteLine(types);
            Console.WriteLine(countries);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(weights);
            Console.WriteLine(enginecap);
            Console.WriteLine(horsepower);
            Console.WriteLine(maxspeed);
            Console.WriteLine(consuption);
            Console.WriteLine(line);
        }
        private void Looting(string winner)
        {
            List<Card> loot = new List<Card>();
            foreach (KeyValuePair<string, Card> hand in table.GetTable())
            {
                loot.Add(hand.Value);
            }
            foreach (Player player in listOfPlayers)
            {
                if (player.Name == winner)
                {
                    player.YouWon(loot);
                }
            }
        }
        private void AddPlayers()
        {
            listOfPlayers.Clear();
            int numberOfPlayers = 0;
            string typeOfPlayer = "";
            string nameOfPlayer = "";
            while (true)
            {
                try
                {
                    Console.Write("Number of players?: ");
                    numberOfPlayers = int.Parse(Console.ReadLine());
                    if (numberOfPlayers > 4 || numberOfPlayers < 2)
                    {
                        throw new NumberOfPlayerException();
                    }
                    break;
                }
                catch (NumberOfPlayerException)
                {
                    Console.WriteLine("The number of player should be between 2 and 4");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong input");
                }
               }

            for (int number = 1; number < numberOfPlayers + 1; number++)
            {
                while (true)
                {
                    try
                    {
                        Console.Write("The type of the " + number.ToString() + ". player? ('human' or 'ai'): ");
                        typeOfPlayer = Console.ReadLine();
                        if (typeOfPlayer.ToLower() != "human" && typeOfPlayer.ToLower() != "ai")
                        {
                            throw new WrongPlayertypeException();
                        }
                        break;
                    }
                    catch (WrongPlayertypeException)
                    {
                        Console.WriteLine("Player type should be 'human' or 'ai'");
                    }
                }
                while (true)
                {
                    try
                    {
                        Console.Write("The name of the " + number.ToString() + ". player?: ");
                        nameOfPlayer = Console.ReadLine();
                        foreach (Player player in listOfPlayers)
                        {
                            if (player.Name == nameOfPlayer)
                            {
                                throw new SameNameException();
                            }
                        }
                        break;
                    }
                    
                    catch (SameNameException)
                    {
                        Console.WriteLine("The name of the players can't be the same");
                    }
                    
                }
                if (typeOfPlayer.ToLower() == "human")
                {
                    listOfPlayers.Add(new Player(typeOfPlayer, nameOfPlayer));
                }
                else if (typeOfPlayer.ToLower() == "ai")
                {
                    listOfPlayers.Add(new AIPlayer(typeOfPlayer, nameOfPlayer));
                }
            }
            
        }
        private void Play(string firstPlayer)
        {
            int round = 1;
            bool run = true;
            Console.Clear();
            while (run)
            {
                string parameter = "error";
                string winner = "error";
                List<Card> loot = new List<Card>();
                Console.WriteLine("The first player is: " + firstPlayer);
                foreach (Player player in listOfPlayers)
                {
                    if (player.Name == firstPlayer)
                    {
                        table.PutTable(player.Name, player.GetTopCard());
                        ShowCards(table.GetTable());
                        parameter = player.ChooseParameter();
                        if (parameter == "human")
                        {
                            parameter = ChooseParameterManual();
                        }
                    }
                }
                foreach (Player player in listOfPlayers)
                {
                    if (player.Name != firstPlayer)
                    {
                        table.PutTable(player.Name, player.GetTopCard());
                    }
                }
                Console.WriteLine("The chosen parameter is: " + parameter);
                ShowCards(table.GetTable());
                winner = table.GetWinner(parameter);
                firstPlayer = winner;
                Looting(winner);
                Console.WriteLine("The winner of the " + round.ToString() + ". round is: " + winner);
                table.ResetTable();
                round++;
                foreach (Player player in listOfPlayers)
                {
                    Console.WriteLine(player.Name + " playes has " + player.GetNumberOfCards().ToString() + " card(s) left.");
                }
                Console.WriteLine("------------------------------------------------------------");
                foreach (Player player in listOfPlayers)
                {
                    if (player.GetNumberOfCards() == 0)
                    {
                        run = false;
                    }
                }
            }
            ResetPlayersHand();
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }
        private void ResetPlayersHand()
        {
            foreach (Player player in listOfPlayers)
            {
                player.ResetDeck();
            }
        }
        private string ChooseParameterManual()
        {
            string param = "";
            while (true)
            {
                try
                {
                    Console.WriteLine("Choose a winning parameter: ");
                    param = Console.ReadLine();
                    if (!this.param.Contains(param))
                    {
                        throw new WrongInputException();
                    }
                    return param;
                }
                catch (WrongInputException)
                {
                    Console.WriteLine("Wrong input");
                } 
            }
        }
        public void showMenu(string[] menupoints)
        {
            
            foreach (string point in menupoints)
            {
                Console.WriteLine(point);
                
            }
        }
        public void start()
        {
            string[] menupoints = new string[]
            {
                "(1) New Play",
                "(2) Another game with current players",
                "(0) End Program"
            };
            while (true)
            {
                showMenu(menupoints);
                Console.Write("Type in your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    case "1":
                        {
                            myDeck.Shuffle();
                            AddPlayers();
                            param = myDeck.GetParameters();
                            Dealing();
                            Play(ChooseFirtsPlayer());
                            myDeck.ResetDeck();
                            break;

                        }
                    case "2":
                        {
                            myDeck.Shuffle();
                            Dealing();
                            Play(ChooseFirtsPlayer());
                            myDeck.ResetDeck();
                            break;
                        }
                }
            }
        }
    }
}
