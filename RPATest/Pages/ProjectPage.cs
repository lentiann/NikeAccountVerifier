using System.Linq;
using OpenQA.Selenium;
using RPAFramework.Base;
using RPAFramework.Extensions;

namespace RPATest.Pages
{
    internal class ProjectPage : BasePage
    {
        private IWebElement ProjectList => DriverContext.Driver.FindElements(By.Id("projectsList"))[1];

        private IWebElement ProjectItem => ProjectList.FindElement(By.CssSelector("li[class*='list']"));

        private IWebElement SubProjectList => DriverContext.Driver.FindElements(By.Id("subProjectsList"))[1];

        private IWebElement SubProjectItem => ProjectList.FindElements(By.CssSelector("li[class*='list']"))[1];

        private IWebElement OkButton => DriverContext.Driver.FindElements(By.CssSelector("button[class*='btn btn-info ok']"))[1];

        private  IWebElement NewProject => DriverContext.Driver.FindElements(By.Id("newProject")).Last();
        private IWebElement NewTitleInput => DriverContext.Driver.FindElements(By.Id("projectName")).Last();

        private IWebElement NewSubProject => DriverContext.Driver.FindElements(By.Id("newSubProject")).Last();
        private IWebElement NewSubprojectTitle => DriverContext.Driver.FindElement(By.Id("subProjectName"));

        private IWebElement NewSubprojectSubmit => DriverContext.Driver.FindElement(By.Id("createsubProjectSubmit"));

        private IWebElement SubmitButton => DriverContext.Driver.FindElement(By.Id("projectSelectionSubmit"));

        //internal HomePage ClickOKButton()
        //{
        //    OkButton.Click();
        //    return GetInstace<HomePage>();
        //}

        public void ClickOkButton()
        {
            OkButton.Click();
        }
        
        public void ClickSubmitButton()
        {
            SubmitButton.Click();
        }

        public void ClickSubProjectButton()
        {
            NewSubprojectSubmit.Click();
        }

        public void ClickNewProject()
        {
            NewProject.Click();
        }

        public void selectLastElementProject()
        {
            ProjectList.FindElements(By.TagName("li")).Last().Click();
        }

        public void selectElementSubProject()
        {
            SubProjectList.FindElements(By.TagName("li")).First().Click();
        }
        public void ClickNewSubProject()
        {
            NewSubProject.Click();
        }



        public void CreateProject(string projectName)
        {
            NewTitleInput.SendKeys(projectName);
        }

        public void CreateSubProject(string projectName)
        {
            NewSubprojectTitle.SendKeys(projectName);
        }

        internal bool CheckIfProjectExist() => ProjectList.IsProjectPresent();
        


    }
}
