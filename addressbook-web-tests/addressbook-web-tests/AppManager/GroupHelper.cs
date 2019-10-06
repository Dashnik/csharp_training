using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

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
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            driver.FindElement(By.Name("update")).Click();
            return this;

        }

       
        public GroupHelper FillnewGroup(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }



        public GroupHelper RemoveGroup()
        {

            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper GroupLine(int x)
        {

            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));

            int quantityelements = elements.Count();

            if (quantityelements <= 0)
            {
                NewGroupCreation();
                FillnewGroup(new GroupData("testname", "testheader ", "testfooter"));
                Submitgroupcreation();
                driver.FindElement(By.LinkText("groups")).Click();
            }

            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + x + "]")).Click();

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
