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
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToContact();
            FillDataForContact(new ContactData("Vasya", "Pupkin"));
        }

    }
    }
    
