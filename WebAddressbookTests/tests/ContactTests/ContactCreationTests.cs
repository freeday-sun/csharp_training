using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace WebAddressbookTests.tests.ContactTests
{
    [TestFixture]
    public class ContactCreationTests : AuthBaseTest
    {
         public static string dir = TestContext.CurrentContext.TestDirectory
                                    .Replace("\\bin\\Debug", "\\data");

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {   Address = GenerateRandomString(100), 
                    Email = GenerateRandomString(100),
                    Telephone_home = GenerateRandomString(30)
                });
            }

            return contacts;
        }

        public static IEnumerable<ContactData> GetContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(dir + "\\contacts.csv");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                contacts.Add(new ContactData(parts[0], parts[1])
                {
                    Address = parts[2],
                    Email = parts[3],
                    Telephone_home = parts[4]
                });

            }
            return contacts;
        }

        public static IEnumerable<ContactData> GetContactDataFromXmlFile()
        {
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(dir + "\\contacts.xml"));
        }

        public static IEnumerable<ContactData> GetContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(dir + "\\contacts.json"));
        }

        [Test, TestCaseSource("GetContactDataFromXmlFile")]
        public void ContactCreationTest(ContactData contact)
        {
            //prepare
            List<ContactData> oldContacts = app.Contact.GetContactsList();

            //action
            app.Contact.Create(contact);

            //verification
            List<ContactData> newContacts = app.Contact.GetContactsList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
