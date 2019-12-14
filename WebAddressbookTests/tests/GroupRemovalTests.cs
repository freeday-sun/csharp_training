using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class  GroupRemovalTests : BaseTest

    {

        [Test]
        public void TheRemoveGroupTest()
        {
            app.Navigator.GoToMainPage();
            app.Auth.FillLoginForm(new AccountData("admin", "secret"));
            app.Auth.ConfirmLogin();
            app.Navigator.GoToGroupPage();
            app.Groups.SelectGroup(1);
            app.Groups.DeleteGroup();
            app.Groups.ReturnToGroupPage();
            app.Auth.Logout();
        }
    }
}
