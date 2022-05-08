using atFrameWork2.SeleniumFramework;

namespace atFrameWork2.PageObjects
{
    public class BusinessLeftMenu
    {
        public VisitStatisticsPage OpenVisitStatistics()
        {
            var btnVisitStatistics = new WebItem("//ul[@class = 'left-menu']//a[contains(text(), 'Статистика посещений')]", "Переход на страницу 'Статистика посещений'");
            btnVisitStatistics.Click();
            return new VisitStatisticsPage();
        }

        public TransferStatisticsPage OpenTransferStatistics()
        {
            var btnTransferStatistics = new WebItem("//ul[@class = 'left-menu']//a[contains(text(), 'Статистика переходов')]", "Переход на страницу 'Статистика переходов'");
            btnTransferStatistics.Click();
            return new TransferStatisticsPage();
        }

        public LabelGenerationPage OpenLabelGeneration()
        {
            var btnLabelGeneration = new WebItem("//ul[@class = 'left-menu']//a[contains(text(), 'Генерация меток')]", "Переход на страницу 'Генерация меток'");
            btnLabelGeneration.Click();
            return new LabelGenerationPage();
        }

        public LinkGenerationPage OpenLinkGeneration()
        {
            var btnLinkGeneration = new WebItem("//ul[@class = 'left-menu']//a[contains(text(), 'Генерация ссылок')]", "Переход на страницу 'Генерация ссылок'");
            btnLinkGeneration.Click();
            return new LinkGenerationPage();
        }
    }
}