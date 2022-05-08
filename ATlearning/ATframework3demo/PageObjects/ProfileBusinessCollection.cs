using atFrameWork2.SeleniumFramework;

namespace atFrameWork2.PageObjects
{
    public class ProfileBusinessCollection
    {
        public ProfileBusinessCollection AddNewBusiness(string businessName)
        {
            var writeBusinessName = new WebItem("//input[@class = 'field-input']", "Поле ввода 'Название бизнеса'");
            writeBusinessName.SendKeys(businessName);
            var addNewBusinessBtn = new WebItem("//button[@class = 'ui-btn ui-btn-success']", "Кнопка добавления бизнеса");
            addNewBusinessBtn.Click();
            return new ProfileBusinessCollection(); 
        }

        public BusinessPage OpenBusiness(string businessName)
        {
            var openBusinessBtn = new WebItem($"//div[contains(text(), '{businessName}')]/..//a[@class = 'ui-btn ui-btn-success']", "Выбор нужного бизнеса");
            openBusinessBtn.WaitElementDisplayed(2000);
            openBusinessBtn.Click();
            return new BusinessPage();
        }
    }
}