using System;
using System.IO;
using System.Xml.XPath;

namespace RPAFramework.Config
{
    public class ConfigReader
    {
        public static void SetFrameWorkSettings()
        {
            XPathItem aut;
            XPathItem testType;
            XPathItem isLog;
            XPathItem isReport;
            XPathItem buildName;
            XPathItem logPath;
            XPathItem appConnection;

            string strFileName = Environment.CurrentDirectory.ToString() + "\\Config\\GlobalConfig.xml";
            FileStream stream = new FileStream(strFileName,FileMode.Open);
            XPathDocument document = new XPathDocument(stream);
            XPathNavigator navigator = document.CreateNavigator();

            aut = navigator.SelectSingleNode("RPASelenium/RunSettings/AUT");
            testType = navigator.SelectSingleNode("RPASelenium/RunSettings/TestyType");
            isLog = navigator.SelectSingleNode("RPASelenium/RunSettings/IsLog");
            isReport = navigator.SelectSingleNode("RPASelenium/RunSettings/IsReport");
            buildName = navigator.SelectSingleNode("RPASelenium/RunSettings/BuildName");
            logPath = navigator.SelectSingleNode("RPASelenium/RunSettings/LogPath");
            appConnection = navigator.SelectSingleNode("RPASelenium/RunSettings/ApplicationDb");

            Settings.Aut = aut.Value;
            Settings.BuildName = buildName.Value;
            Settings.IsLog = isLog.Value;
            Settings.LogPath = logPath.Value;
            Settings.TestType = testType.Value;
            Settings.IsReporting = isReport.Value;
            Settings.AppConnectionString = appConnection.Value;
        }
    }
}
