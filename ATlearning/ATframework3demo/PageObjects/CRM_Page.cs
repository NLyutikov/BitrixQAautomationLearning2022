using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class CRM_Page
    {
        internal CRM_ContactsPage OpenContactsCRM()
        {
            var btnContactsCRM = new WebItem("//div[@id='crm_control_panel_menu_menu_crm_contact']", "Переход во вкладку Контакты");

            if (btnContactsCRM.WaitElementDisplayed())
            {
                Log.Info("Вкладка 'Контакты' найдена");

                btnContactsCRM.Click();
            } else
            {
                Log.Error("Вкладка 'Контакты' не найдена");
            }

            return new CRM_ContactsPage();
        }
    }
}
