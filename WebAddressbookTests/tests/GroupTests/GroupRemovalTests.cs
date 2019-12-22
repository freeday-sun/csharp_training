using NUnit.Framework;

namespace WebAddressbookTests.tests.GroupTests
{
    [TestFixture]
    public class  GroupRemovalTests : AuthBaseTest

    {
        private readonly int GROUP_INDEX = 1;
        [Test]
        public void GroupRemovalTest()
        {
            //prepare
            app.Groups.GroupsShouldNotBeEmpty();

            //action
            app.Groups.Remove(GROUP_INDEX);

            //vetification
            //so far without verification
        }

    }
}
