using NUnit.Framework;


namespace WebAddressbookTests.tests.ContactTests
{
    [TestFixture]
    public class ContactInformationTests : AuthBaseTest
    {
        private readonly int CONTACT_INDEX = 0;

        [Test]
        public void ContactInformationTest()
        {
            //prepare
            app.Contact.ContactsShouldNotBeEmpty();
           
            //action
            ContactData ContactInfoFromMainPage = app.Contact.GetContactInfoFromMainPage(CONTACT_INDEX);
            ContactData ContactInfoFromContacModifyPage = app.Contact.GetContactInfoFromContacModifyPage(CONTACT_INDEX);


            //verification
//            Assert.AreEqual(ContactInfoFromMainPage, ContactInfoFromContacModifyPage);
            Assert.AreEqual(ContactInfoFromMainPage.Address, ContactInfoFromContacModifyPage.Address);
            Assert.AreEqual(ContactInfoFromMainPage.AllPhones, ContactInfoFromContacModifyPage.AllPhones);
            Assert.AreEqual(ContactInfoFromMainPage.AllEmails, ContactInfoFromContacModifyPage.AllEmails);
        }

        [Test]
        public void ContactDetailInformationTest()
        {
            //prepare
            app.Contact.ContactsShouldNotBeEmpty();

            //action
            ContactData ContactInfoFromMainPage = app.Contact.GetContactInfoFromContacModifyPage(CONTACT_INDEX);
            string ContactInfoFromContactDetailInformationPage = app.Contact.GetContactInfoFromContactDetailInformationPage(CONTACT_INDEX);


            //verification
            Assert.AreEqual(ContactInfoFromMainPage.AllInfo, ContactInfoFromContactDetailInformationPage);
        }
    }
}
