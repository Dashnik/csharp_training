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

        protected ApplcationManager app;

        [SetUp]
        protected void SetupTest()
        {
            app = new ApplcationManager();
            app.Navi.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }


    }
}

