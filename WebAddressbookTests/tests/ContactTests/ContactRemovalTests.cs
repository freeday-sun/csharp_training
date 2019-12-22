using NUnit.Framework;


namespace WebAddressbookTests.tests.ContactTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthBaseTest
    {
        private readonly int CONTACT_INDEX = 2; //min value = 2, because in table contact_index begin with 2

        [Test]
        public void ContactRemovalTest()
        {
            //prepare
            app.Contact.ContactsShouldNotBeEmpty();

            //action
            app.Contact.Remove(CONTACT_INDEX);

            //verification
            //so far without verification
        }

        [Test]
        public void AllContactsRemovalTest()
        {
            //prepare
            app.Contact.ContactsShouldNotBeEmpty();

            //action
            app.Contact.RemoveAll();

            //verification
            System.Threading.Thread.Sleep(1000); // redirect to the main page does not have time to work
            Assert.IsTrue(app.Contact.ContactListIsEmpty());
        }
    }
}
