using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigatorHelper : BaseHelper
    {
        private string baseURL;

        public NavigatorHelper(ApplicationManager manager, string baseURL) : base(manager)
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
