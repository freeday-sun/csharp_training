using NUnit.Framework;


namespace WebAddressbookTests.test.ContactTests
{
    [TestFixture]
    public class ContactRemovalTests : BaseTest
    {
        private readonly int CONTACT_INDEX = 2; //min value = 2, because in table contact_index begin with 2

        [Test]
        public void ContactRemovalTest()
        {
            app.Contact.Remove(CONTACT_INDEX);
        }
    }
}
