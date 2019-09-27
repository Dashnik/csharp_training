using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests

{
    
    public class GroupCreationTests : AuthTestBase
    {
      
        [Test]
        public void GroupCreationTest()
        {
          app.Navi.Gotothegrouppage();
            app.Groups
            .NewGroupCreation()
            .Fillnewroup(new GroupData("3", "2", "1"))
            .Submitgroupcreation();
           // app.Auth.LogOut();
        }

    }
}
