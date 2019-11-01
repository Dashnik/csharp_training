using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantis_tests
{
   public class LoginHelper : BaseHelper
    {
        public LoginHelper(ApplicationManager manager)
           : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }    
            Type(By.Name("username"), account.Username);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector("span.user-info"));
        }
        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggetUserName() == account.Username;

        }

        public string GetLoggetUserName()
        {
            return driver.FindElement(By.CssSelector("span.user-info")).Text;
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.XPath("//@span[@class='user-info' and contains(text(), 'administrator')]")).Click();
                driver.FindElement(By.XPath("//@a[@href='/mantisbt-2.22.1/logout_page.php'")).Click();
            }
        }
    }
}
