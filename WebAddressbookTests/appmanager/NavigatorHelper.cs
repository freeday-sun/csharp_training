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
            if (driver.Url == baseURL + "addressbook")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "addressbook");
        }

        public void ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public void GoToGroupPage()
        {
            bool NewGroupButton =  IsElementPresent(By.CssSelector("input[name=\"new\"]"));
            bool EditGroupButton = IsElementPresent(By.CssSelector("input[name=\"edit\"]"));
            bool DeleteGroupButton = IsElementPresent(By.CssSelector("input[name=\"new\"]"));

            if (driver.Url == baseURL + "addressbook/group.php"
                && NewGroupButton && EditGroupButton && DeleteGroupButton)
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToAddContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}
