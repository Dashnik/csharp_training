using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests 
{
    [TestFixture]
    public class CreateContacts : AuthTestBase
    {

        [Test]
        public void CreateContact()
        {
            List<ContactData> oldcontacts = app.contacts.GetContactList();
            app.Navi.GoToContact();
       
            app.contacts.FillDataForContact(new ContactData("Tony", "Stark"));
            List<ContactData> newcontacts = app.contacts.GetContactList();
            Assert.AreEqual(oldcontacts.Count + 1, newcontacts.Count);
            //   app.Auth.LogOut();
        }
    }
}
    
