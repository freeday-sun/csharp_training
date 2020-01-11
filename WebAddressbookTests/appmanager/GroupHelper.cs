using OpenQA.Selenium;
using System;
using System.Collections.Generic;

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
            manager.Navigator.ReturnToGroupPage();
            return this;
        }

        public GroupHelper Remove(int index)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(index);
            SubmitDeleteGroup();
            manager.Navigator.ReturnToGroupPage();
            return this;
        }

        public GroupHelper RemoveAll()
        {
            manager.Navigator.GoToGroupPage();
            SelectAllGroups();
            SubmitDeleteGroup();
            manager.Navigator.ReturnToGroupPage();
            return this;
        }

        public GroupHelper Modify(GroupData group, int index)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(index);
            InitModificateGroup();
            FillGroupForm(group);
            SubmitModificationGroup();
            manager.Navigator.ReturnToGroupPage();
            return this;
        }

        public void GroupsShouldNotBeEmpty()
        {
            manager.Navigator.GoToGroupPage();
            if (GroupsListIsEmpty())
            {
                manager.Groups.Create(new GroupData("name1"));
            }
        }

        private bool GroupsListIsEmpty()
        {
            bool GroupTableRows = IsElementPresent(By.XPath("//span"));

            if (!GroupTableRows) 
            {
                return true;
            }
            return false;
        }

        public List<GroupData> GetGroupsList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }

            return groups;

        }

        public void SelectAllGroups()
        {
            try
            {
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group input"));
                foreach (IWebElement element in elements)
                {
                    element.Click();
                }
            }
            catch(Exception)
            {
                return;
            }
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
            driver.FindElements(By.CssSelector("span.group"))[index] // groups rows in table
            .FindElement(By.TagName("input")).Click(); // edit button index in row in table
            return this;
        }

        public GroupHelper SubmitDeleteGroup()
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
