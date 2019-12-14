using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class AddContactTests : BaseTest
    {

        [Test]
        public void AddContactTest()
        {
            navigatorHelper.GoToMainPage();
            loginHelper.FillLoginForm(new AccountData("admin", "secret"));
            loginHelper.ConfirmLogin();
            navigatorHelper.GoToAddContactPage();
            ContactData contact = new ContactData("firstname", "lastname", "address", "email");
            contactHelper.FillContactForm(contact);
            contactHelper.SubmitContactForm();
            contactHelper.ReturnToHomePage();
            loginHelper.Logout();
        }
    }
}
