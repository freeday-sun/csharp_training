using NUnit.Framework;


namespace WebAddressbookTests.tests.ContactTests
{
    [TestFixture]
    public class ContactModificationTests : AuthBaseTest
    {
        private readonly int CONTACT_INDEX = 0;

        [Test]
        public void ContactModificationTest()
        {
            //prepare
            app.Contact.ContactsShouldNotBeEmpty();
           
            //action
            ContactData newContactData = new ContactData("firstname1", null, null, null, null);
            app.Contact.Modify(newContactData, CONTACT_INDEX);

            //verification
            //so far without verification
        }
    }
}
