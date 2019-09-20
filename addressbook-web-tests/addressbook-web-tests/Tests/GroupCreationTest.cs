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
            app.Navi.OpenHomePage();
            app.Auth.Login(new AccountData("admin","secret"));
            app.Navi.Gotothegrouppage();
            app.Groups.InitGroupCreation();
            app.Groups.fillnewroup(new GroupData("aaa"));
            app.Groups.submitgroupcreation();
            app.Auth.LogOut();
        }

    }
}
