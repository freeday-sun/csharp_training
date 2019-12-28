﻿using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests.tests.GroupTests
{
    [TestFixture]
    public class  GroupRemovalTests : AuthBaseTest

    {
        private readonly int GROUP_INDEX = 0;
        [Test]
        public void GroupRemovalTest()
        {
            //prepare
            app.Groups.GroupsShouldNotBeEmpty();
            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            //action
            app.Groups.Remove(GROUP_INDEX);

            //vetification
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.RemoveAt(GROUP_INDEX);
            Assert.AreEqual(oldGroups, newGroups);
        }
        [Test]
        public void AllGroupRemovalTest()
        {
            //prepare
            app.Groups.GroupsShouldNotBeEmpty();
            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            //action
            app.Groups.RemoveAll();

            //vetification
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            Assert.IsTrue(newGroups.Count == 0);
        }

    }
}
