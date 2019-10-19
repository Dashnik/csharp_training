using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {

        [Test]

        public void ContactModificationTest()
        {
            app.Navi.OpenContactPage();
            List<ContactData> oldcontacts = app.contacts.GetContactList();
            ContactData newData = new ContactData("Capitan", "America");
            app.contacts.CheckEmptyContact();
            app.contacts.ChooseLineForEditing(0);
            app.contacts.EditContact(newData);

            List<ContactData> newcontacts = app.contacts.GetContactList();
            oldcontacts[0].Firstname = newData.Firstname;
            oldcontacts[0].Lastname = newData.Lastname;

            oldcontacts.Sort();
            newcontacts.Sort();
            Assert.AreEqual(oldcontacts, newcontacts);
            
        }
    }
}
