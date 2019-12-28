using NUnit.Framework;

namespace WebAddressbookTests.tests
{
    public class AuthBaseTest : BaseTest
    {
        [SetUp]
        public void SetupLogin()
        {
            app.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
