using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Pages
{
    public class SeriesBlock
    {
        private IWebDriver _driver;

        private By _locator;

        private IWebElement mySelf => _driver.FindElement(_locator);

        public SeriesBlock(By locator, IWebDriver Driver)
        {
            _locator = locator;
            _driver = Driver;
            
        }

        private IWebElement Title => mySelf.FindElement(By.XPath(".//div[@class='tile__title']"));
        private IWebElement Image => mySelf.FindElement(By.XPath(".//img[not(@class='brand-logo__image')]"));

        public string GetTitle => Title.Text;
        public string GetImageAlt => Image.GetAttribute("alt");
    }
}
