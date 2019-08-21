using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPATest.CustomBasePage
{
    public abstract class BasePageCustom
    {
        public abstract string Url { get; }
        public abstract IWebElement firstName { get; }
        public abstract IWebElement lastName { get; }
        public abstract IWebElement Email { get; }
        public abstract IWebElement Password { get; }
        public abstract IWebElement btnSubmit { get; }
    }
}
