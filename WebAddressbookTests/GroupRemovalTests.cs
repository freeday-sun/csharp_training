using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class  GroupRemovalTests : BaseTest

    {

        [Test]
        public void TheRemoveGroupTest()
        {
            GoToMainPage();
            FillLoginForm(new AccountData("admin", "secret"));
            ConfirmLogin();
            GoToGroupPage();
            SelectGroup();
            DeleteGroup();
            ReturnToGroupPage();
            Logout();
        }
    }
}
