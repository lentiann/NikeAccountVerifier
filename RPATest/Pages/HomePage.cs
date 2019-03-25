using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RPAFramework.Base;
using RPAFramework.Extensions;

namespace RPATest.Pages
{
    internal class HomePage : BasePage
    {
        private IWebElement LoginLink => DriverContext.Driver.FindElement(By.Id("loginLink"));
        private IWebElement EmployeeListLink => DriverContext.Driver.FindElement(By.LinkText("Employee List"));

        private IWebElement LoggedInUserLink => DriverContext.Driver.FindElement(By.XPath("//a[@title='Manage']"));

        private IWebElement LogOffLink => DriverContext.Driver.FindElement(By.LinkText("Log off"));


        internal LoginPage ClickLogin()
        {
            LoginLink.Click();
            return GetInstace<LoginPage>();
        }

        internal void CheckIfLoginExists() => LoginLink.AssertElementPresent();

        public EmployeeListPage CickEmployeeList()
        {
            EmployeeListLink.Click();
            return GetInstace<EmployeeListPage>();
        }

        internal string GetLoggedInUser() => LoggedInUserLink.GetLinkText();
    }
}
