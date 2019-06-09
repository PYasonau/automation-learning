using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Pages
{
    public class ShowsPage
    {
        private IWebDriver driver;

        public ShowsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private string lnkAll = "a[href='/shows/all']";
        private string lnkCurrent = "a[href='/shows/current']";
        private string lnkUpcoming = "a[href='/shows/upcoming']";
        private string lnkThrowBack = "a[href='/shows/classic-throwback']";

        private string lnkShowBlockByText(string text) => $"//div[text()='{text}']/../../..";

        public ShowsPage ClickAll()
        {
            driver.FindElement(By.CssSelector(lnkAll)).Click();
            return WaitForPageLoaded();
        }
        public ShowsPage ClickCurrent()
        {
            driver.FindElement(By.CssSelector(lnkCurrent)).Click();
            return WaitForPageLoaded();
        }
        public ShowsPage ClickUpcoming()
        {
            driver.FindElement(By.CssSelector(lnkUpcoming)).Click();
            return WaitForPageLoaded();
        }
        public ShowsPage ClickThrowback()
        {
            driver.FindElement(By.CssSelector(lnkThrowBack)).Click();
            return WaitForPageLoaded();
        }

        public SerialPage ClickOnShowBlockByName(string name)
        {
            driver.FindElement(By.XPath(lnkShowBlockByText(name))).Click();
            return new SerialPage(driver).WaitForPageLoaded();
        }

        public bool IsShowBlockByNameExist(string name) => driver.FindElements(By.XPath(lnkShowBlockByText(name))).Count > 0;

        public ShowsPage WaitForPageLoaded()
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
            return this;
        }
    }
}
