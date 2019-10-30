using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        
        [Test]
        public void TestAddingContactToGroup()
        {
            app.Groups.CheckEmptyGroup();
            app.contacts.CheckEmptyContact();

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();

             app.contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }

    }
}
