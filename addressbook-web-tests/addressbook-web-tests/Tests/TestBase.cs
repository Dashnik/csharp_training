using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class TestBase
    {

        protected ApplicationManager app;
        public static bool PERFORM_LONG_UI_CHECKS_GROUPS = false;
        public static bool PERFORM_LONG_UI_CHECKS_CONTACTS = true;
        [SetUp]
        protected void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        //метод который генерирует случайные символы
        public static string GenerateRandomString(int max)
        {
           
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
              builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
              
        }


    }
}

