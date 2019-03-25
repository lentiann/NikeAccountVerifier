using RPAFramework.Base;
using RPATest.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RPATest.Steps
{
    [Binding]
    public class LoginSteps : BaseStep
    {
        [When(@"I enter Username and Password")]
        public void WhenIEnterUsernameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            CurrentPage.As<LoginPage>().Login(data.UserName, data.Password);
        }

        [Then(@"I should see the username with hello")]
        public bool ThenIShouldSeeTheUsernameWithHello()
        {
            if (CurrentPage.As<ProjectPage>().CheckIfProjectExist())
                return true;
            else
                return false;
        }
    }
}
