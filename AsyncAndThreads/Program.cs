using AsyncAndThreads.Processors;
using AsyncAndThreads.Services;
using System;
using System.Threading.Tasks;

namespace AsyncAndThreads
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string parentCurrentWorkingDirectory = BaseFolderFinder.FindBaseFolder();
            string filePath = parentCurrentWorkingDirectory + "\\Files\\TextFiles\\ExampleFile.txt";
            int bulkAmount = 5;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("============Standard Files Reading===============");
            BulkReader.ReadFilesInBulk(bulkAmount, filePath);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("===========Async Files Reading=============");
            await BulkReader.ReadFilesInBulkAsync(bulkAmount, filePath);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("===========Threading Files Reading=================");
            BulkReader.ReadFilesInBulkThreading(bulkAmount, filePath);
        }
    }
}
