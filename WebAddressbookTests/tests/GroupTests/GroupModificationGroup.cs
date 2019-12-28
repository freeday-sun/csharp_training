using NUnit.Framework;

namespace WebAddressbookTests.tests.GroupTests
{
    [TestFixture]
    public class GroupModificationTests : AuthBaseTest
    {
        private readonly int GROUP_INDEX = 1;
        [Test]
        public void GroupModificationTest()
        {
            //prepare
            app.Groups.GroupsShouldNotBeEmpty();

            //action
            GroupData newGroupData = new GroupData("name2");
            app.Groups.Modify(newGroupData, GROUP_INDEX);

            //verification
            //so far without verification
        }
    }
}
