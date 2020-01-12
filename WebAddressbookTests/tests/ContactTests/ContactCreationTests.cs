using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests.tests.ContactTests
{
    [TestFixture]
    public class ContactCreationTests : AuthBaseTest
    {

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {   Address = GenerateRandomString(100), 
                    Email = GenerateRandomString(100),
                    Telephone_home = GenerateRandomString(30)
                });
            }

            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
            //prepare
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
