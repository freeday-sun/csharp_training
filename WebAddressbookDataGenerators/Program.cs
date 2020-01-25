using WebAddressbookTests;
using System.IO;
using System;

namespace WebAddressbookDataGenerators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            for (int i = 0; i < count; i++)
            {
                writer.WriteLine(String.Format("${0},{1},{2}",
                    BaseTest.GenerateRandomString(25),
                    BaseTest.GenerateRandomString(25),
                    BaseTest.GenerateRandomString(25)
                    ));
            }
            writer.Close();
        }
    }
}
