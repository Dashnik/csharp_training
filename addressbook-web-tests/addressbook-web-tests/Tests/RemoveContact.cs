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
    class RemoveContact : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {

            app.Navi.OpenContactPage();
            List<ContactData> oldcontacts = ContactData.GetAll();
            ContactData toBeRemoved = oldcontacts[0];

            app.contacts.CheckEmptyContact();
            app.contacts.RemoveContactMainPage(toBeRemoved);
            //app.contacts.RemoveContactMainPage(0);
            List<ContactData> newcontacts = ContactData.GetAll();

            oldcontacts.RemoveAt(0);
            newcontacts.Sort();
            oldcontacts.Sort();
            Assert.AreEqual(oldcontacts, newcontacts);

            foreach (ContactData contact in newcontacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}