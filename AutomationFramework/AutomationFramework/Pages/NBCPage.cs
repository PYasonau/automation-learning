using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Pages
{
    public class NBCPage
    {
        private IWebDriver _driver;

        public NBCHeader NBCHeader => new NBCHeader(_driver);

        public PopularShowsBlock PopularShowsBlock => new PopularShowsBlock(_driver);

        public NBCPage(IWebDriver Driver)
        {
            _driver = Driver;
        }
        
    }
}
