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
            List<ContactData> oldcontacts = app.contacts.GetContactList();
            app.contacts.CheckEmptyContact();
            app.contacts.RemoveContactMainPage(0);
            List<ContactData> newcontacts = app.contacts.GetContactList();
            oldcontacts.RemoveAt(0);
            Assert.AreEqual(oldcontacts, newcontacts);
        }
    }
}