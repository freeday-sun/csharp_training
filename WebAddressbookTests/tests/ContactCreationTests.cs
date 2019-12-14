using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : BaseTest
    {

        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("firstname", "lastname", "address", "email");
            app.Contact.Create(contact);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "", "", "");
            app.Contact.Create(contact);
        }
    }
}
