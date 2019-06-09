using AutomationFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Tests
{
    public class HT52
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
        public void HT52Test()
        {
            var headerPage = new NBCHeader(driver);
            var  nbcShows = headerPage
                .ClickSHows()
                .ClickCurrent()
                .ClickUpcoming()
                .ClickThrowback()
                .ClickAll();

            Assert.That(nbcShows.IsShowBlockByNameExist(nbcSerialName),
                Is.True, $"Сериала с именем {nbcSerialName} нет");

            nbcShows.ClickOnShowBlockByName(nbcSerialName);
        }
    }
}
