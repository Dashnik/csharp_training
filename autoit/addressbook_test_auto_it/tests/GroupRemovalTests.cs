using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_test_auto_it
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
         [Test]
        public void TestGroupRemoval()
        {
            app.Groups.CheckThatGroupExist("test");

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.RemoveGroup(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        //test
        
    }
}
