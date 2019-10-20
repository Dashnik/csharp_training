using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;

namespace addressbook_web_tests 
{
    [TestFixture]
    public class CreateContacts : AuthTestBase
    {

        [Test]
        public void CreateContact()
        {
            ContactData contact = new ContactData("Tony", "Stark");
            List<ContactData> oldcontacts = app.contacts.GetContactListTest();
            app.Navi.GoToContact();
       
            app.contacts.FillDataForContact(contact);
            List<ContactData> newcontacts = app.contacts.GetContactListTest();
            oldcontacts.Add(contact);
            oldcontacts.Sort();
            newcontacts.Sort();
            Assert.AreEqual(oldcontacts, newcontacts);
            //   app.Auth.LogOut();
        }


      
       
    }
}
    
