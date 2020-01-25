using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace WebAddressbookTests.tests.GroupTests
{
    [TestFixture]
    class GroupCreationTests : AuthBaseTest
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < 5; i++)
            {
                groups.Add( new GroupData(GenerateRandomString(30) )
                {Header = GenerateRandomString(100), Footer= GenerateRandomString(100) } );
            }

            return groups;
        }

        public static IEnumerable<GroupData> GetGroupDataFromFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"D:\Courses\DotNet\csharp_training\WebAddressbookTests\data\groups.csv");
            foreach (string line in lines)
            {
                string[] parts =  line.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1], Footer = parts[2]
                });

            }
            return groups;
        }

        [Test, TestCaseSource("GetGroupDataFromFile")]
        public void GroupCreationTest(GroupData group)
        {
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