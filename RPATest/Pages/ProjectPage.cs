using System.Linq;
using OpenQA.Selenium;
using RPAFramework.Base;
using RPAFramework.Extensions;

namespace RPATest.Pages
{
    internal class ProjectPage : BasePage
    {
        private IWebElement ProjectList => DriverContext.Driver.FindElements(By.Id("projectsList"))[2];

        private IWebElement ProjectItem => ProjectList.FindElement(By.CssSelector("li[class*='list']"));

        private IWebElement SubProjectList => DriverContext.Driver.FindElements(By.CssSelector("ul[class*='list-group ml-3 mt-2']"))[3];

        private IWebElement SubProjectItem => ProjectList.FindElements(By.CssSelector("li[class*='list']"))[1];

        private IWebElement OkButton => DriverContext.Driver.FindElements(By.CssSelector("button[class*='btn btn-info ok']"))[1];

        private  IWebElement NewProject => DriverContext.Driver.FindElements(By.Id("newProject")).Last();
        private IWebElement NewTitleInput => DriverContext.Driver.FindElements(By.Id("projectName")).Last();

        private IWebElement SubmitButton => DriverContext.Driver.FindElement(By.CssSelector("button[class*='k-button k-primary submit-button']"));

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

        public void ClickNewProject()
        {
            NewProject.Click();
        }

        public void selectLastElement()
        {
            ProjectList.FindElements(By.CssSelector("li[class*='list']")).First().Click();
        }


        public void CreateProject(string projectName)
        {
            NewTitleInput.SendKeys(projectName);
        }
        
        internal bool CheckIfProjectExist() => ProjectList.IsProjectPresent();
        


    }
}
