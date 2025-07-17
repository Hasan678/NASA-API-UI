using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumAPITest.AutoData;
using SeleniumAPITest.Methods;

namespace SeleniumAPITest.Tests
{
    [TestFixture]
    public class LoginTest
    {
        private IWebDriver _driver;
        private CommonMethods commonMethods;
        private TestData testData; 

        [SetUp]
        public void setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            commonMethods = new CommonMethods(_driver);
            testData = new TestData();  
        }

        [Test]
        public void UserLogin()
        {
            _driver.Navigate().GoToUrl(TestData.url);
            commonMethods.Username(testData.Firstname);
            commonMethods.Password(testData.Password);
            commonMethods.ClickSumbit();
        }

        [TearDown]
        public void tearDown()
        {
            _driver.Close();
        }
    }
}
