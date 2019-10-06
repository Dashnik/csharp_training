using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
     
        [Test]
     
        public void LoginWithValidCredentials()
        {
            //prepare
            app.Auth.LogOut();
            //action
            AccountData account =  new AccountData("admin", "secret");
            app.Auth.Login(account);

            //verification
            Assert.IsTrue(app.Auth.IsLoggedIn());
        }
       
        [Test]
      
        public void LoginWithInValidCredentials()
        {
            app.Auth.LogOut();
            AccountData account = new AccountData("admin", "123");
            app.Auth.Login(account);
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }
    }
}
