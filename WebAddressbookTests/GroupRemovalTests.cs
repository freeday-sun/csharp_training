using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class  GroupRemovalTests : BaseTest

    {

        [Test]
        public void TheRemoveGroupTest()
        {
            navigatorHelper.GoToMainPage();
            loginHelper.FillLoginForm(new AccountData("admin", "secret"));
            loginHelper.ConfirmLogin();
            navigatorHelper.GoToGroupPage();
            groupHelper.SelectGroup(1);
            groupHelper.DeleteGroup();
            groupHelper.ReturnToGroupPage();
            loginHelper.Logout();
        }
    }
}
