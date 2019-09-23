﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class TestBase
    {

        protected ApplicationManager app;

        [SetUp]
        protected void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }
              
    }
}

