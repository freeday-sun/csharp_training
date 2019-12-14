using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class GroupCreationTests : BaseTest
    {

        [Test]
        public void GroupCreationTest()
        {
            navigatorHelper.GoToMainPage();
            loginHelper.FillLoginForm(new AccountData("admin", "secret"));
            loginHelper.ConfirmLogin();
            navigatorHelper.GoToGroupPage();
            groupHelper.CreateNewGroup();
            GroupData group = new GroupData("name")
            {
                Header = "Header",
                Footer = "Footer"
            };
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitGroupForm();
            groupHelper.ReturnToGroupPage();
            loginHelper.Logout();
        }
    }
}