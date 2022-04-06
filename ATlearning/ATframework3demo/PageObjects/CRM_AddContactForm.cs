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

            if (fieldName.WaitElementDisplayed())
            {
                Log.Info("Поле ввода 'Имя', в фрейме, найдено");

                fieldName.SendKeys(name);
            } else
            {
                Log.Error("Поле ввода 'Имя', в фрейме, не найдено");
            }

            return new CRM_AddContactForm();
        }

        internal CRM_AddContactForm SaveNewContact()
        {
            var btnSaveContact = new WebItem("//button[@class='ui-btn ui-btn-success']", "Кнопка сохранить");

            if (btnSaveContact.WaitElementDisplayed())
            {
                Log.Info("Кнопка 'Сохранить', в фрейме, найдена");

                btnSaveContact.Click();
            }
            else
            {
                Log.Error("Кнопка 'Сохранить', в фрейме, не найдена");
            }

            DriverActions.SwitchToDefaultContent();

            Thread.Sleep(2000);

            return new CRM_AddContactForm();
        }

        internal CRM_ContactsPage CloseContactForm()
        {
            var btnCloseContactForm = new WebItem("//div[@class='side-panel-label-icon side-panel-label-icon-close']", "Кнопка закрытия формы создания контакта");
            
            if (btnCloseContactForm.WaitElementDisplayed())
            {
                Log.Info("Кнопка 'Закрыть' найдена");

                btnCloseContactForm.Click();
            }
            else
            {
                Log.Error("Кнопка 'Закрыть' не найдена");
            }
            
            return new CRM_ContactsPage();
        }
    }
}
