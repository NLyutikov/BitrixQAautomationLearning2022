using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;

namespace ATframework3demo.TestCases
{
    public class Case_Bitrix24_CreateShortLink : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Создание короткой ссылки", homePage => CreateShortLink(homePage)));
            return caseCollection;
        }

        private void CreateShortLink(ProjectHomePage homePage)
        {
            homePage
                .BusinessCollection
                .OpenBusiness("Уточки")
                .LeftMenu
                .OpenLinkGeneration()
                .CreateShortLink("Услуги УтБосса", "https://2ip.ru/")
                ;
        }
    }
}