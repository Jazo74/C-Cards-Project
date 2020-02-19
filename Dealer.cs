using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Cardgame
{
    class Menu


    {
        public void showMenu(string[] menupoints)
        {
            int index = 1;
            foreach (string point in menupoints)
            {
                Console.WriteLine("(" + index + ") " + point);
                index++;
            }
            Console.WriteLine("(0) Exit Program");
        }
        public void start()
        {
            string[] menupoints = new string[]
            {
                "Egy",
                "Kettő"

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


                }
            }
        }
    }
}