using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class ApplicationManager
    {

        public IWebDriver driver;
        protected string baseURL;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {

            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            loginHelper = new LoginHelper(driver);
            navigationHelper = new NavigationHelper(driver, baseURL);
            groupHelper = new GroupHelper(driver);
            contactHelper = new ContactHelper(driver);
        }

        ~ApplicationManager() //деструктор 
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
        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navi.OpenBasePage();
                app.Value = newInstance;
            }
            return app.Value;
        }
    }
}
