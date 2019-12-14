using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddContactTests : BaseTest
    {

        [Test]
        public void AddContactTest()
        {
            app.Navigator.GoToMainPage();
            app.Auth.FillLoginForm(new AccountData("admin", "secret"));
            app.Auth.ConfirmLogin();
            app.Navigator.GoToAddContactPage();
            ContactData contact = new ContactData("firstname", "lastname", "address", "email");
            app.Contact.FillContactForm(contact);
            app.Contact.SubmitContactForm();
            app.Contact.ReturnToHomePage();
            app.Auth.Logout();
        }
    }
}
