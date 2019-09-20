using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace addressbook_web_tests
{
    public class baseHelper
    {
        protected IWebDriver driver;

        public baseHelper(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
