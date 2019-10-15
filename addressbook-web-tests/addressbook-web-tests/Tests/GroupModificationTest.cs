using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ModificationTests : AuthTestBase
    {

        [Test]

        public void GroupModificationTest()
        {
            app.Navi.Gotothegrouppage();
            List<GroupData> oldgroups = app.Groups.GetGroupList();
            app.Groups.CheckEmptyGroup();
            app.Groups.GroupLine(0);
            app.Groups.EditGroup(new GroupData("name"));
            List<GroupData> newgroups = app.Groups.GetGroupList();
            Assert.AreNotEqual(oldgroups, newgroups);
        }
    }
}
