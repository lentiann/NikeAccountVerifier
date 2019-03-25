using OpenQA.Selenium;
using RPAFramework.Base;

namespace RPATest.Pages
{
    internal class CreateEmployeePage : BasePage
    {
        private IWebElement NameInput => DriverContext.Driver.FindElement(By.Id("Name"));
        private IWebElement SalaryInput => DriverContext.Driver.FindElement(By.Id("Salary"));
        private IWebElement DurationWorkedInput => DriverContext.Driver.FindElement(By.Id("DurationWorked"));
        private IWebElement GradeInput => DriverContext.Driver.FindElement(By.Id("Grade"));
        private IWebElement EmailInput => DriverContext.Driver.FindElement(By.Id("Email"));

        private IWebElement CreateEmployeeButton =>
            DriverContext.Driver.FindElement(By.XPath("//input[@value='Create']"));


        public void ClickCreateButton()
        {
            CreateEmployeeButton.Submit();
        }

        public void CreateEmployee(string name, string salary, string durationWorked, string grade, string email)
        {
            NameInput.SendKeys(name);
            SalaryInput.SendKeys(salary);
            DurationWorkedInput.SendKeys(durationWorked);
            GradeInput.SendKeys(grade);
            EmailInput.SendKeys(email);
        }
    }
}