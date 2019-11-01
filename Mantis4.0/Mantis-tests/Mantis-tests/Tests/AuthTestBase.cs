using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mantis_tests
{
    public class AuthTestBase : TestBase
    {

        [SetUp]
        protected void SetupLogin()
        {
            app = ApplicationManager.GetInstance();
            app.Auth.Login(new AccountData("administrator", "root"));
                        
        }
    }
}
