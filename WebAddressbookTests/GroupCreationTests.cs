﻿using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    class GroupCreationTests : BaseTest
    {

        [Test]
        public void GroupCreationTest()
        {
            GoToMainPage();
            FillLoginForm(new AccountData("admin", "secret"));
            ConfirmLogin();
            GoToGroupPage();
            CreateNewGroup();
            GroupData group = new GroupData("name")
            {
                Header = "Header",
                Footer = "Footer"
            };
            FillGroupForm(group);
            SubmitGroupForm();
            ReturnToGroupPage();
            Logout();
        }
    }
}