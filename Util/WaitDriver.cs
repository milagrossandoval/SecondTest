using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Test.driver;

namespace Test.Util
{
    public class WaitDriver
    {
        public static void WaitForElement(IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(x => x.FindElement(by));
        }
                
    }
}
