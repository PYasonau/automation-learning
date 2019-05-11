using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Pages
{
    public class NBCAppPage
    {
        private IWebDriver _driver;

        private IWebElement lblAndroidAppHeader => _driver.FindElement(By.XPath("//div[text()='Android App']"));
        public NBCAppPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool IsAndroidAppBlockDisplayed()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(d => lblAndroidAppHeader.Displayed);
            return true;
        }
    }
}
