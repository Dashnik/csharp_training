using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class ApplcationManager
    {

        protected IWebDriver driver;
        protected string baseURL;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
  
        public ApplcationManager()
        {

            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            loginHelper = new LoginHelper(driver);
            navigationHelper = new NavigationHelper(driver, baseURL);
            groupHelper = new GroupHelper(driver);
            contactHelper = new ContactHelper(driver);
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
                    }
        }
        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
        public NavigationHelper Navi
        {
            get
            {
                return navigationHelper;
            }
        }
        public ContactHelper contacts
        {
            get
            {
                return contactHelper;
            }
        }

    }
}
