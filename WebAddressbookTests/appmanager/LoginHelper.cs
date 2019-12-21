using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class LoginHelper : BaseHelper
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void FillLoginForm(AccountData account)
        {
            FillField(By.Name("user"), account.Username);
            FillField(By.Name("pass"), account.Password);
        }

        public void ConfirmLogin()
        {
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
