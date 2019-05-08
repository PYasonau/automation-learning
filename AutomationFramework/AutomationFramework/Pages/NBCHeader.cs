using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Pages
{
    public class NBCHeader
    {
        private IWebDriver _driver;

        private static string lnkShowsLocator = "a[href='/shows']";
        private static string lnkEpisodesLocator = "a[href='/video']";
        private static string lnkScheduleLocator = "a[href='/schedule']";
        private static string lnkNewsSportsLocator = "//*[contains(text(), 'Sports')]/.."; //XPath locator
        private static string lnkShopLocator = "a[href$='shop']"; //ends with shop
        private static string lnkAppLocator = "a[href='/apps']";
        private static string btnSearchLocator = "[class$='search'] button";

        private IWebElement lnkShows => _driver.FindElement(By.CssSelector(lnkShowsLocator));
        private IWebElement lnkEpisodes => _driver.FindElement(By.CssSelector(lnkEpisodesLocator));
        private IWebElement lnkSchedule => _driver.FindElement(By.CssSelector(lnkScheduleLocator));
        private IWebElement lnkNewsSports => _driver.FindElement(By.CssSelector(lnkNewsSportsLocator));
        private IWebElement lnkShop => _driver.FindElement(By.CssSelector(lnkShopLocator));
        private IWebElement lnkApp => _driver.FindElement(By.CssSelector(lnkAppLocator));
        private IWebElement btnSearch => _driver.FindElement(By.CssSelector(btnSearchLocator));

        public NBCHeader(IWebDriver Driver)
        {
            _driver = Driver;
        }

        public NBCPage ClickSHows()
        {
            lnkShows.Click();
            return new NBCPage(_driver);
        }

        public NBCPage ClickEpisodes()
        {
            lnkShows.Click();
            return new NBCPage(_driver);
        }

        public NBCPage ClickSchedule()
        {
            lnkShows.Click();
            return new NBCPage(_driver);
        }

        public NBCPage ClickNewsSports()
        {
            lnkShows.Click();
            return new NBCPage(_driver);
        }

        public NBCPage ClickShop()
        {
            lnkShows.Click();
            return new NBCPage(_driver);
        }

        public NBCPage ClickApp()
        {
            lnkShows.Click();
            return new NBCPage(_driver);
        }

        public NBCPage ClickSearch()
        {
            lnkShows.Click();
            return new NBCPage(_driver);
        }
        
    }
}
