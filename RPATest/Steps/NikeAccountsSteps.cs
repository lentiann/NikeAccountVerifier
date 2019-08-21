using NUnit.Framework;
using OpenQA.Selenium;
using RPAFramework.Base;
using RPAFramework.Extensions;
using RPAFramework.Helpers;
using RPATest.CustomPage;
using System;
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
            Proxies proxy = new Proxies();
            proxy.ChromeProxies();

            WebElementExtensions.MaximizeBrowser();
            NavigateSite(nikePage.Url);
            nikePage.Navigate();
            Assert.True(true);
        }

        [Then(@"I fill register form")]
        public void ThenIFillRegisterForm()
        {
            var ListOfPeople = ExcelHelpers.PopulateInCollection(@"C:\Users\arlind.hajdari\Desktop\register.xlsx", "Sheet1");

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
