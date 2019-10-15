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
           
            app.contacts.CheckEmptyContact();
            app.contacts.ChooseLineForEditing(1);
            app.contacts.EditContact(new ContactData("Capitan", "America"));

            List<ContactData> oldcontacts = app.contacts.GetContactList();
            List<ContactData> newcontacts = app.contacts.GetContactList();


            Assert.AreEqual(oldcontacts, newcontacts);
            
        }
    }
}
