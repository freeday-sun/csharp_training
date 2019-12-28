using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests.tests.GroupTests
{
    [TestFixture]
    class GroupCreationTests : AuthBaseTest
    {

        [Test]
        public void GroupCreationTest()
        {   //prepare
            GroupData group = new GroupData("name", "Header", "Footer");
            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            //action
            app.Groups.Create(group);

            //verification
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            //prepare
            GroupData group = new GroupData("", "", "");
            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            //action
            app.Groups.Create(group);

            //verification
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
    }
}