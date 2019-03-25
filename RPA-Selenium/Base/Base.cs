//using OpenQA.Selenium;

using System;
using TechTalk.SpecFlow;
//using SeleniumExtras.PageObjects;

namespace RPAFramework.Base
{
    public class Base
    {
        //private readonly ScenarioContext scenarioContext = 
       
        public BasePage CurrentPage
        {

            //get => (BasePage)scenarioContext["currentPage"];
            //set => scenarioContext["currentPage"] = value;

            get => (BasePage)ScenarioContext.Current["currentPage"];
            set => ScenarioContext.Current["currentPage"] = value;
        }

        protected TPage GetInstace<TPage>() where TPage : BasePage, new()
        {
            return (TPage)Activator.CreateInstance(typeof(TPage));
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }
    }
}
