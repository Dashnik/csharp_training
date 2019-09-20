using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class NavigationHelper : baseHelper
    {
        private string baseURL;

        public NavigationHelper(IWebDriver driver, string baseURL)
            : base(driver)
        {
             this.baseURL = baseURL;
        }
        public void Gotothegrouppage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
    }
}
