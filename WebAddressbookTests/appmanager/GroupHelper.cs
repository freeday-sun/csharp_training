using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class GroupHelper : BaseHelper
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group) 
        {
            manager.Navigator.GoToGroupPage();
            InitNewGroup();
            FillGroupForm(group);
            SubmitGroupForm();
            ReturnToGroupPage();
            return this;
        }


        public GroupHelper Remove(int index)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(index);
            DeleteGroup();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Modify(GroupData group, int index)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(index);
            InitModificateGroup();
            FillGroupForm(group);
            SubmitModificationGroup();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SubmitGroupForm()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            FillField(By.Name("group_name"), group.Name);
            FillField(By.Name("group_header"), group.Header);
            FillField(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper InitNewGroup()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper InitModificateGroup()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SubmitModificationGroup()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
    }
}
