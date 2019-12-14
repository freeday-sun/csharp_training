using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class  GroupRemovalTests : BaseTest

    {

        [Test]
        public void TheRemoveGroupTest()
        {
            app.Groups.Remove(1);
        }
    }
}
