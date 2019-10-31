using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{

    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void RemovingContactFromGroup()
        {
            app.Groups.CheckEmptyGroup();
            app.contacts.CheckEmptyContact();


            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();

            if (oldList.Count() == 0)
            {
                ContactData contactnew = ContactData.GetAll().Except(oldList).First();
                app.contacts.AddContactToGroup(contactnew, group);
            }
            List<ContactData> oldListContacts = group.GetContacts();
            ContactData contact = oldListContacts[0];

            app.contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
