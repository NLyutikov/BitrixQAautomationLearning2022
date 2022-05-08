using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;

namespace ATframework3demo.TestCases
{
    public class Case_Bitrix24_OpenBusiness : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Открытие нужного бизнеса", homePage => OpenBusiness(homePage)));
            return caseCollection;
        }

        private void OpenBusiness(ProjectHomePage homePage)
        {
            homePage
                .BusinessCollection
                .OpenBusiness("Бизнес: Кошечки");
        }
    }
}
