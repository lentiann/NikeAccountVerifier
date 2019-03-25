using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using RPAFramework.Config;
using RPAFramework.Helpers;

namespace RPAFramework.Base
{
    public abstract class TestInitializeHook : Base 
    {
        public readonly BrowserType Browser;
        public TestInitializeHook(BrowserType browser)
        {
            Browser = browser;
        }
        public void InitializeSettings()
        {
            //set all settings for framework
            ConfigReader.SetFrameWorkSettings();

            //Set Log
            LogHelpers.CreateLogFile();

            //Open Browser
            OpenBrowser(Browser);

            LogHelpers.Write("Initialize framework !!!");


        }

        private void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    DriverContext.Driver = new InternetExplorerDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.FireFox:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver(@"C:\webdrivers");
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }
        }

        public virtual void NavigateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.Aut);
            LogHelpers.Write("Opened the browser !!!");
        }

    }
}
