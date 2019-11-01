using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace Mantis_tests
{
    public class BaseHelper
    {
        
        protected ApplicationManager manager;
        protected IWebDriver driver;

        public BaseHelper(ApplicationManager manager)
        {
            this.manager = manager;
           driver = manager.driver;
        }


        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }

        }

        public void OpenHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }


        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
