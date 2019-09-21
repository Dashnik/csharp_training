using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests 
{
    [TestFixture]
    public class CreateContacts : TestBase
    {

        [Test]
        public void CreateContact()
        {
            app.Navi.GoToContact();
            app.contacts.FillDataForContact(new ContactData("Vasya", "Pupkin"));
            app.Auth.LogOut();
        }
    }
}
    
