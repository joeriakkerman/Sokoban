using System;

namespace Sokoban.Presentation
{
    class InputView
    {

        public ConsoleKey GetSingleKey(String message)
        {
            Console.WriteLine("> " + message);
            return Console.ReadKey().Key;
        }
        
        public int GetIntegerWithinRange(String message, int lowerBound, int upperBound)
        {
            int i;
            if(upperBound < 10) i = GetSmallInteger("> " + message);
            else i = GetInteger("> " + message);

            if (i >= lowerBound && i <= upperBound)
            {
                return i;
            }
            else
            {
                Console.WriteLine("> ?");
                return GetIntegerWithinRange(message, lowerBound, upperBound);
            }
        }

        public int GetSmallInteger(String message)
        {
            Console.WriteLine(message);
            char line = Console.ReadKey().KeyChar;
            int input;
            if (!Int32.TryParse("" + line, out input))
            {
                if (line == 's') Environment.Exit(0);
                Console.WriteLine("\n> ?");
                return GetSmallInteger(message);
            }
            Console.WriteLine("");
            Console.WriteLine("");
            return input;
        }

        public int GetInteger(String message)
        {
            Console.WriteLine(message);
            String line = Console.ReadLine();
            int input;
            if(!Int32.TryParse(line, out input))
            {
                if (line.Equals('s')) Environment.Exit(0);
                Console.WriteLine("> ?");
                return GetInteger(message);
            }
            Console.WriteLine("");
            return input;
        }
    }
}
