using System;
using RPAFramework.Base;
using RPATest.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RPATest.Steps
{
    [Binding]
    public class CreateProjectSteps : BaseStep
    {
        [Then(@"I enter ProjectName and test")]
        public void ThenIEnterProjectNameAndTest(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            CurrentPage.As<ProjectPage>().CreateProject(data.ProjectName);
        }
        
        [Then(@"click submitProject button")]
        public void ThenClickSubmitProjectButton()
        {
            CurrentPage.As<ProjectPage>().ClickSubmitButton();
        }
        
        [Then(@"I enter SubProjectName and test")]
        public void ThenIEnterSubProjectNameAndTest(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            CurrentPage.As<ProjectPage>().CreateProject(data.ProjectName);
        }
        
        [Then(@"click OkButton button")]
        public void ThenClickOkButtonButton()
        {
            CurrentPage.As<ProjectPage>().ClickOkButton();
        }

        [Then(@"I select last element in ProjectList")]
        public void ThenISelectLastElementInProjectList()
        {
           CurrentPage.As<ProjectPage>().selectLastElement();
        }

        [Then(@"I select last element in SubProjectList")]
        public void ThenISelectLastElementInSubProjectList()
        {
            ScenarioContext.Current.Pending();
        }


    }
}
