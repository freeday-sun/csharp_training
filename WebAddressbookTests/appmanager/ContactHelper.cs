using OpenQA.Selenium;
using System;

namespace WebAddressbookTests
{
    public class ContactHelper : BaseHelper
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }


        public ContactHelper Create(ContactData contact) 
        {
            manager.Navigator.GoToAddContactPage();
            FillContactForm(contact);
            SubmitContactForm();
            ReturnToHomePage();
            return this;
        }

        internal ContactHelper Modify(ContactData newContactData, int index)
        {
            manager.Navigator.GoToMainPage();
            InitModificateContact(index);
            FillContactForm(newContactData);
            SubmitModificationContact();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(int index)
        {
            manager.Navigator.GoToMainPage();
            SelectContact(index);
            SubmitRemoveContact();
            SubmitRemoveContectAlert();
            return this;
        }

        private ContactHelper SubmitModificationContact()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private ContactHelper InitModificateContact(int index)
        {
            driver.FindElement(By.XPath("//a[@href = \"edit.php?id=" + index + "\"]")).Click();
            return this;
        }

        private void SubmitRemoveContectAlert()
        {
            driver.SwitchTo().Alert().Accept();
        }

        private ContactHelper SubmitRemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value=\"Delete\"]")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.CssSelector("input[name=\"selected[]\"]")).Click();
            return this;
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper SubmitContactForm()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
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
            driver.FindElement(By.Name("home")).Click();
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(contact.Telephone_home);
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
            return this;
        }
    }
}
