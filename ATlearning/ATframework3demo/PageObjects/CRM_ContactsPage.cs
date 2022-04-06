using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class CRM_ContactsPage
    {
        internal CRM_AddContactForm OpenContactForm()
        {
            var btnAddContact = new WebItem("//a[@class='ui-btn ui-btn-primary ui-btn-icon-add crm-btn-toolbar-add']", "Кнопка добавления контакта");
            if (btnAddContact.WaitElementDisplayed())
            {
                Log.Info("Кнопка 'Добавить контакт' найдена");

                btnAddContact.Click();
            } else
            {
                Log.Error("Кнопка 'Добавить контакт' не найдена");
            }
            return new CRM_AddContactForm();
        }

        internal void IsContactCreatAndDeleteAll()
        {
            var createdContact = new WebItem("//tr[@class='main-grid-row main-grid-row-body']", "Созданный контакт");
            if (createdContact.WaitElementDisplayed())
            {
                Log.Info("Добавленный контакт отображается в списке контактов");

                var checkBoxSelectAll = new WebItem("//div[@class='main-grid-container']//input[@id='CRM_CONTACT_LIST_V12_check_all']", "Чекбокс 'Выбрать всё'");
                checkBoxSelectAll.Click();

                var btnDeleteSelectedContacts = new WebItem("//span[@id='grid_remove_button_control']", "Кнопка удаления выбранных контактов");
                btnDeleteSelectedContacts.Click();

                var btnAcceptDelete = new WebItem("//div[@id='crm_contact_list_v12_batch_delete']//span[@class='popup-window-button popup-window-button-accept']", "Кнопка подтверждения удаления контактов");
                btnAcceptDelete.Click();

                if (!createdContact.WaitElementDisplayed()) Log.Info("Контакт отобразился в списке. Отчистка успешна.");
            } else 
            {
                Log.Error("Контакт не отобразился");
            }            

        }

    }
}
