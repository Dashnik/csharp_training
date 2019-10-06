using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {

        [Test]

        public void ContactModificationTest()
        {
            app.Navi.OpenContactPage();
            app.contacts.ChooseLineForEditing(1);
            app.contacts.EditContact(new ContactData("Capitan", "America"));
        }
    }
}
