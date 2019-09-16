using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests

{
    [TestFixture]
    public class GroupCreationTest : TestBase
    {
      
        [Test]
        public void GroupCreationTest1()
        {
            OpenHomePage();
            Login(new AccountData("admin","secret"));
            Gotothegrouppage();
            InitGroupCreation();
            fillnewroup(new GroupData("aaa"));
            submitgroupcreation();
            LogOut();
        }

    }
}
