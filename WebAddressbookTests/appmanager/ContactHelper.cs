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

        public ContactData GetContactInfoFromMainPage(int index)
        {
            manager.Navigator.GoToMainPage();
            IList<IWebElement> Contacts = driver.FindElements(By.Name("entry"))[index]
                                                .FindElements(By.TagName("td"));
            return GetInfoContacMainPage(Contacts);
        }

        public ContactData GetContactInfoFromContacModifyPage(int index)
        {
            manager.Navigator.GoToMainPage();

            InitModificateContact(index);
            return GetInfoContacModifyPage();
        }

        private ContactData GetInfoContacMainPage(IList<IWebElement> contacts)
        {
            string lastname = contacts[1].Text;
            string firstname = contacts[2].Text;
            string address = contacts[3].Text;
            string allPhones = contacts[5].Text;
            IList<IWebElement> emails = contacts[4].FindElements(By.TagName("a"));
            string allEmails = "";
            foreach (IWebElement email in emails)
            {
                allEmails = allEmails + email.Text;
            }
            allEmails.Trim();
            

            return new ContactData(firstname, lastname)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails,
            };
        }

        private ContactData GetInfoContacModifyPage()
        {
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string telephone_home = driver.FindElement(By.Name("home")).GetAttribute("value");
            string telephone_mobile = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string telephone_work = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstname, lastname)
            {
                Address = address,
                Telephone_home = telephone_home,
                Telephone_mobile = telephone_mobile,
                Telephone_work = telephone_work,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        private ContactHelper SubmitModificationContact()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private ContactHelper InitModificateContact(int index)
        {
            driver.FindElements(By.Name("entry"))[index] // contacts rows in table
                .FindElements(By.TagName("td"))[7] // edit button index in row in table
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        private void SubmitDeleteContectAlert()
        {
            driver.SwitchTo().Alert().Accept();
        }

        private ContactHelper SubmitDeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value=\"Delete\"]")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//tbody/tr["+ index +"]/td/input")).Click();
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
