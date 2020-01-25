using WebAddressbookTests;
using System.IO;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace WebAddressbookDataGenerators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string fileFormat = args[2];
            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(BaseTest.GenerateRandomString(25))
                {
                    Header = BaseTest.GenerateRandomString(25),
                    Footer = BaseTest.GenerateRandomString(25)
                }
                );
            }

            if (fileFormat == "csv")
            {
                writeGroupsToCsv(groups, writer);
            }
            else if (fileFormat == "xml")
            {
                writeGroupsToXml(groups, writer);
            }
            else if (fileFormat == "json")
            {
                writeGroupsToJson(groups, writer);
            }
            else
            {
                System.Console.WriteLine("Incorrect file format {0}", fileFormat);
            }
            writer.Close();
        }

        static void writeGroupsToCsv(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},{1},{2}",
                    group.Name, group.Header, group.Footer)
                    );
            }
        }

        static void writeGroupsToXml(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupsToJson(List<GroupData> groups, StreamWriter writer)
        {

        }
    }
}
