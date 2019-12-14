using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class BaseHelper
    {
        protected ApplicationManager manager;
        protected IWebDriver driver;
        public BaseHelper(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }
    }
}
