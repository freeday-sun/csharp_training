﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class BaseTest
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
            app.Navigator.GoToMainPage();
            app.Auth.FillLoginForm(new AccountData("admin", "secret"));
            app.Auth.ConfirmLogin();
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Auth.Logout();
            app.StopBrowser();
        }
    }
}