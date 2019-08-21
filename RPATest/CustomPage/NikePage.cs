using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using RPAFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RPATest.CustomPage
{
    public class NikePage
    {
        readonly static string Token = "5e21f3b0dccb07d65cf2fb403da1a35e";
        readonly static string Username = "lindi1995@hotmail.com";
        readonly static string PID = "628";
        readonly static string Number = "18280426117";
        readonly static string GetNumbersRegEx = "(\\d+)";

        static readonly string URL = "http://www.getsmscode.com/do.php";
        static readonly string Parameters = $"?action=getsms&username={Username}&token={Token}&pid=628&mobile=86";

        public IWebElement Email => DriverContext.Driver.FindElement(By.Name("emailAddress"));
        public IWebElement Password => DriverContext.Driver.FindElement(By.Name("password"));
        public IWebElement FirstName => DriverContext.Driver.FindElement(By.Name("firstName"));
        public IWebElement LastName => DriverContext.Driver.FindElement(By.Name("lastName"));
        public IWebElement DateOfBirth => DriverContext.Driver.FindElement(By.Name("dateOfBirth"));
        public IWebElement Country => DriverContext.Driver.FindElement(By.Name("country"));
        public IWebElement Gender => DriverContext.Driver.FindElement(By.CssSelector("ul[data-componentname='gender']"));
        public IWebElement CreateAccount => DriverContext.Driver.FindElement(By.CssSelector("input[value='CREATE ACCOUNT']"));

        public IWebElement DisaperLogin => DriverContext.Driver.FindElement(By.CssSelector("input[value*='PROCESSING']"));
        #region [VERIFICATION]
        public IWebElement PhoneNumber => DriverContext.Driver.FindElement(By.CssSelector("input[class*='phoneNumber'][type*='tel']"));
        public IWebElement SendCode => DriverContext.Driver.FindElement(By.CssSelector("input[class*='sendCodeButton'][type*='button']"));
        public IWebElement Code => DriverContext.Driver.FindElement(By.CssSelector("input[class*='code'][type*='number']")); 
        public IWebElement MobileJoinContinue => DriverContext.Driver.FindElement(By.CssSelector("div[class*='mobileJoinContinue'] > input"));
        public IWebElement Join => DriverContext.Driver.FindElement(By.CssSelector("div[class*='mobileLoginJoinLink'] > a"));
        public int MaxNumbersOfRetries = 10;
        #endregion

        public string Url = "https://www.nike.com/cn";

        public IWebElement SignUp => DriverContext.Driver.FindElement(By.CssSelector("button[data-type='click_navJoinLogin']"));
        public IWebElement CloseX => DriverContext.Driver.FindElement(By.CssSelector("nav[data-hfjs='LanguageMenu'] > button"));
        public IWebElement AcceptCookies => DriverContext.Driver.FindElement(By.XPath("//div[contains(@class, 'hf-modal-view is-active')]//button[contains(@class,'nav-btn-accent')]"));
        public IWebElement MyAccount => DriverContext.Driver.FindElement(By.Id("MyAccountLink"));

        public IWebElement LougOutAccount => DriverContext.Driver.FindElement(By.CssSelector("div[id='AccountNavigationDropdown-Menu'] > ul"))
                                                        .FindElements(By.TagName("button"))
                                                        .Where(x => x.Text.ToLower() == "log out")
                                                        .FirstOrDefault();

        public async Task<string> GetCodeFromSMS(string number)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(URL)
            };

            string _response = string.Empty;
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(Parameters+number).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            string response_text = await response.Content.ReadAsStringAsync();

            _response = response.IsSuccessStatusCode ? Regex.Match(response_text, GetNumbersRegEx).Value : response_text.Split('|').LastOrDefault();

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();

            return _response;
        }

        public NikePage clickMobileJoin()
        {
            MobileJoinContinue.Click();
            return this;
        }

        public NikePage setPhoneNumber()
        {
            PhoneNumber.SendKeys(Number);
            return this;
        }

        public NikePage setCode(string code)
        {
            Code.SendKeys(code);
            return this;
        }

        public NikePage clickSendButton()
        {
            SendCode.Click();
            return this;
        }

        public void Navigate()
        {
            //AcceptCookies.Click();
            CloseX.Click();
            SignUp.Click();
            Join.Click();
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
            Join.Click();
        }
    }
}
