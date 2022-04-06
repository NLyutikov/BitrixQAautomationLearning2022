using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class CRM_Page
    {
        internal CRM_ContactsPage OpenContactsCRM()
        {
            var btnContactsCRM = new WebItem("//div[@id='crm_control_panel_menu_menu_crm_contact']", "Переход во вкладку Контакты");
            btnContactsCRM.Click();

            return new CRM_ContactsPage();
        }
    }
}
