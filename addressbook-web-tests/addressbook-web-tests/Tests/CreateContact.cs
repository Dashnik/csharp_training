using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;
using System.IO; // этот юзинг позволяет работать с файлами и вызывать метод File


namespace addressbook_web_tests 
{
    [TestFixture]
    public class CreateContacts : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {

                // contacts.Add(new ContactData(GenerateRandomString(30))
                contacts.Add(new ContactData("Firstname", "Lastname")
                {
                    Firstname = GenerateRandomString(100),
                 Lastname = GenerateRandomString(10)
                });
            }

            return contacts;
        }

        //public static IEnumerable<ContactData> ContactDataFromFile()
        //{
        //    List<ContactData> contacts = new List<ContactData>();
        //    string[] lines = File.ReadAllLines(@"contacts.csv");
        //    foreach (string l in lines)
        //    {
        //        string[] parts = l.Split(',');
        //        contacts.Add(new ContactData("Firstname", "Lastname")
        //        {
        //            Firstname = parts[1],
        //             Lastname = parts[2]
        //        });
        //    }
        //    return contacts;
        //}

        [Test,TestCaseSource("ContactDataFromFile")]//("RandomContactDataProvider")]
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
    
