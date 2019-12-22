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
            if (driver.Url == baseURL + "addressbook" || driver.Url == baseURL + "addressbook/index.php")
            {
                return;
            }
            
            driver.Navigate().GoToUrl(baseURL + "addressbook");
        }

        public void ReturnToHomePageAfterWorkWithContact()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }

        public void ReturnToGroupPage()
        {
            bool NewGroupButton = IsElementPresent(By.CssSelector("input[name=\"new\"]"));
            bool EditGroupButton = IsElementPresent(By.CssSelector("input[name=\"edit\"]"));
            bool DeleteGroupButton = IsElementPresent(By.CssSelector("input[name=\"delete\"]"));

            if (driver.Url == baseURL + "addressbook/group.php"
                && NewGroupButton && EditGroupButton && DeleteGroupButton)
            {
                return;
            }
            
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public void GoToGroupPage()
        {
            bool NewGroupButton =  IsElementPresent(By.CssSelector("input[name=\"new\"]"));
            bool EditGroupButton = IsElementPresent(By.CssSelector("input[name=\"edit\"]"));
            bool DeleteGroupButton = IsElementPresent(By.CssSelector("input[name=\"delete\"]"));

            if (driver.Url == baseURL + "addressbook/group.php"
                && NewGroupButton && EditGroupButton && DeleteGroupButton)
            {
                return;
            }
            
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToAddContactPage()
        {
            bool ConfirmCreationContactButton = IsElementPresent(By.CssSelector("input[value=\"Enter\"]"));

            if (driver.Url == baseURL + "addressbook/edit.php"
               && ConfirmCreationContactButton)
            {
                return;
            }
            
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}
