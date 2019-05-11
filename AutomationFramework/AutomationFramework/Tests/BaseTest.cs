using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Tests
{
    [Parallelizable(ParallelScope.Fixtures)]
    public class BaseTest
    {
        protected IWebDriver Driver1;
        protected IWebDriver Driver2;
        [SetUp]
        public void CreateDrivers()
        {
            Driver1 = new RemoteWebDriver(new ChromeOptions { });
            Driver1.Manage().Window.Maximize();
        }

        [TearDown]
        public void CloseDrivers()
        {
            Driver1?.Quit();
            Driver2?.Quit();
        }

    }
}
