using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;

namespace ATframework3demo.TestCases
{
    public class Case_Bitrix24_CRM : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Добавление контакта CRM", homePage => AddContactToCRM(homePage)));
            return caseCollection;
        }

        private void AddContactToCRM(PortalHomePage homePage)
        {
            //перейти во вкладку CRM
            //перейти в контакты
            //перейти к добавлению контакта
            homePage
                .LeftMenu
                .OpenCRM()
                .OpenContactsCRM()
                .OpenContactForm();
            //ввести имя
            //сохранить контакт
            //вернуться к списку контактов
            //проверить созданный контакт
        }
    }
}
