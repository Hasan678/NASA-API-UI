using Docker.DotNet.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumAPITest.AutoData;
using SeleniumAPITest.Locators;
using SeleniumAPITest.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAPITest.Tests
{
    [TestFixture]
    public class LoginTest
    {
        private IWebDriver driver;
        private CommonMethods commonMethods;
        private TestData testData; 

        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            commonMethods = new CommonMethods(driver);
            testData = new TestData();  
        }

        [Test]
        public void UserLogin()
        {
            driver.Navigate().GoToUrl(TestData.url);
            commonMethods.Username(testData.Firstname);
            commonMethods.Password(testData.Password);
            commonMethods.ClickSumbit();
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}
