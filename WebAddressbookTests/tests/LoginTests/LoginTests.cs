﻿using NUnit.Framework;

namespace WebAddressbookTests.tests.LoginTests
{
    [TestFixture]
    public class LoginTests : BaseTest
    {
        [Test]
        public void LoginWithValidCredentionals()
        {
            // prepare
            app.Auth.Logout();

            // action
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);


            //verification
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentionals()
        {
            // prepare
            app.Auth.Logout();

            // action
            AccountData account = new AccountData("admin", "123");
            app.Auth.Login(account);


            //verification
            System.Threading.Thread.Sleep(1000); // redirect to the main page does not have time to work
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }

    }
}
