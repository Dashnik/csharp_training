using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;//позволяет работать с таблицами в  БД
using System.Collections;
using System.IO; // этот юзинг позволяет работать с файлами и вызывать метод File
using System.Xml.Serialization;//юзинг позволяет работать с xml
using Newtonsoft.Json;//юзинг позволяет работать с json

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
               //  contacts.Add(new ContactData(GenerateRandomString(30))
                contacts.Add(new ContactData(GenerateRandomString(100), GenerateRandomString(10)) //row is worked
                { });
            }

            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"contacts.xml"));

        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }


        [Test,TestCaseSource("ContactDataFromJsonFile")]
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


        [Test]
        public void TestDbConnectivity()
        {
            DateTime start = DateTime.Now;
            List<ContactData> fromUI = app.contacts.GetContactListTest();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<ContactData> fromDb = ContactData.GetAll();                
            
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }
       
    }
}
    
