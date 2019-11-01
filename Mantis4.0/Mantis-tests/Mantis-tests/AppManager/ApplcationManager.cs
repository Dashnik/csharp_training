using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace Mantis_tests
{
    public class ApplicationManager
    {

        public IWebDriver driver;
        protected string baseURL;
        protected LoginHelper loginHelper { get; set; }

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }
        public JamesHelper James { get; set; }
        internal MailHelper Mail { get; set; }
        public ProjectHelper Project { get; set;}
        public ManagementMenuHelper ManagementMenu { get;  set; }
        public APIHelper API { get; set;}

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            loginHelper = new LoginHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            Project = new ProjectHelper(this);
            ManagementMenu = new ManagementMenuHelper(this, baseURL);
            API = new APIHelper(this);
            
        }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        ~ApplicationManager() //деструктор 
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
      
        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
            
                newInstance.driver.Url = "http://localhost/mantisbt-2.22.1/mantisbt-2.22.1";
               
                app.Value = newInstance;
            }
            return app.Value;
        }
    }
}
