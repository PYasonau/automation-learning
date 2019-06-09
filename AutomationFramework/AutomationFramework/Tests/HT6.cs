using AutomationFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Tests
{
    public class HT6
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
        public void HT6Test()
        {
            var expectedActorsCount = 7;
            var JamesSpader = "James Spader";
            var Mozhan = "Mozhan Marnò";
            var Hisham = "Hisham Tawfiq ";
            var Megan = "Megan Boone";

            var headerPage = new NBCHeader(driver);
            var nbcShows = headerPage
                .ClickSHows();

            Assert.That(nbcShows.IsShowBlockByNameExist(nbcSerialName),
                        Is.True, $"Сериала с именем {nbcSerialName} нет");

            var serialPage = nbcShows.ClickOnShowBlockByName(nbcSerialName);

            serialPage.ClickAddToFavorite().ClosePopUpIfPresent().ClickCast();

            Assert.That(serialPage.GetActorsCount(), Is.EqualTo(expectedActorsCount), "Actors count is not as expected");
            Assert.That(serialPage.IsActorPresent(JamesSpader), Is.True, $"Actor {JamesSpader} is not present");
            Assert.That(serialPage.IsActorPresent(Mozhan), Is.True, $"Actor {Mozhan} is not present");
            Assert.That(serialPage.IsActorPresent(Hisham), Is.True, $"Actor {Hisham} is not present");

            serialPage.ClickOnActor(Megan).ClickMoreButton();

            Assert.That(serialPage.IsLessButtonDisplayed(), Is.True, "Button Less is not present");
        }
    }
}
