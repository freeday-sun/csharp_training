using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : BaseTest
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newDataInGroup = new GroupData("name1")
            {
                Header = "Header1",
                Footer = "Footer1"
            };
            app.Groups.Modify(newDataInGroup, 1);
        }
    }
}
