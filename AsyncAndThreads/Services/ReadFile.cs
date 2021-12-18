using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace AsyncAndThreads.Services
{
    public class ReadFile
    {
        private static string[] ReadTxtFileSleep(string filePath)
        {
            Thread.Sleep(5000);
            string[] data = File.ReadAllLines(filePath);
            return data;
        }

        private static async Task<string[]> ReadTxtFileSleepAsync(string filePath)
        {
            await Task.Delay(5000);
            string[] data = File.ReadAllLines(filePath);
            return data;
        }

        public static string[] ReadTxtFile(string filePath)
        {
            try
            {
                return ReadTxtFileSleep(filePath);
            }
            catch (IOException ex)
            {
                throw new IOException($"Something is wrong with the file: {ex}");
            }
        }

        public static Task<string[]> ReadTxtFileAsync(string filePath)
        {
            try
            {
                return Task.Run(() => ReadTxtFileSleepAsync(filePath)); 
            }
            catch (IOException ex)
            {
                throw new IOException($"Something is wrong with the file: {ex}");
            }
        }

        public static Thread ReadTxtFileThread(string filePath)
        {
            try
            {

                return new Thread(() =>
                {
                    string[] data = ReadTxtFileSleep(filePath);
                    ReadData.ReadStringArray(data);
                });
            }
            catch (IOException ex)
            {
                throw new IOException($"Something is wrong with the file: {ex}");
            }
        }
    }
}
