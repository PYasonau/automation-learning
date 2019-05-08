using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class PopularShowsBlock
    {
        private IWebDriver driver;

        private static string popularShowTitle = "//*[text()='Popular Shows']";

        private static By BlockLocator(int blockNumber) => By.XPath($"//*[text()='Popular Shows']/../..//a[@data-index='{blockNumber}']");        


        public PopularShowsBlock(IWebDriver driver)
        {
            this.driver = driver;
        }

        public SeriesBlock PopularShowBlock(int number) => new SeriesBlock(BlockLocator(number), driver);
    }
}
