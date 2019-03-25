using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RPAFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RPAFramework.Extensions
{
    public static class WebElementExtensions
    {

        public static string GetSelectedDropDown(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions.First().ToString();
        }

        public static IList<IWebElement> GetSelectedListOptions(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions;
        }

        public static string GetLinkText(this IWebElement element)
        {
            return element.Text;
        }

        public static void Hover(this IWebElement element)
        {
            Actions actions = new Actions(DriverContext.Driver);
            actions.MoveToElement(element).Perform();
        }


        public static void SelectDropDownList(this IWebElement element, string value)
        {
            SelectElement ddl = new SelectElement(element);
            ddl.SelectByText(value);
        }

        public static void AssertElementPresent(this IWebElement element)
        {
            if(!IsElementPresent(element))
                throw new Exception(string.Format("Element not present exception"));
        }

        public static bool IsProjectPresent(this IWebElement element)
        {
            if (element.Displayed)
                return true;
            return false;
        }
        
        private static bool IsElementPresent(IWebElement element)
        {
            try
            {
                bool ele = element.Displayed;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static void MaximizeBrowser(this IWebElement element)
        {
            element.MaximizeBrowser();
        }
    }
}
