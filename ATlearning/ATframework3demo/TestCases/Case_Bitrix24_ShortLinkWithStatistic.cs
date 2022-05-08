using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;

namespace ATframework3demo.TestCases
{
    public class Case_Bitrix24_ShortLinkWithStatistic : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Короткая ссылка: создание, переход, статистика", homePage => ShortLinkWhithStatistic(homePage)));
            return caseCollection;
        }

        private void ShortLinkWhithStatistic(ProjectHomePage homePage)
        {
            var nameShortLink = "Прогноз погоды";

            homePage
                .BusinessCollection
                .AddNewBusiness("Уточки")
                .OpenBusiness("Уточки")
                .LeftMenu
                .OpenLinkGeneration()
                .CreateShortLink(nameShortLink, "https://www.gismeteo.ru/weather-kaliningrad-4225/")
                .OpenShortLink(nameShortLink)
                .LeftMenu
                .OpenTransferStatistics()
                .TransferCheck(nameShortLink)
                ;
        }
    }
}