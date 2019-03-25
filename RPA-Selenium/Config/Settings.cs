using System.Data.SqlClient;
using RPAFramework.Base;

namespace RPAFramework.Config
{
    public class Settings
    {
        public static string TestType { get; set; }
        public static string Aut { get; set; }
        public static string  BuildName { get; set; }
        public BrowserType BrowserType { get; set; }
        public static string IsLog { get; set; }
        public static string LogPath { get; set; }
        public static string IsReporting { get; set; }
        public static SqlConnection ApplicationCon { get; set; }
        public static string AppConnectionString { get; set; }

    }
}
