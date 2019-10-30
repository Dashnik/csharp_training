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
            List<ContactData> oldcontacts = ContactData.GetAll();
            ContactData oldData = oldcontacts[0];
            ContactData newData = new ContactData("Test", "Test2");
            app.contacts.CheckEmptyContact();
            //app.contacts.EditContact(0,newData); //original row
            app.contacts.EditContact(oldData, newData);

            List<ContactData> newcontacts = app.contacts.GetContactList();
            oldcontacts[0].Firstname = newData.Firstname;
            oldcontacts[0].Lastname = newData.Lastname;

            oldcontacts.Sort();
            newcontacts.Sort();
            Assert.AreEqual(oldcontacts, newcontacts);

            foreach (ContactData contact in newcontacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Firstname, contact.Firstname);
                    Assert.AreEqual(newData.Lastname, contact.Lastname);
                }
            }

        }
    }
}
