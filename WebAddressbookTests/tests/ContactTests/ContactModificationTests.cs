using NUnit.Framework;


namespace WebAddressbookTests.test.ContactTests
{
    [TestFixture]
    public class ContactModificationTests : BaseTest
    {
        private readonly int CONTACT_INDEX = 4; //min value = 2, because in table contact_index begin with 2

        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData("firstname1", "lastname1", "address1", "email1", "telephone1");
            app.Contact.Modify(newContactData, CONTACT_INDEX);
        }
    }
}
