﻿using OpenQA.Selenium;
using System;

namespace WebAddressbookTests
{
    public class LoginHelper : BaseHelper
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account)) 
                {
                    return;
                }
                Logout();
            }
            FillLoginForm(account);
            ConfirmLogin();
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
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector("form[name=\"logout\"] b"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            
            return IsLoggedIn()
                && GetLoggetUsername() == account.Username;

        }

        public string GetLoggetUsername()
        {
            string accountName = driver.FindElement(By.CssSelector("form[name=\"logout\"] b")).Text;
            return accountName.Substring(1, accountName.Length - 2);
        }
    }
}
