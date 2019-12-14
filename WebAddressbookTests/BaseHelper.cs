using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class BaseHelper
    {
        protected IWebDriver driver;
        public BaseHelper(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
