using NUnit.Framework;

namespace WebAddressbookTests.tests.GroupTests
{
    [TestFixture]
    class GroupCreationTests : BaseTest
    {

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("name")
            {
                Header = "Header",
                Footer = "Footer"
            };
            app.Groups.Create(group);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("")
            {
                Header = "",
                Footer = ""
            };
            app.Groups.Create(group);
        }
    }
}