using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class ContactHelper : BaseHelper
    {
        public ContactHelper(IWebDriver driver) : base(driver)
        {
        }

        public ContactHelper CheckEmptyContact()
        {
            driver.FindElement(By.LinkText("home")).Click();
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

        public void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            driver.FindElement(By.LinkText("home")).Click();
            SelectGroupFromFilter(group.Name);
            ChooseContactOnMainPage(contact.Id);
            RemoveContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }       

        private void SelectGroupFromFilter(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

       
        private void RemoveContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            driver.FindElement(By.LinkText("home")).Click();
            ClearGroupFilter();
            ChooseContactOnMainPage(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver,TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public string  GetInformationFromProperties(int index)
        {
            driver.FindElement(By.LinkText("home")).Click();
            InitContactProperties(index);
            string alltext = driver.FindElement(By.Id("content")).Text;
            return alltext;                     
        }

        public void InitContactProperties(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            driver.FindElement(By.LinkText("home")).Click();
            ChooseLineForEditing(index);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string mail = driver.FindElement(By.Name("email")).GetAttribute("value");
            string mail2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string mail3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");                 
                        
            return new ContactData(firstname, lastname)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Mail= mail,
                Mail2= mail2,
                Mail3 = mail3
            };

        }

        public ContactData GetInformationFromTable(int index)
        {
            driver.FindElement(By.LinkText("home")).Click();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string address = cells[3].Text;
            string allmail = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstname, lastname)
            {
                Address = address,
                AllMails = allmail,
                AllPhones = allPhones,
            };
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            driver.FindElement(By.LinkText("home")).Click();
            List<ContactData> contacts = new List<ContactData>();
            ICollection<IWebElement> elements = driver.FindElements(By.TagName("tr"));
            foreach (IWebElement element  in elements.Skip(1))
            {
                IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                var lastcell = cells.ElementAt(2);
                var firstcell = cells.ElementAt(1);

                ContactData contact = new ContactData(lastcell.Text, firstcell.Text);
                contacts.Add(contact);
            }
            return contacts;
        }


        public List<ContactData> GetContactListTest()
        {

            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                driver.FindElement(By.LinkText("home")).Click();
                ICollection<IWebElement> elements = driver.FindElements(By.TagName("tr"));
                foreach (IWebElement element in elements.Skip(1))
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    var lastcell = cells.ElementAt(2);
                    var firstcell = cells.ElementAt(1);

                    ContactData contact = new ContactData(lastcell.Text, firstcell.Text);
                    contactCache.Add(contact);
                }
            }
           
            return new List<ContactData>(contactCache);
        }


        public ContactHelper FillDataForContact(ContactData contactData)
        {

            Type(By.Name("firstname"), contactData.Firstname);
            Type(By.Name("lastname"), contactData.Lastname);

            //driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public void  SubmitEnterButtonOnAddNewContact()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        public ContactHelper RemoveContactMainPage(int index)
        {
            ChooseContactOnMainPage(index);
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public ContactHelper RemoveContactMainPage(ContactData contacts)
        {
            ChooseContactOnMainPage(contacts.Id);
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public ContactHelper ChooseContactOnMainPage(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index + 2) + "]/td/input")).Click();     //driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper ChooseContactOnMainPage(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
            return this;
        }

        //this case for modification contac test and get old and new data
        public ContactHelper ChooseLineForEditing(int y)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (y + 1) + "]")).Click();
            return this;
        }

        public ContactHelper ChooseLineForEditing(String id)
        {            
            driver.FindElement(By.XPath("//input[@name='selected[]' and @value='" + id + "']")).Click();
            driver.FindElement(By.XPath("//td[@class='center']//a[@href='edit.php?id=" + id + "']")).Click();
            return this;
        }

        public ContactHelper EditContact(int line, ContactData contact)
        {
            ChooseLineForEditing(line);
            FillDataForContact(contact);
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper EditContact(ContactData contact, ContactData contactData)
        {            
            ChooseLineForEditing(contact.Id);
            FillDataForContact(contactData);
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

       


    }
}
