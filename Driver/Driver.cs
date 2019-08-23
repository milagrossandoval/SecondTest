using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Test.driver
{
    public class Driver
    {
        public static IWebDriver InitializeDriver(string browser)
        {
            IWebDriver webDriver = null;
            switch (browser)
            {
                case "firefox":
                    webDriver = new FirefoxDriver();
                    break;
                case "chrome":
                    webDriver = new ChromeDriver();
                    break;
                default:
                    Console.WriteLine("The browser is unknown.");
                    break;
            }
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            return webDriver;
        }

        public static void ClosePage(IWebDriver webDriver)
        {
            if (webDriver != null)
            {
                webDriver.Quit();
            }
        }
    }
}
