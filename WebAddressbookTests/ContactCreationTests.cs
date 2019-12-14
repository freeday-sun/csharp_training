using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    class AddContactTests : BaseTest
    {

        [Test]
        public void AddContactTest()
        {
            GoToMainPage();
            FillLoginForm(new AccountData("admin", "secret"));
            ConfirmLogin();
            GoToAddContactPage();
            ContactData contact = new ContactData("firstname", "lastname", "address", "email");
            FillContactForm(contact);
            SubmitContactForm();
            ReturnToHomePage();
            Logout();
        }
    }
}
