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
            GroupData group = new GroupData("name")
            {
                Header = "Header",
                Footer = "Footer"
            };
            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            //action
            app.Groups.Create(group);

            //verification
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            //prepare
            GroupData group = new GroupData("");
            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            //action
            app.Groups.Create(group);

            //verification
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            //prepare
            GroupData group = new GroupData("w'a");
            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            //action
            app.Groups.Create(group);

            //verification
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}