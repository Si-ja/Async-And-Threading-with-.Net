using System;
using System.IO;

namespace AsyncAndThreads.Services
{
    public class BaseFolderFinder
    {
        public static string FindBaseFolder()
        {
            string currentWorkingDirectory = Environment.CurrentDirectory;
            string parentCurrentWorkingDirectory = Directory.GetParent(
                Directory.GetParent(
                    Directory.GetParent(currentWorkingDirectory).ToString())
                .ToString())
                .ToString();
            return parentCurrentWorkingDirectory;
        }
    }
}
