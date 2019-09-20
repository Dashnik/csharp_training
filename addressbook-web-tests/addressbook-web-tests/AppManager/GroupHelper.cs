using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class GroupHelper : baseHelper
    {
        
        public GroupHelper(IWebDriver driver) : base(driver)
        {
        }
        public void submitgroupcreation()
        {

            driver.FindElement(By.Name("submit")).Click();
        }

        public void fillnewroup(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Clear();

            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }
        public void InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            driver.FindElement(By.Name("group_name")).Click();
        }


    }

}
