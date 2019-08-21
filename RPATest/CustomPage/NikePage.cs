using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using RPAFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPATest.CustomPage
{
    public class NikePage
    {
        readonly static string sApiKey = "6540b11f-a195-414b-b498-b4d70f126598";
        readonly static string sClientId = "053d4422-361b-4535-b486-7242966bb091";
        readonly static string sNumber = "003";
        readonly static string sSID = "WEBSMS";
        readonly static string sMessage = "Test Message";

        static string parameters = $"?&apikey={sApiKey}&clientid={sClientId}&msisdn={sNumber}&sid={sSID}&msg={sMessage}&fl=0";
        static string sURL = "https://my.forwardvaluesms.com/vendorsms/pushsms.aspx" + parameters;


        public IWebElement Email => DriverContext.Driver.FindElement(By.Name("emailAddress"));
        public IWebElement Password => DriverContext.Driver.FindElement(By.Name("password"));
        public IWebElement FirstName => DriverContext.Driver.FindElement(By.Name("firstName"));
        public IWebElement LastName => DriverContext.Driver.FindElement(By.Name("lastName"));
        public IWebElement DateOfBirth => DriverContext.Driver.FindElement(By.Name("dateOfBirth"));
        public IWebElement Country => DriverContext.Driver.FindElement(By.Name("country"));
        public IWebElement Gender => DriverContext.Driver.FindElement(By.CssSelector("ul[data-componentname='gender']"));
        public IWebElement CreateAccount => DriverContext.Driver.FindElement(By.CssSelector("input[value='CREATE ACCOUNT']"));

        public IWebElement DisaperLogin => DriverContext.Driver.FindElement(By.CssSelector("input[value*='PROCESSING']"));

        public string Url = "https://www.nike.com/nl/en/";

        public IWebElement SignUp => DriverContext.Driver.FindElement(By.CssSelector("button[data-type='click_navJoinLogin']"));

        public IWebElement JoinNow => DriverContext.Driver.FindElement(By.XPath("//a[contains(text(),'Join now.')]"));
        public IWebElement CloseX => DriverContext.Driver.FindElement(By.CssSelector("nav[data-hfjs='LanguageMenu'] > button"));
        public IWebElement AcceptCookies => DriverContext.Driver.FindElement(By.XPath("//div[contains(@class, 'hf-modal-view is-active')]//button[contains(@class,'nav-btn-accent')]"));
        public IWebElement MyAccount => DriverContext.Driver.FindElement(By.Id("MyAccountLink"));

        public IWebElement LougOutAccount => DriverContext.Driver.FindElement(By.CssSelector("div[id='AccountNavigationDropdown-Menu'] > ul"))
                                                        .FindElements(By.TagName("button"))
                                                        .Where(x => x.Text.ToLower() == "log out")
                                                        .FirstOrDefault();

        public void Navigate()
        {
            AcceptCookies.Click();
            CloseX.Click();
            SignUp.Click();
            JoinNow.Click();
        }

        public NikePage setEmail(string email)
        {
            Email.SendKeys(email);
            return this;
        }
        public NikePage setPassword(string password)
        {
            Password.SendKeys(password);
            return this;
        }
        public NikePage setFirstName(string firstname)
        {
            FirstName.SendKeys(firstname);
            return this;
        }
        public NikePage setLastName(string lastname)
        {
            LastName.SendKeys(lastname);
            return this;
        }
        public NikePage setDateOfBirth(string date)
        {
            DateOfBirth.SendKeys(date);
            return this;
        }
        public NikePage setCountry(string country)
        {
            Country.SendKeys(country);
            return this;
        }
        public NikePage setGender(string gender)
        {
            IWebElement li;

            if (gender.ToLower() == "male")
                li = Gender.FindElements(By.TagName("li")).FirstOrDefault();
            else
                li = Gender.FindElements(By.TagName("li")).LastOrDefault();

            li.Click();
            return this;
        }

        public NikePage submitForm()
        {
            CreateAccount.Submit();
            return this;
        }

        public void LogOut()
        {
            Actions act = new Actions(DriverContext.Driver);
            act.MoveToElement(MyAccount).Perform();

            act.MoveToElement(LougOutAccount).Perform();
            LougOutAccount.Click();
        }

        public void Login()
        {
            SignUp.Click();
            JoinNow.Click();
        }
    }
}
