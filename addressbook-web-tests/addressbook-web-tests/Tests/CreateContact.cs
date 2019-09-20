using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests 
{
    public class CreateContact : TestBase
    {

        [Test]
        public void CreateContact1()
        {
            app.Navi.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navi.GoToContact();
            app.contacts.FillDataForContact(new ContactData("Vasya", "Pupkin"));
            app.Auth.LogOut();
        }
    }
}
    
