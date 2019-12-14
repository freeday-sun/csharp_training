using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigatorHelper : BaseHelper
    {
        private readonly string baseURL;

        public NavigatorHelper(IWebDriver driver, string baseURL) : base(driver)
        {
            this.baseURL = baseURL;
        }

        public void GoToMainPage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook");
        }

        public void ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public void GoToGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToAddContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}
