using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPATest.Hooks;

namespace RPATest.TraditionalTests
{
    [TestClass]
    public class UnitTest1 : HookInitialize
    {
        //[TestMethod]
        //public void TestMethod1()
        //{

        //    string fileName = Environment.CurrentDirectory.ToString() + "\\Data\\Login.xlsl";

        //    ExcelHelpers.PopulateInCollection(fileName);

        //    CurrentPage = GetInstace<LoginPage>();
        //    CurrentPage.As<LoginPage>().CickLoginLink();
        //    CurrentPage.As<LoginPage>().Login(ExcelHelpers.ReadData(1,"username"),ExcelHelpers.ReadData(1,"password"));
        //    CurrentPage = CurrentPage.As<LoginPage>().CickEmployeeList();

        //    CurrentPage.As<EmployeePage>().ClickCreateNew();
        //}

        //[TestMethod]
        //public void TableOperation()
        //{
        //    string fileName = Environment.CurrentDirectory.ToString() + "\\Data\\Login.xlsl";
        //    ExcelHelpers.PopulateInCollection(fileName);

        //    CurrentPage = GetInstace<LoginPage>();
        //    CurrentPage.As<LoginPage>().CickLoginLink();
        //    CurrentPage.As<LoginPage>().CheckIfLoginExist();
        //    CurrentPage.As<LoginPage>().Login(ExcelHelpers.ReadData(1, "username"), ExcelHelpers.ReadData(1, "password"));
        //    CurrentPage = CurrentPage.As<LoginPage>().CickEmployeeList();

        //    var table = CurrentPage.As<EmployeePage>().GetEmployeeList();

        //    HtmlTableHelpers.ReadTable(table);
        //    HtmlTableHelpers.PerformActionOnCell("5","Name","Ramesh","Edit");
        //}
    }
}
