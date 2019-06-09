using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Pages
{
    public class SerialPage
    {
        private IWebDriver driver;

        private const string btnAddToFavorite = "div.show-header__menu a.navigation__item__link--favorite-add";
        private const string btnCast = "a[href$='/cast']";
        private const string lstActors = ".shelf__tiles a";
        private string lnkActor(string name) => $"//*[@class='tile__description__part-bold' and text()='{name}']";

        private const string btnMore = ".bio__long-desc__more";
        private const string btnLess = ".bio__long-desc__more--active";

        private const string btnClosePopUp = ".modal__icon__exit";


        public SerialPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public SerialPage ClosePopUpIfPresent()
        {
            if (driver.FindElements(By.CssSelector(btnClosePopUp)).Count > 0)
                driver.FindElement(By.CssSelector(btnClosePopUp)).Click();
            return WaitForPageLoaded();
        }

        public SerialPage WaitForPageLoaded()
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
            return this;
        }

        public SerialPage ClickAddToFavorite()
        {
            driver.FindElement(By.CssSelector(btnAddToFavorite)).Click();
            return WaitForPageLoaded();
        }

        public bool IsActorPresent(string name) => driver.FindElements(By.XPath(lnkActor(name))).Count > 0;

        public SerialPage ClickOnActor(string name)
        {
            driver.FindElement(By.XPath(lnkActor(name))).Click();
            return WaitForPageLoaded();
        }
        public SerialPage ClickCast()
        {
            driver.FindElement(By.CssSelector(btnCast)).Click();

            return WaitForPageLoaded();
        }

        public int GetActorsCount() => driver.FindElements(By.CssSelector(lstActors)).Count;

        public SerialPage ClickMoreButton()
        {
            driver.FindElement(By.CssSelector(btnMore)).Click();
            return WaitForPageLoaded();
        }
         
        public bool IsLessButtonDisplayed() => driver.FindElements(By.CssSelector(btnLess)).Count > 0;
    }
}
