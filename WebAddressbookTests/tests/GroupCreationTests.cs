using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class GroupCreationTests : BaseTest
    {

        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.GoToMainPage();
            app.Auth.FillLoginForm(new AccountData("admin", "secret"));
            app.Auth.ConfirmLogin();
            app.Navigator.GoToGroupPage();
            app.Groups.CreateNewGroup();
            GroupData group = new GroupData("name")
            {
                Header = "Header",
                Footer = "Footer"
            };
            app.Groups.FillGroupForm(group);
            app.Groups.SubmitGroupForm();
            app.Groups.ReturnToGroupPage();
            app.Auth.Logout();
        }
    }
}