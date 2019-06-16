using Allure.Commons;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutomationFramework.Tests
{
    [Parallelizable(ParallelScope.Fixtures)]
    [AllureNUnit]
    public class BaseTest : AlluresetUp
    {

        protected IWebDriver Driver1;
        protected IWebDriver Driver2;
        protected Allure.Commons.AllureLifecycle allure
        {
            get
            {
                Environment.SetEnvironmentVariable("ALLURE_CONFIG", Path.Combine(TestContext.CurrentContext.WorkDirectory, "allureConfig.json"));
                return Allure.Commons.AllureLifecycle.Instance;
            }
        }


        [OneTimeSetUp]
        public void CreateDrivers()
        {

        }

        [SetUp]
        public void AllureSetUp()
        {
        }

        [TearDown]
        public void AllureTearDown()
        {
        }

        [TearDown]
        public void CloseDrivers()
        {
            Driver1?.Quit();
            Driver2?.Quit();
        }

        public IWebDriver CreateDriver()
        {
            return new ChromeDriver();
        }

        public void NavigateToSite(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.nbc.com");
        }
    }

    public class AlluresetUp
    {
        static AlluresetUp()
        {
            Environment.SetEnvironmentVariable("ALLURE_CONFIG", Path.Combine(TestContext.CurrentContext.WorkDirectory, "allureConfig.json"));
        }
    }
}
