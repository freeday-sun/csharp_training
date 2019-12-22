using NUnit.Framework;

namespace WebAddressbookTests.tests.GroupTests
{
    [TestFixture]
    class GroupCreationTests : AuthBaseTest
    {

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("name", "Header", "Footer");
            app.Groups.Create(group);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("", "", "");
            app.Groups.Create(group);
        }
    }
}