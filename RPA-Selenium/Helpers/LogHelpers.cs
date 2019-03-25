using System;
using System.IO;
using RPAFramework.Config;

namespace RPAFramework.Helpers
{
    public class LogHelpers
    {
        //private static string logFileName = string.Format($"{DateTime.Now}:yyyymmddhhmmss");
        private static string logFileName = string.Format($"test");
        private static StreamWriter StreamWriter = null;

        public static void CreateLogFile()
        {
            string dir = Settings.LogPath;

            if (Directory.Exists(dir))
            {
                StreamWriter = File.AppendText(dir + logFileName + ".log");
            }
            else
            {
                Directory.CreateDirectory(dir);
                StreamWriter = File.AppendText(dir + logFileName + ".log");
            }
        }

        public static void Write(string logMessage)
        {
            StreamWriter.Write($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            StreamWriter.WriteLine($"   {logMessage}");
            StreamWriter.Flush();
        }

    }
}
