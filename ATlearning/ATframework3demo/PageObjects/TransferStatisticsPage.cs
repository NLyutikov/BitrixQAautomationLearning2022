using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;

namespace atFrameWork2.PageObjects
{
    public class TransferStatisticsPage
    {
        public TransferStatisticsPage TransferCheck(string nameShortLink)
        {
            var nameShortLinkInTransferList = new WebItem($"//tr[td[div[span[a[contains(text(), '{nameShortLink}')]]]]]", "Название короткой ссылки в списке переходов");
            if (nameShortLinkInTransferList.WaitElementDisplayed())
            {
                Log.Info("Переход, по созданной короткой ссылке, успешно отобразился в списке переходов");
            }
            else
            {
                Log.Error("Переход, по созданной короткой ссылке, не обнаружен в списке переходов");
            }
            return new TransferStatisticsPage();
        }
        public BusinessLeftMenu LeftMenu => new BusinessLeftMenu();

    }
}