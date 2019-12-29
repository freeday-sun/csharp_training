using OpenQA.Selenium;
using System;
using System.Collections.Generic;

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
            manager.Navigator.ReturnToHomePageAfterWorkWithContact();
            return this;
        }

        private List<ContactData> contactCache = null;
        public List<ContactData> GetGroupsList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToMainPage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name=\"entry\"]"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> fields = element.FindElements(By.TagName("td"));
                    string Firstname = fields[2].Text;
                    string Lastname = fields[1].Text;

                    ContactData contacts = new ContactData(Firstname, Lastname);
                    contacts.Id = element.FindElement(By.XPath("//td//input")).GetAttribute("value");
                    contactCache.Add(contacts);
                }
            }
            return new List<ContactData>(contactCache);
        }

        internal ContactHelper Modify(ContactData newContactData, int index)
        {
            manager.Navigator.GoToMainPage();
            InitModificateContact(index);
            FillContactForm(newContactData);
            SubmitModificationContact();
            manager.Navigator.ReturnToHomePageAfterWorkWithContact();
            return this;
        }

        public ContactHelper Remove(int index)
        {
            manager.Navigator.GoToMainPage();
            SelectContact(index);
            SubmitDeleteContact();
            SubmitDeleteContectAlert();
            manager.Navigator.GoToMainPage();
            return this;
        }

        public ContactHelper RemoveAll()
        {
            manager.Navigator.GoToMainPage();
            SelectAllContacts();
            SubmitDeleteContact();
            SubmitDeleteContectAlert();
            manager.Navigator.GoToMainPage();
            return this;
        }

        public void ContactsShouldNotBeEmpty()
        {
            if (ContactListIsEmpty()) 
            {
                manager.Contact.Create(new ContactData("firstname", "lastname", "address", "email", "telephone"));
            }
        }

        public bool ContactListIsEmpty()
        {
            bool ContactTableRows = IsElementPresent(By.XPath("//tbody/tr[2]"));

            if (!ContactTableRows)
            {
                return true;
            }
            return false;
        }

        private ContactHelper SubmitModificationContact()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        private ContactHelper InitModificateContact(int index)
        {
            driver.FindElement(By.XPath("//tbody/tr[" + (index + 2)+ "]//td[8]")).Click();
            return this;
        }

        private void SubmitDeleteContectAlert()
        {
            driver.SwitchTo().Alert().Accept();
        }

        private ContactHelper SubmitDeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value=\"Delete\"]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//tbody/tr["+ (index + 2) +"]/td/input")).Click();
            return this;
        }

        private ContactHelper SelectAllContacts()
        {
            driver.FindElement(By.CssSelector("#MassCB")).Click();
            return this;
        }

        public ContactHelper SubmitContactForm()
        {
            driver.FindElement(By.CssSelector("input[value=\"Enter\"]")).Click();
            contactCache = null;
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
                        FillField(By.Name("email"), contact.Email);
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
