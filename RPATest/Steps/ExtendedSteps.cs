using System;
using System.Collections.Generic;
using System.Text;
using RPAFramework.Base;
using RPAFramework.Config;
using RPAFramework.Helpers;
using RPATest.Pages;
using TechTalk.SpecFlow;

namespace RPATest.Steps
{
    [Binding]
    internal class ExtendedSteps : BaseStep
    {
        [Given(@"I have navigated to the application")]
        public void GivenIHaveNavigatedToTheApplication()
        {
            NavigateSite();
            CurrentPage = GetInstace<LoginPage>();
        }

        [Given(@"I see application opened")]
        public void GivenISeeApplicationOpened()
        {
            CurrentPage.As<ProjectPage>().CheckIfProjectExist();
        }


        [Given(@"I Delete employee '(.*)' before I start running test")]
        public void GivenIDeleteEmployeeBeforeIStartRunningTest(string employeeName)
        {
            string query = "delete from Employees where Name= '" + employeeName + "'";
            Settings.ApplicationCon.ExecuteQuery(query);
        }

        [Then(@"I click (.*) link")]
        public void ThenIClickLoginLink(string linkName)
        {
            if (linkName == "login")
                CurrentPage = CurrentPage.As<HomePage>().ClickLogin();
            else if (linkName == "employeeList")
                CurrentPage = CurrentPage.As<HomePage>().CickEmployeeList();
        }

        [Then(@"I click (.*) button")]
        public void ThenIClickButton(string buttonName)
        {
            if (buttonName == "login")
                CurrentPage = CurrentPage.As<LoginPage>().ClickLoginButton();
            else if (buttonName == "new project")
                CurrentPage.As<ProjectPage>().ClickNewProject();
            else if (buttonName == "submitProject")
            {
                CurrentPage.As<ProjectPage>().ClickSubmitButton();
            }
            else if (buttonName == "new subproject")
            {
                CurrentPage.As<ProjectPage>().ClickNewSubProject();
            }

            else if (buttonName == "submitSubProject")
            {
                CurrentPage.As<ProjectPage>().ClickSubProjectButton();
            }

        }
    }
}
