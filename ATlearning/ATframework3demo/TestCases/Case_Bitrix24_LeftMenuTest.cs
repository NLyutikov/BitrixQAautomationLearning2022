using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;

namespace ATframework3demo.TestCases
{
    public class Case_Bitrix24_LeftMenuTest : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Проверка переходов по левому меню", homePage => LeftMenuTest(homePage)));
            return caseCollection;
        }

        private void LeftMenuTest(ProjectHomePage homePage)
        {
            homePage
                .BusinessCollection
                .OpenBusiness("Уточки")
                .LeftMenu
                //.OpenVisitStatistics()
                //.LeftMenu
                .OpenTransferStatistics()
                .LeftMenu
                .OpenLabelGeneration()
                .LeftMenu
                .OpenLinkGeneration()
                .LeftMenu
                .OpenVisitStatistics()
                ;
                //Ввести название и нажить кнопку создать
        }
    }
}