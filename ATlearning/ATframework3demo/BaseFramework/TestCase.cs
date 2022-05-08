using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.BaseFramework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace atFrameWork2.BaseFramework
{
    public class TestCase
    {
#pragma warning disable CS8618 // свойство "RunningTestCase", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
        public static TestCase RunningTestCase { get; set; }
#pragma warning restore CS8618 // свойство "RunningTestCase", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.

#pragma warning disable CS8618 // свойство "CaseLogPath", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
        public TestCase(string title, Action<ProjectHomePage> body)
#pragma warning restore CS8618 // свойство "CaseLogPath", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Body = body ?? throw new ArgumentNullException(nameof(body));
            Node = new TestCaseTreeNode(title);
        }

        int logCounter = 0;

        public void Execute(PortalInfo testPortal, Action uiRefresher)
        {
            Status = TestCaseStatus.running;
            uiRefresher.Invoke();
            RunningTestCase = this;
            logCounter++;
            CaseLogPath = Path.Combine(Environment.CurrentDirectory, $"caselog{DateTime.Now:ddMMyyyyHHmmss}{logCounter}.html");
            Log.WriteHtmlHeader(CaseLogPath);
            uiRefresher.Invoke();

            try
            {
                Log.Info($"---------------Запуск кейса '{Title}'---------------");
                var portalLoginPage = new ProjectLoginPage(testPortal);
                var homePage = portalLoginPage.Login(testPortal.PortalAdmin);
                Body.Invoke(homePage);
            }
            catch (Exception e)
            {
                Log.Error($"Кейс не пройден, причина:{Environment.NewLine}{e}");
            }

            Log.Info($"---------------Кейс '{Title}' завершён---------------");

            try
            {
                if (WebItem._defaultDriver != default)
                {
                    WebItem.DefaultDriver.Quit();
#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
                    WebItem.DefaultDriver = default;
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
                }
            }
            catch (Exception) { }

            if(CaseLog.Any(x => x is LogMessageError))
                Status = TestCaseStatus.failed;
            else
                Status = TestCaseStatus.passed;

#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
            RunningTestCase = default;
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
            uiRefresher.Invoke();
        }

        public string Title { get; set; }
        Action<ProjectHomePage> Body { get; set; }
        public TestCaseTreeNode Node { get; set; }
        public string CaseLogPath { get; set; }
        public List<LogMessage> CaseLog { get; } = new List<LogMessage>();
        public TestCaseStatus Status { get; set; }
    }
}
