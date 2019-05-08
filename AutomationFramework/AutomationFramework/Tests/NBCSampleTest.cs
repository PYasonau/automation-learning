using AutomationFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Tests
{
    public class NBCSampleTest
    {

        private IWebDriver Driver;

        [SetUp]
        public void CreateDriver()
        {
            Driver = new RemoteWebDriver(new ChromeOptions { });
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void QuitDriver()
        {
            Driver?.Quit();
        }

        [Test]
        public void NBCSample()
        {
            Driver.Navigate().GoToUrl("http://www.nbc.com");
            var firstPopularVideo = new NBCPage(Driver).PopularShowsBlock.PopularShowBlock(0);
            Assert.That(() => firstPopularVideo.GetTitle, Is.EqualTo(firstPopularVideo.GetImageAlt).After(10).Seconds.PollEvery(1).Seconds);

            new NBCPage(Driver).NBCHeader.ClickSHows();
        }
    }
}
