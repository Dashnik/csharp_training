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
    class RemoveContact : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Navi.OpenContactPage();
            app.contacts.CheckEmptyContact();
            app.contacts.RemoveContact(0);
        }
    }
}