using AutomationFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Tests
{
    public class HT5
    {
        private IWebDriver driver;
        private string nbcUrl = "https://www.nbc.com";
        private string nbcSerialName = "The Blacklist";

        [SetUp]
        public void CreateDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(nbcUrl);
        }

        [TearDown]
        public void QuitDriver()
        {
            driver?.Quit();
        }

        [Test]
        public void HT5Test()
        {
            var headerPage = new NBCHeader(driver);
            headerPage.ClickSHows();

            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));

            var nbcShows = new ShowsPage(driver);
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
            nbcShows.ClickCurrent();
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
            nbcShows.ClickUpcoming();
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
            nbcShows.ClickThrowback();
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
            nbcShows.ClickAll();
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
            Assert.That(nbcShows.IsShowBlockByNameExist(nbcSerialName), Is.True, $"Сериала с именем {nbcSerialName} нет");

            nbcShows.ClickOnShowBlockByName(nbcSerialName);

            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
        }
    }
}
