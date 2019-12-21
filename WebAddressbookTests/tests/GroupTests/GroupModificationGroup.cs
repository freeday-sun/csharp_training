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
            GroupData newGroupData = new GroupData("name1")
            {
                Header = null,
                Footer = null
            };
            app.Groups.Modify(newGroupData, GROUP_INDEX);
        }
    }
}
