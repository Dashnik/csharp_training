using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class GroupHelper : BaseHelper
    {
        
        public GroupHelper(IWebDriver driver) : base(driver)
        {
        }
        public GroupHelper Submitgroupcreation()
        {

            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper EditGroup(GroupData group)
        {   
            driver.FindElement(By.Name("edit")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.EditName);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.EditHeader);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.EditFooter);
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper Fillnewroup(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Clear();

            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }

        public GroupHelper RemoveGroup()
        {

          driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper GroupLine(int x)
        {
            //original row //driver.FindElement(By.Name("selected[]")).Click();
            driver.FindElement(By.XPath("(//input[@name='selected[]'])["+ x + "]")).Click();
           
            return this;
        }

        public GroupHelper NewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            driver.FindElement(By.Name("group_name")).Click();
            return this;
        }


    }

}
