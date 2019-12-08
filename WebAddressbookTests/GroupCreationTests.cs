using NUnit.Framework;
using OpenQA.Selenium;



namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : BaseTest
    {

        [Test]
        public void GroupCreationTest()
        {
            GoToMainPage();
            FillLoginForm(new AccountData("admin", "secret"));
            ConfirmLogin();
            GoToGroupPage();
            GroupData group = new GroupData("name");
            group.Header = "Header";
            group.Footer = "Footer";
            FillGroupForm(group);
            SubmitGroupForm();
            ReturnToGroupPageAfterAddGroup();
            LogoutFromGroupPage();
        }
        private void LogoutFromGroupPage()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void ReturnToGroupPageAfterAddGroup()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        private void SubmitGroupForm()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        private void FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }

        private void GoToGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            driver.FindElement(By.Name("new")).Click();
        }
    }
}