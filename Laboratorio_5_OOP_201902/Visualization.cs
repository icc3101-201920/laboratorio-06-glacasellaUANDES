using Laboratorio_5_OOP_201902.Cards;
using Laboratorio_5_OOP_201902.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_5_OOP_201902
{
    public static class Visualization
    {
        // Metodos
        public static void ShowHand(Hand hand)
        {
            Console.WriteLine("Hand:");
            int count = 0;
            foreach (Card card in hand.Cards)
            {
                string aux = "| ";
                aux += "(" + Convert.ToString(count) + ")";
                string name = card.Name;
                EnumType type = card.Type;
                // Si es combatcard
                if (type == (EnumType)Enum.Parse(typeof(EnumType), "melee") || type == (EnumType)Enum.Parse(typeof(EnumType), "range") || type == (EnumType)Enum.Parse(typeof(EnumType), "longRange"))
                {
                    CombatCard aux2 = (CombatCard)card;
                    aux += " " + name + "(" + type + "): " + Convert.ToString(aux2.AttackPoints) + " |";
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(aux);
                    Console.ForegroundColor = ConsoleColor.White;
                    count++;
                }
                // Si es specialCard
                else
                {
                    aux += " " + name + "(" + type + ") |";
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(aux);
                    Console.ForegroundColor = ConsoleColor.White;
                    count++;
                }
            }
        }

        public static void ShowDecks(List<Deck> Decks)
        {
            Console.WriteLine("Select one Deck: ");
            int count = 0;
            foreach (Deck deck in Decks)
            {
                Console.WriteLine($"({count}) Deck {count + 1}");
                count++;
            }
        }

        public static void ShowCaptains(List<SpecialCard> specialcards)
        {
            Console.WriteLine("Select one Captain: ");
            int count = 0;
            foreach (SpecialCard card in specialcards)
            {
                if (card.Type == EnumType.captain)
                {
                    Console.WriteLine($"({count}) {card.Name}: {card.Effect}");
                    count++;
                }
            }
        }

        public static int GetUserInput(int maxInput, bool stopper = false)
        {
            int convertido;
            while (true)
            {
                string userinput = Console.ReadLine();
                // Primero verificamos que se pudeda convertir a int
                try
                {
                    convertido = Convert.ToInt32(userinput);
                }
                catch
                {
                    ConsoleError("Input must be a number. Try again");
                    continue;
                }
                bool tryagain = false;
                switch (stopper)
                {
                    case false:
                        if (convertido < 0 || convertido > maxInput)
                        {
                            ConsoleError($"The option {convertido} is not valid. Try again");
                            tryagain = true;
                        }
                        break;
                    case true:
                        if (convertido < -1 || convertido > maxInput)
                        {
                            ConsoleError($"The option {convertido} is not valid. Try again");
                            tryagain = true;
                        }
                        break;
                }
                if (tryagain == false) break;
            }
            return convertido;
        }

        public static void ConsoleError(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void ShowProgramMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;   
        }

        public static void ShowListOptions(List<string> options, string message = null)
        {
            if (message != null) Console.WriteLine(message);
            int count = 0;
            foreach (string option in options)
            {
                Console.WriteLine($"({count}) " + option);
                count++;
            }
        }

        public static void ClearConsole()
        {
            Console.Clear();
        }

    }
}
