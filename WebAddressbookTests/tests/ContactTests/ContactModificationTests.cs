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
            List<ContactData> oldContacts = app.Contact.GetContactsList();

            //action
            ContactData newContactData = new ContactData("firstname1", "lastname1");
            app.Contact.Modify(newContactData, CONTACT_INDEX);
            ContactData oldData = oldContacts[CONTACT_INDEX];

            //verification
            List<ContactData> newContacts = app.Contact.GetContactsList();
            oldContacts[CONTACT_INDEX].Firstname = newContactData.Firstname;
            oldContacts[CONTACT_INDEX].Lastname = newContactData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newContactData.Firstname, contact.Firstname);
                    Assert.AreEqual(newContactData.Lastname, contact.Lastname);
                }
            }
        }
    }
}
