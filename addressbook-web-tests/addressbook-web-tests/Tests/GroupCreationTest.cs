using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests

{

    public class GroupCreationTests : AuthTestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            app.Navi.Gotothegrouppage();
              //        List<GroupData> oldgroups = app.Groups.GetGroupList();
            app.Groups
            .NewGroupCreation()
            .FillnewGroup(new GroupData("3"))//"1","2"))
                .Submitgroupcreation();
            // app.Auth.LogOut();
            //List<GroupData> newgroups = app.Groups.GetGroupList();
           // Assert.AreEqual(oldgroups.Count + 1, newgroups.Count);
        }
     
    }
}
