using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
 


namespace Mantis_tests
{
   public class RegistrationHelper : BaseHelper
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
                        FillRegistrationForm(account);
            SubmitRegistration();
        }

        private void OpenRegistrationForm()
        {
            driver.FindElement(By.XPath("//div[@id='login-box']/div/div[2]/a")).Click();
           // driver.FindElement(By.LinkText("Signup for a new account")).Click();
            //   driver.FindElement(By.LinkText("Signup for a new account")).Click();
            //   driver.FindElements(By.CssSelector("span.bracket-link"))[0].Click();
        }

        private void SubmitRegistration()
        {
            driver.FindElement(By.CssSelector("input.button")).Click();
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        private void OpenMainPage()
        {
            manager.driver.Url = "http://localhost/mantisbt-2.22.1/mantisbt-2.22.1/my_view_page.php";
        }
    }
}
