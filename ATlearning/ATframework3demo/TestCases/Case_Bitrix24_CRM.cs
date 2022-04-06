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
            homePage
                .LeftMenu
                .OpenCRM()                     //перейти во вкладку CRM
                .OpenContactsCRM()             //перейти в контакты
                .OpenContactForm()             //перейти к добавлению контакта
                .WriteNameToContactForm()      //ввести имя
                .SaveNewContact()              //сохранить контакт
                .CloseContactForm()            //Закрыть контактную форму
                .IsContactCreatAndDeleteAll(); //Проверка созданного контакта и его удаление
        }
    }
}
