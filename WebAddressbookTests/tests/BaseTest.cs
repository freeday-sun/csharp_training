using NUnit.Framework;
using System;
using System.Text;

namespace WebAddressbookTests
{
    public class BaseTest
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random random = new Random();

        public static string GenerateRandomString(int len)
        {
            int l = Convert.ToInt32(random.NextDouble() * len);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(random.NextDouble() * 223)));
            }
            return builder.ToString();
        }
    }
}
