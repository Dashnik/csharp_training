using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class LoginHelper : BaseHelper
    {
                public LoginHelper (IWebDriver driver) : base(driver) 
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
                LogOut();
            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.Id("LoginForm")).Submit();
        }

        public bool IsLoggedIn() 
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && driver.FindElement(By.Name("Logout")).FindElement(By.TagName("b")).Text == "(" + account.Username + ")";
        }



        public void LogOut()
        { 
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }

    }
}
