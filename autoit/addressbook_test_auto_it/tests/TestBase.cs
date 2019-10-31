using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_test_auto_it
{
    
    public class TestBase
    {
        public ApplicationManager app;

        [OneTimeSetUp]//Выполняется один раз перед всеми методами
        public void InitAppplication()
        {
            app = new ApplicationManager();
        }

        [OneTimeTearDown]
        public void stopApplication()
        {
            app.Stop();
        }
    }
}
