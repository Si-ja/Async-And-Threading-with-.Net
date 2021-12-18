using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
