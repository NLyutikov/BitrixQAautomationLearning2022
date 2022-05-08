using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;

namespace ATframework3demo.TestCases
{
    public class Case_Bitrix24_AddNewBusiness : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Добавление нового бизнеса", homePage => AddNewBusiness(homePage)));
            return caseCollection;
        }

        private void AddNewBusiness(ProjectHomePage homePage)
        {
            var businessName = "Кошечки";

            homePage
                .BusinessCollection
                .AddNewBusiness(businessName)
                .OpenBusiness(businessName)
                ;
        }
    }
}