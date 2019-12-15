using NUnit.Framework;


namespace WebAddressbookTests.test.ContactTests
{
    [TestFixture]
    public class ContactRemovalTests : BaseTest
    {
        private readonly int CONTACT_INDEX = 1;

        [Test]
        public void ContactRemovalTest()
        {
            app.Contact.Remove(CONTACT_INDEX);
        }
    }
}
