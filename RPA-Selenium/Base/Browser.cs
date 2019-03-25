using OpenQA.Selenium;

namespace RPAFramework.Base
{
    public class Browser
    {
        private readonly IWebDriver driver;

        public Browser(IWebDriver driver)
        {
            this.driver = driver;
        }

        public BrowserType Type { get; set; }

        public void GoToUrl(string url)
        {
            DriverContext.Driver.Url = url;
        }
    }

    public enum BrowserType
    {
        InternetExplorer,
        Chrome,
        FireFox
    }

}
