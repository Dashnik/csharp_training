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
            groupCache = null;
            return this;
        }

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                driver.FindElement(By.LinkText("groups")).Click();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    GroupData group = new GroupData(element.Text);
                    groupCache.Add(group);
                }
            }
           return new List<GroupData>(groupCache);
        }

        internal int GetGroupCount()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        //public GroupHelper CheckEmptyGroup()
        //{
        //    ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));

        //    int quantityelements = elements.Count();

        //    if (quantityelements <= 0)
        //    {
        //        NewGroupCreation();
        //        FillnewGroup(new GroupData("testname"));
        //        Submitgroupcreation();
        //        driver.FindElement(By.LinkText("groups")).Click();
        //    }

        //    return this;
        //}



        public GroupHelper EditGroup(GroupData group)
        {
                                 
            driver.FindElement(By.Name("edit")).Click();
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
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
            groupCache = null;
            return this;
        }

        public GroupHelper GroupLine(int x)
        {

            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" +(x+1) + "]")).Click();

            return this;
        }

        public GroupHelper NewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            driver.FindElement(By.Name("group_name")).Click();
            return this;
        }


        public GroupHelper CheckEmptyGroup()
        {
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));

            int quantityelements = elements.Count();

            if (quantityelements <= 0)
            {
                NewGroupCreation();
                FillnewGroup(new GroupData("testname"));
                Submitgroupcreation();
                driver.FindElement(By.LinkText("groups")).Click();
            }

            return this;
        }


    }

}
