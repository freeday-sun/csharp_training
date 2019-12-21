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

        [OneTimeSetUpAttribute]
        public void InitApplicationManager()
        {
            ApplicationManager app = ApplicationManager.GetInstance();
            app.Navigator.GoToMainPage();
            app.Auth.FillLoginForm(new AccountData("admin", "secret"));
            app.Auth.ConfirmLogin();
        }

        [OneTimeTearDownAttribute]
        public void StopApplicationManager()
        {
            ApplicationManager.GetInstance().Auth.Logout();
            ApplicationManager.GetInstance().StopBrowser();
        }
    }
}
