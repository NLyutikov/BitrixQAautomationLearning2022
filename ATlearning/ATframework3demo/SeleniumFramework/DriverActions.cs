using atFrameWork2.BaseFramework.LogTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace atFrameWork2.SeleniumFramework
{
    class DriverActions
    {
        public static IWebDriver GetNewDriver()
        {
            IWebDriver driver;
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }

#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        public static void Refresh(IWebDriver driver = default)
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        {
            Log.Info($"{nameof(Refresh)}");
            driver ??= WebItem.DefaultDriver;
            driver.Navigate().Refresh();
        }

#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        public static void OpenUri(Uri uri, IWebDriver driver = default)
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        {
            Log.Info($"{nameof(OpenUri)}: {uri}");
            driver ??= WebItem.DefaultDriver;
            driver.Navigate().GoToUrl(uri);
        }

#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        public static void SwitchToDefaultContent(IWebDriver driver = default)
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        {
            Log.Info($"{nameof(SwitchToDefaultContent)}");
            driver ??= WebItem.DefaultDriver;
            driver.SwitchTo().DefaultContent();
        }
    }
}
