using OpenQA.Selenium.DevTools.V136.FedCm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAPITest.Locators
{
    public class ElementData
    {
        public static string userName = "//*[@id = 'username']";
        public static string password = "//*[@id = 'password']";
        public static string submitButton = "//*[@class = 'eui-btn--round eui-btn--green']";
    }
}
