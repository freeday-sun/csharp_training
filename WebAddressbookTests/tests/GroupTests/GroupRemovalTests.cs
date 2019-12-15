using NUnit.Framework;

namespace WebAddressbookTests.tests.GroupTests
{
    [TestFixture]
    public class  GroupRemovalTests : BaseTest

    {
        private readonly int GROUP_INDEX = 1;
        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.Remove(GROUP_INDEX);
        }
    }
}
