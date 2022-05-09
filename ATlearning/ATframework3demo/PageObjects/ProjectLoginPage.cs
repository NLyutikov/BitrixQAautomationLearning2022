using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace atFrameWork2.PageObjects
{
    class ProjectLoginPage
    {
        PortalInfo portalInfo;

        public ProjectLoginPage(PortalInfo portal)
        {
            portalInfo = portal;
        }

        public ProjectHomePage Login(User admin)
        {
            DriverActions.OpenUri(portalInfo.PortalUri);
            var loginField = new WebItem("//input[@id='login']", "Поле для ввода логина");
            var pwdField = new WebItem("//input[@id='password']", "Поле для ввода пароля");
            loginField.SendKeys(admin.Login);
            //Thread.Sleep(2000);
            //loginField.SendKeys(Keys.Enter);
            pwdField.SendKeys(admin.Password, logInputtedText: false);
            Thread.Sleep(2000);
            pwdField.SendKeys(Keys.Enter);
            return new ProjectHomePage();
        }
    }
}
