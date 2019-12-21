using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        public static ApplicationManager app;

        [OneTimeSetUpAttribute]
        public void InitApplicationManager()
        {
            app = new ApplicationManager();
            app.Navigator.GoToMainPage();
            app.Auth.FillLoginForm(new AccountData("admin", "secret"));
            app.Auth.ConfirmLogin();
        }

        [OneTimeTearDownAttribute]
        public void StopApplicationManager()
        {
            app.Auth.Logout();
            app.StopBrowser();
        }
    }
}
