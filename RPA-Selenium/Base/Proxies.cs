using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPAFramework.Base
{
    public class Proxies
    {
        public void ChromeProxies()
        {

            //var cService = ChromeDriverService.CreateDefaultService(@"C:\WebdriverJava");
            //cService.HideCommandPromptWindow = true;

            //var options = new ChromeOptions();

            //options.AddArguments("--proxy-server=" + "117.191.11.104" + ":" + "8080");
            //options.AddExtension(@"C:\Users\arlind.hajdari\Desktop\ProxyChanger.crx");

            //options.Proxy = null;

            ////string userAgent = "<< User Agent Text >>";

            ////options.AddArgument($"--user-agent={userAgent}$PC${"<< User Name >>" + ":" + "<< Password >>"}");

            //IWebDriver _webDriver = new ChromeDriver(cService, options);


            //Create a chrome options object
            var chromeOptions = new ChromeOptions();
            //Create a new proxy object
            var proxy = new Proxy();
            //Set the http proxy value, host and port.
            proxy.HttpProxy = "117.191.11.104:8080";
            //Set the proxy to the Chrome options
            chromeOptions.Proxy = proxy;
            //Then create a new ChromeDriver passing in the options
            //ChromeDriver path isn't required if its on your path
            //If it now downloaded it and put the path here
            var Driver = new ChromeDriver(@"C:\WebdriverJava", chromeOptions);



            Driver.Navigate().GoToUrl("https://whatismyipaddress.com/");
        }
    }
}
