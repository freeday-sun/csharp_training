using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests.tests.ContactTests
{
    [TestFixture]
    public class ContactModificationTests : AuthBaseTest
    {
        private readonly int CONTACT_INDEX = 0; //min value = 2, because in table contact_index begin with 2

        [Test]
        public void ContactModificationTest()
        {
            //prepare
            app.Contact.ContactsShouldNotBeEmpty();
            List<ContactData> oldContacts = app.Contact.GetGroupsList();

            //action
            ContactData newContactData = new ContactData("firstname1", "", "", "", "");
            app.Contact.Modify(newContactData, CONTACT_INDEX);

            //verification
            List<ContactData> newContacts = app.Contact.GetGroupsList();
            oldContacts[CONTACT_INDEX].Firstname = newContactData.Firstname;
            oldContacts[CONTACT_INDEX].Lastname = newContactData.Lastname;
            oldContacts[CONTACT_INDEX].Address = newContactData.Address;
            oldContacts[CONTACT_INDEX].Email = newContactData.Email;
            oldContacts[CONTACT_INDEX].Telephone_home = newContactData.Telephone_home;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
