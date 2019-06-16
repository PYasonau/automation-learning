using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework
{
    class Assembly
    {
        [OneTimeSetUp]
        public void SetAllureConfigDirectory()
        {
            Environment.SetEnvironmentVariable("ALLURE_CONFIG", TestContext.CurrentContext.WorkDirectory);
        }
    }
}
