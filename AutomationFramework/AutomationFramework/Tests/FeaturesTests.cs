using NUnit.Allure.Core;
using NUnit.Allure.Steps;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Tests
{
    public class FeaturesTests
    {

        public class PassTest : BaseTest
        {
            [AllureStep]
            public void allureStep()
            {
                Console.WriteLine("this is from methods");
            }

            [Test]
            public void Passed()
            {
                allure.WrapInStep(() => Assert.True(true, "Assert pass action"));
                allureStep();
                allure.WrapInStep(() => Assert.Fail("this test will pass"), "Assert fail action");
            }
        }

        public class IgnoreTest : BaseTest
        {
            [Test]
            public void Ignore()
            {
                Assert.Ignore("Will be ignored. Reason");
            }
        }

        public class AssertTest : BaseTest
        {

            private int Return5() => 5;

            [Test]
            public void Assertion()
            {
                Assert.Multiple(() => 
                {
                    Assert.True(Return5() == 6, "Unexpected");
                    Assert.That(Return5() == 7, Is.True, "Unexpected");
                    Assert.That(Return5(), Is.EqualTo(8), "Unexpected");
                });
            }
        }

        public class AssertDuringTimeTest : BaseTest
        {

            private int Return5()
            {
                var number = new Random().Next(10);
                TestContext.Progress.WriteLine($"Generated number: {number}");
                return number;
            }

            [Test]
            public void AssertDuringTime()
            {
                Assert.That(() => Return5(), Is.EqualTo(8).After(30).Seconds.PollEvery(1).Seconds);
            }
        }

        public class Params : BaseTest
        {
            [TestCase(5)]
            [TestCase(7)]
            [TestCase(9)]
            public void ParamsTest(int number)
            {
                Assert.That(number, Is.EqualTo(7), "Unexpected number");
            }
        }
    }
}
