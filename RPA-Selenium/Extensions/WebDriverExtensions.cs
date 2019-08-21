using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RPAFramework.Base;
using System;
using System.Diagnostics;

namespace RPAFramework.Extensions
{
    public static class WebDriverExtensions
    {
        public static void WaitForPageLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(dri =>
            {
                string state = dri.ExecuteJs("return document.readyState").ToString();
                return state == "complete";
            }, 10);
        }

        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                };
            var stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < timeOut)
            {
                if (execute(obj))
                {
                    break;
                }
            }
        }

        internal static object ExecuteJs(this IWebDriver driver, string script)
        {
            return ((IJavaScriptExecutor)DriverContext.Driver).ExecuteScript(script);
        }

        public static bool SummaryDisplayed(this IWebDriver driver, string id)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                var myElement = wait.Until(x => x.FindElement(By.Id(id)));
                return myElement.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {            
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static void Wait(int seconds)
        {
            //WebDriverWait driver;
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
            new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.TextToBePresentInElement(DriverContext.Driver.FindElement(By.Id("MyAccountLink")), "My Account"));
        }
    }
}
   