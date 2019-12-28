using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests.tests.GroupTests
{
    [TestFixture]
    public class GroupModificationTests : AuthBaseTest
    {
        private readonly int GROUP_INDEX = 0;
        [Test]
        public void GroupModificationTest()
        {
            //prepare
            app.Groups.GroupsShouldNotBeEmpty();
            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            //action
            GroupData newGroupData = new GroupData("name2");
            app.Groups.Modify(newGroupData, GROUP_INDEX);

            //verification
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups[GROUP_INDEX].Name = newGroupData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
