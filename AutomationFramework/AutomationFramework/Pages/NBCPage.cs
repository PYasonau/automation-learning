using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Pages
{
    public class NBCPage
    {
        private IWebDriver _driver;

        private IWebElement loadingSpinner => _driver.FindElement(By.CssSelector(".spinner"));
        private IWebElement slidshowContainer => _driver.FindElement(By.CssSelector(".slideshow__container"));

        public NBCHeader NBCHeader => new NBCHeader(_driver);

        public PopularShowsBlock PopularShowsBlock => new PopularShowsBlock(_driver);

        public NBCPage(IWebDriver Driver)
        {
            _driver = Driver;
        }


        public bool IsNBCPageLoaded()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(d => slidshowContainer.Displayed);
            return true;
        }
    }
}
