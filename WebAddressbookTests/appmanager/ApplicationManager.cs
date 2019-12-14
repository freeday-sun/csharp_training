using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{

    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        
        protected LoginHelper loginHelper;
        protected NavigatorHelper navigatorHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        public ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/";
            loginHelper = new LoginHelper(driver);
            navigatorHelper = new NavigatorHelper(driver, baseURL);
            groupHelper = new GroupHelper(driver);
            contactHelper = new ContactHelper(driver);
        }

        public LoginHelper Auth
        {
            get { return loginHelper; }
        }

        public NavigatorHelper Navigator
        {
            get { return navigatorHelper; }
        }

        public GroupHelper Groups
        {
            get { return groupHelper; }
        }

        public ContactHelper Contact
        {
            get { return contactHelper; }
        }

        public void StopBrowser()
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
    }
}
