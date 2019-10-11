using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
//using Windows.Forms;

namespace addressbook_web_tests
{
    [TestFixture]
    class RemoveGroup : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navi.Gotothegrouppage();
            List<GroupData> oldgroups = app.Groups.GetGroupList();
            app.Groups.CheckEmptyGroup();
            app.Groups.GroupLine(0)
            .RemoveGroup();
            List<GroupData> newgroups = app.Groups.GetGroupList();
            oldgroups.RemoveAt(0);
            Assert.AreEqual(oldgroups, newgroups);
        }
    }
}