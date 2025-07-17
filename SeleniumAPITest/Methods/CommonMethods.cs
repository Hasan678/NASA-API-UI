using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using OpenQA.Selenium;
using SeleniumAPITest.Locators;

namespace SeleniumAPITest.Methods
{
    public class CommonMethods
    {
        private readonly IWebDriver _driver;

        public CommonMethods(IWebDriver driver)
        {
            this._driver = driver;
        }
        public void Username(string text)
        {
            var element = _driver.FindElement(By.XPath(ElementData.userName));
            element.Click();
            element.Clear();
            element.SendKeys(text);
        }

        public void Password(string text)
        {
            var element = _driver.FindElement(By.XPath(ElementData.password));
            element.Click();
            element.Clear();
            element.SendKeys(text);
        }

        public void ClickSumbit()
        {
            var element = _driver.FindElement(By.XPath(ElementData.submitButton));
            element.Click();
        }
    }
}
