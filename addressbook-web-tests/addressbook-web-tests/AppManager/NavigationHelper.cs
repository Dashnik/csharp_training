using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class NavigationHelper : BaseHelper
    {
        private string baseURL;

        public NavigationHelper(IWebDriver driver, string baseURL)
            : base(driver)
        {
             this.baseURL = baseURL;
        }


        public void Gotothegrouppage()
        {
            if (driver.Url == baseURL + "addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
            
        }


        public void GoToContact()
        {
            if (driver.Url == baseURL + "addressbook/edit.php"
                && IsElementPresent(By.Name("submit")))
            {
                return;
            }
            driver.FindElement(By.LinkText("add new")).Click();
        }


        public void OpenBasePage()
        {
             driver.Navigate().GoToUrl(baseURL);
        }


        public void OpenContactPage()
        {
            if (driver.Url == baseURL + "addressbook/")
            {
                return;
            }

            driver.FindElement(By.LinkText("home")).Click();
        }
        
    }
}
