using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests.tests.ContactTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthBaseTest
    {
        private readonly int CONTACT_INDEX = 0; //min value = 2, because in table contact_index begin with 2

        [Test]
        public void ContactRemovalTest()
        {
            //prepare
            app.Contact.ContactsShouldNotBeEmpty();
            List<ContactData> oldContacts = app.Contact.GetGroupsList();

            //action
            app.Contact.Remove(CONTACT_INDEX);
            System.Threading.Thread.Sleep(1000);// 

            //verification
            List<ContactData> newContacts = app.Contact.GetGroupsList();
            oldContacts.RemoveAt(CONTACT_INDEX);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void ContactsRemovalAllTest()
        {
            //prepare
            app.Contact.ContactsShouldNotBeEmpty();
            List<ContactData> oldContacts = app.Contact.GetGroupsList();

            //action
            app.Contact.RemoveAll();
            System.Threading.Thread.Sleep(1000);

            //verification
            List<ContactData> newContacts = app.Contact.GetGroupsList();
            Assert.IsTrue(newContacts.Count == 0);
        }
    }
}
