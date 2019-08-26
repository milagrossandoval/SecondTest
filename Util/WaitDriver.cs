using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Util
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
