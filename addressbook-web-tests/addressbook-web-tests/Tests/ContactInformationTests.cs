using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{

    [TestFixture]
    class ContactInformationTests : AuthTestBase
    {

        [Test]
        public void TestContactInformation()
        {
           
            ContactData fromTable = app.contacts.GetInformationFromTable(0);
            ContactData fromForm = app.contacts.GetContactInformationFromEditForm(0);
           
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllMails, fromForm.AllMails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            //verification
        }

        [Test]
        public void TestContactInformationFromProperties()
        {
            String fromProperties = app.contacts.GetInformationFromProperties(1);
           

            ContactData fromForm = app.contacts.GetContactInformationFromEditForm(1);

           Assert.AreEqual(fromProperties,fromForm.SuperFields);
                            
        }
    }
}
