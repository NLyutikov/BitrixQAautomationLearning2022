using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class CRM_ContactsPage
    {
        internal CRM_AddContactForm OpenContactForm()
        {
            var btnAddContact = new WebItem("//a[@class='ui-btn ui-btn-primary ui-btn-icon-add crm-btn-toolbar-add']", "Кнопка добавления контакта");
            btnAddContact.Click();
            return new CRM_AddContactForm();
        }
    }
}
