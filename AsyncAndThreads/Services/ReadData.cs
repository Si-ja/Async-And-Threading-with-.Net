using System;

namespace AsyncAndThreads.Services
{
    public class ReadData
    {
        public static void ReadStringArray(string[] data)
        {
            Console.ForegroundColor = ConsoleColor.White;
            foreach (string line in data)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }
    }
}
