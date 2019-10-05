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
            app.Groups.GroupLine(2);
            app.Groups.EditGroup(new GroupData("AKEdit Name", "AKEdit Header", "AKEdit Footer"));
        }
    }
}
