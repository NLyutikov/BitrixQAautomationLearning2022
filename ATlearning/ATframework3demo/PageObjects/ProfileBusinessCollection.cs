using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;

namespace atFrameWork2.PageObjects
{
    public class ProfileBusinessCollection
    {
        public ProfileBusinessCollection AddNewBusiness(string businessName)
        {
            var checkBusinessName = new WebItem($"//div[contains(text(), '{businessName}')]", "Название сужествующего бизнеса");
            if (checkBusinessName.WaitElementDisplayed(1))
            {
                Log.Info("Такой бизнес уже существует!");

            }
            else
            {
                var writeBusinessName = new WebItem("//input[@class = 'field-input']", "Поле ввода 'Название бизнеса'");
                writeBusinessName.SendKeys(businessName);

                var addNewBusinessBtn = new WebItem("//button[@class = 'ui-btn ui-btn-success']", "Кнопка добавления бизнеса");
                addNewBusinessBtn.Click();

                if (checkBusinessName.WaitElementDisplayed(2))
                {
                    Log.Info("Бизнес успешно создан");
                }
                else
                {
                    Log.Error("При создании бизнеса произошла ошибка");
                }
            }

            return new ProfileBusinessCollection();
        }

        public BusinessPage OpenBusiness(string businessName)
        {
            var openBusinessBtn = new WebItem($"//div[contains(text(), '{businessName}')]/..//a[@class = 'ui-btn ui-btn-success']", "Выбор нужного бизнеса");
            if (openBusinessBtn.WaitElementDisplayed(2000))
            {
                Log.Info("Бизнес найден. Открываю...");

                openBusinessBtn.Click();
            }
            else
            {
                Log.Error("При поиске интересующего бизнеса, произошла ошибка");
            }
            return new BusinessPage();
        }
    }
}