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
    public class BaseTest
    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        protected void FillLoginForm(AccountData account)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
        }
        protected void ConfirmLogin()
        {
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        protected void GoToMainPage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook");
        }

        protected void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        protected void ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        protected void SubmitGroupForm()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        protected void FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }

        protected void GoToGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        protected void CreateNewGroup()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        protected void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }

        protected void SubmitContactForm()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
        }

        protected void FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            //            driver.FindElement(By.Name("middlename")).Click();
            //            driver.FindElement(By.Name("middlename")).Clear();
            //            driver.FindElement(By.Name("middlename")).SendKeys("test");
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            //            driver.FindElement(By.Name("nickname")).Click();
            //            driver.FindElement(By.Name("nickname")).Clear();
            //            driver.FindElement(By.Name("nickname")).SendKeys("test");
            //            driver.FindElement(By.Name("title")).Click();
            //            driver.FindElement(By.Name("title")).Clear();
            //            driver.FindElement(By.Name("title")).SendKeys("test");
            //            driver.FindElement(By.Name("company")).Click();
            //            driver.FindElement(By.Name("company")).Clear();
            //            driver.FindElement(By.Name("company")).SendKeys("test");
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(contact.Address);
            ///            driver.FindElement(By.Name("home")).Click();
            //            driver.FindElement(By.Name("home")).Clear();
            //            driver.FindElement(By.Name("home")).SendKeys("test");
            //            driver.FindElement(By.Name("mobile")).Click();
            //            driver.FindElement(By.Name("mobile")).Clear();
            //            driver.FindElement(By.Name("mobile")).SendKeys("test");
            //            driver.FindElement(By.Name("work")).Click();
            //            driver.FindElement(By.Name("work")).Clear();
            //            driver.FindElement(By.Name("work")).SendKeys("test");
            //            driver.FindElement(By.Name("fax")).Click();
            //            driver.FindElement(By.Name("fax")).Clear();
            //            driver.FindElement(By.Name("fax")).SendKeys("test");
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(contact.Email);
            //            driver.FindElement(By.Name("email2")).Click();
            //            driver.FindElement(By.Name("email2")).Clear();
            //            driver.FindElement(By.Name("email2")).SendKeys("test");
            //            driver.FindElement(By.Name("email3")).Click();
            //            driver.FindElement(By.Name("email3")).Clear();
            //            driver.FindElement(By.Name("email3")).SendKeys("test");
            //            driver.FindElement(By.Name("homepage")).Click();
            //            driver.FindElement(By.Name("homepage")).Clear();
            //            driver.FindElement(By.Name("homepage")).SendKeys("estset");
            //            driver.FindElement(By.Name("address2")).Click();
            //            driver.FindElement(By.Name("address2")).Clear();
            //            driver.FindElement(By.Name("address2")).SendKeys("test");
            //            driver.FindElement(By.Name("phone2")).Click();
            //            driver.FindElement(By.Name("phone2")).Clear();
            //            driver.FindElement(By.Name("phone2")).SendKeys("test");
            //            driver.FindElement(By.Name("notes")).Click();
            //            driver.FindElement(By.Name("notes")).Clear();
            //            driver.FindElement(By.Name("notes")).SendKeys("tset");
        }

        protected void GoToAddContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        protected void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        }
        protected void DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }
    }
}
