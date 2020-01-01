using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests.tests.ContactTests
{
    [TestFixture]
    public class ContactCreationTests : AuthBaseTest
    {

        [Test]
        public void ContactCreationTest()
        {
            //prepare
            ContactData contact = new ContactData("firstname", "lastname", "address", "email", "telephone");
            List<ContactData> oldContacts = app.Contact.GetContactsList();

            //action
            app.Contact.Create(contact);

            //verification
            List<ContactData> newContacts = app.Contact.GetContactsList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            //prepare
            ContactData contact = new ContactData("", "", "", "", "");
            List<ContactData> oldContacts = app.Contact.GetContactsList();

            //action
            app.Contact.Create(contact);

            //verification
            List<ContactData> newContacts = app.Contact.GetContactsList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
