using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests 
{
    [TestFixture]
    public class CreateContacts : AuthTestBase
    {

        [Test]
        public void CreateContact()
        {
            app.Navi.GoToContact();
            app.contacts.FillDataForContact(new ContactData("Tony", "Stark"));
         //   app.Auth.LogOut();
        }
    }
}
    
