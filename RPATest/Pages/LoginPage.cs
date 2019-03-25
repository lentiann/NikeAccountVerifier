using OpenQA.Selenium;
using RPAFramework.Base;
using RPAFramework.Extensions;

namespace RPATest.Pages
{
    internal class LoginPage : BasePage
    {
        private IWebElement UserNameInput => DriverContext.Driver.FindElement(By.CssSelector("input[class*='user-email']"));

        private IWebElement PasswordInput => DriverContext.Driver.FindElement(By.CssSelector("input[class*='password']"));

        private IWebElement LoginButton =>
            DriverContext.Driver.FindElement(By.CssSelector("button[class*='btn  custom-btn']"));

        public void Login(string userName, string password)
        {
            UserNameInput.SendKeys(userName);
            PasswordInput.SendKeys(password);
        }

        //internal void CheckIfLoginExist()
        //{
        //    UserNameInput.AssertElementPresent();
        //}

        public ProjectPage ClickLoginButton()
        {
            LoginButton.Submit();
            return GetInstace<ProjectPage>();
        }

        //public HomePage ClickLoginButton()
        //{
        //    LoginButton.Submit();
        //    return GetInstace<HomePage>();
        //}
    }
}