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
    class RemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navi.Gotothegrouppage();
            app.Groups.GroupLine(2);
            app.Groups.RemoveGroup();
        }

        [Test]
        public void ContactRemovalTest()
        {
            app.Navi.OpenContactPage();
            app.contacts.ContactLine(2);
            app.contacts.RemoveContact();
        }
    }
}
