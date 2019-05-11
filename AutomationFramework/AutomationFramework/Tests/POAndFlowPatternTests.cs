using AutomationFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Tests
{
    public class POAndFlowPatternTests
    {
        const string NBC_URL = "https://www.nbc.com/";
        public class PageObjectTest : BaseTest
        {
            [Test]
            public void PageObject()
            {
                Driver1.Navigate().GoToUrl(NBC_URL);

                Assert.That(() => new NBCPage(Driver1).IsNBCPageLoaded(), Is.True.After(15).Seconds.PollEvery(1).Seconds, "Page has not been loaded after 15 seconds");

                new NBCHeader(Driver1).ClickApp();
                Assert.That(new NBCAppPage(Driver1).IsAndroidAppBlockDisplayed(), Is.True, "Android app link does not present on Apps page");
            }
        }

        public class FlowTest : BaseTest
        {
            [Test]
            public void Flow()
            {
                Driver1.Navigate().GoToUrl(NBC_URL);

                Assert.That(() => new NBCPage(Driver1).IsNBCPageLoaded(), Is.True.After(15).Seconds.PollEvery(1).Seconds, "Page has not been loaded after 15 seconds");

                Assert.That(new NBCHeader(Driver1).ClickApp().IsAndroidAppBlockDisplayed(), Is.True, "Android app link does not present on Apps page");
            }

        }

    }
}
