using System;

namespace Sokoban.Presentation
{
    class OutputView
    {

        public void ShowWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("| Welkom bij Sokoban                                 |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("| betekenis van de symbolen   |   doel van het spel  |");
            Console.WriteLine("|                             |                      |");
            Console.WriteLine("| spatie : outerspace         |   duw met de truck   |");
            Console.WriteLine("|      █ : muur               |   de krat(ten)       |");
            Console.WriteLine("|      · : vloer              |   naar de bestemming |");
            Console.WriteLine("|      O : krat               |                      |");
            Console.WriteLine("|      0 : krat op bestemming |                      |");
            Console.WriteLine("|      x : bestemming         |                      |");
            Console.WriteLine("|      @ : truck              |                      |");
            Console.WriteLine("└────────────────────────────────────────────────────┘");
            Console.WriteLine("");
        }

        public void ShowMaze(String maze)
        {
            Console.Clear();
            Console.WriteLine("┌──────────┐");
            Console.WriteLine("| Sokoban  |");
            Console.WriteLine("└──────────┘");
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────");
            Console.WriteLine(maze);
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("");
        }

        public void ShowException(String message, String exceptionMessage)
        {
            Console.WriteLine("> " + message);
            if(!exceptionMessage.Equals("")) Console.WriteLine("\t" + exceptionMessage);
            Console.WriteLine("> press any key to continue");
            Console.ReadKey();
        }

        public void ShowFinished()
        {
            Console.WriteLine("=== HOERA OPGELOST ===");
        }
    }
}
