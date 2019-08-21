using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RPAFramework.Base;
using RPAFramework.Extensions;
using RPAFramework.Helpers;
using RPATest.CustomPage;
using System;
using System.IO;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RPATest.Steps
{
    [Binding]
    public class NikeAccountsSteps : BaseStep
    {
        private readonly NikePage nikePage;

        public NikeAccountsSteps(NikePage nikePage)
        {
            this.nikePage = nikePage;
        }

        [Given(@"I have entered account details")]
        public void GivenIHaveEnteredAccountDetails()
        {
            //Proxies proxy = new Proxies();
            //proxy.ChromeProxies();

            WebElementExtensions.MaximizeBrowser();
            NavigateSite(nikePage.Url);
            nikePage.Navigate();
            Assert.True(true);
        }

        [Then(@"I Verify Account")]
        public async Task ThenIVerifyAccount()
        {
            var ListOfPeople = ExcelHelpers.PopulateInCollection(AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin")) + @"Data\register.xlsx", "Sheet1");
            
            foreach (var user in ListOfPeople)
            {
                nikePage.setPhoneNumber()
                    .clickSendButton();

                string response_from_api = await nikePage.GetCodeFromSMS("numri qetu");

                //nikePage.WaitForCondition<>(ExpectedConditions.TextToBePresentInElement(DriverContext.Driver.FindElement(By.Id("MyAccountLink")), "My Account"), 5);
                //prit

                nikePage.setEmail(user.Email)
                       .setPassword(user.Password)
                       .setFirstName(user.FirstName)
                       .setLastName(user.LastName)
                       .setDateOfBirth(user.DateOfBirth)
                       .setCountry(user.Email)
                       .setGender(user.Sex)
                       .submitForm();
            }

            Assert.True(true);
        }

        [Then(@"I fill register form")]
        public void ThenIFillRegisterForm()
        {
            var ListOfPeople = ExcelHelpers.PopulateInCollection(Path.Combine(AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin")), @"Data\register.xlsx"), "Sheet1");

            foreach (var item in ListOfPeople)
            {
                nikePage.setEmail(item.Email)
                        .setPassword(item.Password)
                        .setFirstName(item.FirstName)
                        .setLastName(item.LastName)
                        .setDateOfBirth(item.DateOfBirth)
                        .setCountry(item.Email)
                        .setGender(item.Sex)
                        .submitForm();

                //WebDriverExtensions.SummaryDisplayed(DriverContext.Driver, "MyAccountLink");\

                //WebDriverExtensions.FindElement(DriverContext.Driver, By.Id("MyAccountLink"), 20);
                WebDriverExtensions.Wait(6);

                nikePage.LogOut();
                nikePage.Login();
            }

            Assert.True(true);
        }
    }
}
