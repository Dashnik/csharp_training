using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace addressbook_web_tests
{
   public class ContactHelper : BaseHelper
    {
        public ContactHelper(IWebDriver driver) : base(driver)
        {
        }

        public ContactHelper FillDataForContact(ContactData contactData)
        {
            
            Type(By.Name("firstname"), contactData.Firstname);
            Type(By.Name("middlename"), contactData.Middlename);

            //driver.FindElement(By.Name("firstname")).Click();
            //driver.FindElement(By.Name("firstname")).Clear();
            //driver.FindElement(By.Name("firstname")).SendKeys(contactData.Firstname);


            //driver.FindElement(By.Name("middlename")).Clear();
            //driver.FindElement(By.Name("middlename")).SendKeys("tester");
            //driver.FindElement(By.Name("lastname")).Clear();
            //driver.FindElement(By.Name("lastname")).SendKeys("test");
            //driver.FindElement(By.Name("nickname")).Clear();
            //driver.FindElement(By.Name("nickname")).SendKeys("t");
            //driver.FindElement(By.Name("company")).Clear();
            //driver.FindElement(By.Name("company")).SendKeys("foox");
            //driver.FindElement(By.Name("address")).Clear();
            //driver.FindElement(By.Name("address")).SendKeys("street");
            //driver.FindElement(By.Name("home")).Clear();
            //driver.FindElement(By.Name("home")).SendKeys("5566");
            //driver.FindElement(By.Name("mobile")).Clear();
            //driver.FindElement(By.Name("mobile")).SendKeys("4411");
            //driver.FindElement(By.Name("work")).Clear();
            //driver.FindElement(By.Name("work")).SendKeys("111");
            //driver.FindElement(By.Name("email")).Click();
            //driver.FindElement(By.Name("email")).Clear();
            //driver.FindElement(By.Name("email")).SendKeys("test@tes.com");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Notes:'])[1]/following::input[1]")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            //System.Windows.Forms.SendKeys.Send("{ENTER}");
            
            return this;
           
        }

        public ContactHelper ContactLine (int x)
        {

            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + x + "]")).Click();

            return this;
        }

        public ContactHelper EditContact(ContactData contact)
        {
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Tony'])[1]/following::img[2]")).Click();
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            driver.FindElement(By.Name("update")).Click();
            return this;


        }



    }
}
