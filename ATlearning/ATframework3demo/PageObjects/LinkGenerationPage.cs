using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace atFrameWork2.PageObjects
{
    public class LinkGenerationPage
    {
        public LinkGenerationPage CreateShortLink(string shortLinkName, string linkPath)
        {
            var shortLink = new WebItem($"//div[div[div[contains(text(), '{shortLinkName}')]]]/div[@name = 'link-short-path']", "Интересующая короткая ссылка");
            if (shortLink.WaitElementDisplayed())
            {
                Log.Info("Такая короткая ссылка уже существует!");
                return new LinkGenerationPage();
            }
            else
            {
                var fieldShortLinkName = new WebItem("//input[@name = 'tag']", "Поле ввода 'Введите название'");
                fieldShortLinkName.SendKeys(shortLinkName);

                var fieldLinkPath = new WebItem("//input[@name = 'url']", "Поле ввода 'Введите ссылку'");
                fieldLinkPath.SendKeys(linkPath);

                var btnCreateShortLink = new WebItem("//input[@name = 'submit']", "Кнопка создания короткой ссылки");
                btnCreateShortLink.Click();

                if (shortLink.WaitElementDisplayed())
                {
                    Log.Info("Короткая ссылка создана");
                }
                else
                {
                    Log.Error("Произошла ошибка при создании короткой ссылки");
                }

                return new LinkGenerationPage();
            }
        }

        public LinkGenerationPage OpenShortLink(string shortLinkName)
        {
            var shortLink = new WebItem($"//div[div[div[contains(text(), '{shortLinkName}')]]]/div[@name = 'link-short-path']", "Интересующая короткая ссылка");
            
            WebDriver webDriver = new ChromeDriver();
            webDriver.Url = shortLink.InnerText();
            
            Log.Info("Переход по короткой ссылке");
            
            webDriver.Quit();
            
            Log.Info("Закрытие окна короткой ссылки");
            
            return new LinkGenerationPage();
        }
        public BusinessLeftMenu LeftMenu => new BusinessLeftMenu();

    }
}