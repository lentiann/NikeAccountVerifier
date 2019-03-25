using OpenQA.Selenium;
using RPAFramework.Base;

namespace RPATest.Pages
{
    internal class EmployeeListPage : BasePage
    {

        //[FindsBy(How = How.Name, Using = "searchTerm")]
        IWebElement SearchInput => DriverContext.Driver.FindElement(By.Name("searchTerm"));

        //[FindsBy(How = How.LinkText, Using = "Create New")]
        IWebElement CreateNewLink => DriverContext.Driver.FindElement(By.LinkText("Create New"));

        //[FindsBy(How = How.ClassName, Using = "table")]
        IWebElement EmployeeTable => DriverContext.Driver.FindElement(By.ClassName("table"));

        public CreateEmployeePage ClickCreateNew()
        {
            CreateNewLink.Click();
            return new CreateEmployeePage();
        }

        public IWebElement GetEmployeeList()
        {
            return EmployeeTable;
        }

    }
}
