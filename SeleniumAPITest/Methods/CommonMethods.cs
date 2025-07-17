using OpenQA.Selenium;
using SeleniumAPITest.Locators;

namespace SeleniumAPITest.Methods
{
    public class CommonMethods
    {
        private IWebDriver _driver;

        public CommonMethods(IWebDriver driver)
        {
            this._driver = driver;
        }
        public void Username(string text)
        {
            var usernameElement = _driver.FindElement(By.XPath(ElementData.userName));
            usernameElement.Click();
            usernameElement.Clear();
            usernameElement.SendKeys(text);
        }

        public void Password(string text)
        {
            var passwordElement = _driver.FindElement(By.XPath(ElementData.password));
            passwordElement.Click();
            passwordElement.Clear();
            passwordElement.SendKeys(text);
        }

        public void ClickSumbit()
        {
            var sumbitForum = _driver.FindElement(By.XPath(ElementData.submitButton));
            sumbitForum.Click();
        }
    }
}
