﻿using NUnit.Framework;

namespace WebAddressbookTests.tests.GroupTests
{
    [TestFixture]
    public class GroupModificationTests : BaseTest
    {
        private readonly int GROUP_INDEX = 1;
        [Test]
        public void GroupModificationTest()
        {
            GroupData newGroupData = new GroupData("name1")
            {
                Header = "Header1",
                Footer = "Footer1"
            };
            app.Groups.Modify(newGroupData, GROUP_INDEX);
        }
    }
}