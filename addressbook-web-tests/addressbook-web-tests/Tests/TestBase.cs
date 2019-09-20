using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class TestBase : ApplcationManager
    {

        //protected IWebDriver driver;
        //private StringBuilder verificationErrors;
        //protected string baseURL;
        //private bool acceptNextAlert = true;
        //protected LoginHelper loginHelper;
        //protected NavigationHelper navigationHelper;
        //protected GroupHelper groupHelper;
        protected ApplcationManager app;

        [SetUp]
        protected void SetupTest()
        {
            app = new ApplcationManager();
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }


    }
}

