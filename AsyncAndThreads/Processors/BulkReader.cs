using AsyncAndThreads.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndThreads.Processors
{
    public class BulkReader
    {
        private static readonly Stopwatch _stopWatch = new();
        public static void ReadFilesInBulk(int amountInBulk, string filePath)
        {
            _stopWatch.Reset();
            _stopWatch.Start();
            for (int i = 0; i < amountInBulk; i++)
            {
                string[] data = ReadFile.ReadTxtFile(filePath);
                ReadData.ReadStringArray(data);
            }

            _stopWatch.Stop();
            TimeSpan ts = _stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Finished reading {amountInBulk} files in {elapsedTime}");
        }

        public static async Task ReadFilesInBulkAsync(int amountInBulk, string filePath)
        {
            _stopWatch.Reset();
            _stopWatch.Start();
            Task<string[]>[] filesToRead = new Task<string[]>[amountInBulk];
            for (int i = 0; i < amountInBulk; i++)
            {
                Task<string[]> dataAsync = ReadFile.ReadTxtFileAsync(filePath);
                filesToRead[i] = dataAsync;
            }

            await Task.WhenAll(filesToRead);

            foreach (var file in filesToRead)
            {
                ReadData.ReadStringArray(file.Result);
            }

            _stopWatch.Stop();
            TimeSpan ts = _stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Finished reading {amountInBulk} files in {elapsedTime}");
        }

        public static void ReadFilesInBulkThreading(int amountInBulk, string filePath)
        {
            _stopWatch.Reset();
            _stopWatch.Start();
            for (int i = 0; i < amountInBulk; i++)
            {
                Thread thread = ReadFile.ReadTxtFileThread(filePath);
                thread.Start();
            }

            _stopWatch.Stop();
            TimeSpan ts = _stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Finished reading {amountInBulk} files in {elapsedTime}");
        }
    }
}
