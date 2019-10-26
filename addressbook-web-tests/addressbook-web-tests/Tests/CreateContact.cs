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
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactData(GenerateRandomString(30))
                {
                    Firstname = GenerateRandomString(100),
                    Lastname = GenerateRandomString(100)
                });
            }

            return contact;
        }

        [Test,TestCaseSource("RandomContactDataProvider")]
        public void CreateContact(ContactData contact)
        {
           
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
    
