using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class ContactHelper : BaseHelper
    {



        public ContactHelper(IWebDriver driver) : base(driver)
        {
        }

        public ContactHelper CheckEmptyContact()
        {
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr"));

            int quantityelements = elements.Count();

            if (quantityelements <= 1)
            {
                driver.FindElement(By.LinkText("add new")).Click();
                FillDataForContact(new ContactData("Tony", "Stark"));
                driver.FindElement(By.LinkText("home")).Click();
            }
            return this;
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
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }



        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            //System.Windows.Forms.SendKeys.Send("{ENTER}");

            return this;

        }



        public ContactHelper ChooseLineForEditing(int y)

        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + y + "]")).Click();
            return this;
        }



        public ContactHelper EditContact(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            driver.FindElement(By.Name("update")).Click();
            return this;


        }





    }
}
