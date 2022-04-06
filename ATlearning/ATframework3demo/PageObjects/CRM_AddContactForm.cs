using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class CRM_AddContactForm
    {
        internal CRM_AddContactForm WriteNameToContactForm(string name)
        {
            var switchToAddContactFrame = new WebItem("//iframe[@class='side-panel-iframe']", "Переход на фрейм формы создания контакта");
            switchToAddContactFrame.SwitchToFrame();

            var fieldName = new WebItem("//input[@id='name_text']", "Поле ввода 'Имя'");
            fieldName.SendKeys(name);

            return new CRM_AddContactForm();
        }

        internal CRM_AddContactForm SaveNewContact()
        {
            var btnSaveContact = new WebItem("//button[@class='ui-btn ui-btn-success']", "Кнопка сохранить");
            btnSaveContact.Click();

            DriverActions.SwitchToDefaultContent();

            Thread.Sleep(2000);

            return new CRM_AddContactForm();
        }

        internal CRM_ContactsPage CloseContactForm()
        {
            var btnCloseContactForm = new WebItem("//div[@class='side-panel-label-icon side-panel-label-icon-close']", "Кнопка закрытия формы создания контакта");
            btnCloseContactForm.Click();
            
            return new CRM_ContactsPage();
        }
    }
}
