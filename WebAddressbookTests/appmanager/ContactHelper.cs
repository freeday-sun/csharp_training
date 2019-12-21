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
            driver.FindElement(By.XPath("//tbody/tr[" + index + "]//td[8]")).Click();
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
            driver.FindElement(By.XPath("//tbody/tr["+ index +"]/td/input")).Click();
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
            FillField(By.Name("firstname"), contact.Firstname);
            //            FillField(By.Name("middlename"), contact.Middlename);
            FillField(By.Name("lastname"), contact.Lastname);
            //            FillField(By.Name("nickname"), contact.Nickname);
            //            FillField(By.Name("title"), contact.Title);
            //            FillField(By.Name("company"), contact.Company);
            FillField(By.Name("address"), contact.Address);
            FillField(By.Name("home"), contact.Telephone_home);
            //            FillField(By.Name("mobile"), contact.Telephone_mobile);
            //            FillField(By.Name("work"), contact.Telephone_work);
            //            FillField(By.Name("fax"), contact.Telephone_fax);
            //            FillField(By.Name("email"), contact.Email);
            //            FillField(By.Name("email2"), contact.Email2);
            //            FillField(By.Name("email3"), contact.Email3);
            //            FillField(By.Name("homepage"), contact.Homepage);
            //            FillField(By.Name("address2"), contact.Address2);
            //            FillField(By.Name("phone2"), contact.Phone2);
            //            FillField(By.Name("notes"), contact.Notes);
            return this;
        }
    }
}
