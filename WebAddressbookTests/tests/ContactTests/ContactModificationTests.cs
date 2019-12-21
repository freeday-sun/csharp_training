using NUnit.Framework;


namespace WebAddressbookTests.test.ContactTests
{
    [TestFixture]
    public class ContactModificationTests : BaseTest
    {
        private readonly int CONTACT_INDEX = 2; //min value = 2, because in table contact_index begin with 2

        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData("firstname1", null, null, null, null);
            app.Contact.Modify(newContactData, CONTACT_INDEX);
        }
    }
}
