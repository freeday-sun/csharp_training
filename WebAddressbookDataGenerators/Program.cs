using WebAddressbookTests;
using System.IO;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Json = Newtonsoft.Json;

namespace WebAddressbookDataGenerators
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataFormat = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string fileFormat = args[3];

            if (dataFormat == "group")
            {
                List<GroupData> groups = GenerateGroupsData(count);

                if (fileFormat == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                }
                else if (fileFormat == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else if (fileFormat == "json")
                {
                    writeGroupsToJsonFile(groups, writer);
                }
                else
                {
                    System.Console.WriteLine("Incorrect file format {0}", fileFormat);
                }
            }
            else if (dataFormat == "contacts")
            {
                List<ContactData> contacts = GenerateContactsData(count);
                if (fileFormat == "csv")
                {
                    writeContactsToCsvFile(contacts, writer);
                }
                else if (fileFormat == "xml")
                {
                    writeContactsToXmlFile(contacts, writer);
                }
                else if (fileFormat == "json")
                {
                    writeContactsToJsonFile(contacts, writer);
                }
                else
                {
                    System.Console.WriteLine("Incorrect file format {0}", fileFormat);
                }
            }
            writer.Close();
        }

        private static List<ContactData> GenerateContactsData(int count)
        {
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(BaseTest.GenerateRandomString(25),
                                             BaseTest.GenerateRandomString(25))
                {
                    Address = BaseTest.GenerateRandomString(25),
                    Email = BaseTest.GenerateRandomString(25),
                    Telephone_home = BaseTest.GenerateRandomString(25)
                }
                );
            }

            return contacts;
        }

        private static List<GroupData> GenerateGroupsData(int count)
        {
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

            return groups;
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},{1},{2}",
                    group.Name, group.Header, group.Footer)
                    );
            }
        }

        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},{1},{2},{3},{4}",
                    contact.Firstname, contact.Lastname, contact.Address, contact.Email, contact.Telephone_home)
                    );
            }
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(Json.JsonConvert.SerializeObject(groups, Json.Formatting.Indented));
        }

        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(Json.JsonConvert.SerializeObject(contacts, Json.Formatting.Indented));
        }
    }
}
