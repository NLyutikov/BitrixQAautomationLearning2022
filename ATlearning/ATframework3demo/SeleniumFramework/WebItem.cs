using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using ATframework3demo.BaseFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace atFrameWork2.SeleniumFramework
{
    class WebItem
    {
#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        public static IWebDriver _defaultDriver = default;
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        public static IWebDriver DefaultDriver
        {
            get
            {
                if (_defaultDriver == default)
                    _defaultDriver = DriverActions.GetNewDriver();
                return _defaultDriver;
            }

            set => _defaultDriver = value;
        }

        List<string> XPathLocators { get; set; } = new List<string>();
        public string Description { get; set; }
        public string DescriptionFull { get => $"'{Description}' локаторы: {string.Join(", ", XPathLocators)}"; }

        public WebItem(string xpathLocator, string description) : this(new List<string> { xpathLocator }, description)
        {
        }

        public WebItem(List<string> xpathLocators, string description)
        {
            XPathLocators = xpathLocators;
            Description = description;
        }

#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        public void Click(IWebDriver driver = default)
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        {
            WaitElementDisplayed(driver: driver);
            PrintActionInfo(nameof(Click));

            Execute((button, drv) =>
            {
                button.Click();
            }, driver);
        }

#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        public void SendKeys(string textToInput, IWebDriver driver = default, bool logInputtedText = true)
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        {
            WaitElementDisplayed(driver: driver);
            string textToLog = $"'{textToInput}'";
            if (!logInputtedText)
                textToLog = "[логирование отключено]";
            PrintActionInfo($"Ввод текста {textToLog} в элемент");

            Execute((input, drv) =>
            {
                input.SendKeys(textToInput);
            }, driver);
        }

#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        public void SwitchToFrame(IWebDriver driver = default)
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        {
            PrintActionInfo(nameof(SwitchToFrame));
            Execute((frame, drv) =>
            {
                drv.SwitchTo().Frame(frame);
            }, driver);
        }

#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        public void SelectListItemByText(string listItemToSelect, IWebDriver driver = default)
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        {
            WaitElementDisplayed(driver: driver);
            PrintActionInfo($"Выбор пункта списка '{listItemToSelect}' в списке");

            Execute((select, drv) =>
            {
                var selEl = new SelectElement(select);
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                string itemToSelectResultText = default;
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                bool optionExists = selEl.Options.ToList().Find(x => x.Text == listItemToSelect) != null;

                if (!optionExists)
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                    itemToSelectResultText = selEl.Options.ToList().Find(x => x.Text.Contains(listItemToSelect))?.Text;
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                else
                    itemToSelectResultText = listItemToSelect;

                if (itemToSelectResultText != null)
                    selEl.SelectByText(itemToSelectResultText);
                else
                    throw new Exception($"Пункт списка '{listItemToSelect}' не найден в списке {DescriptionFull}");
            }, driver);
        }

#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        public bool Checked(IWebDriver driver = default)
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        {
            WaitElementDisplayed(driver: driver);
            bool isChecked = false;

            Execute((checkBox, drv) =>
            {
                isChecked = checkBox.Selected;
            }, driver);

            PrintActionInfo($"Чекбокс {(isChecked ? "отмечен" : "снят")}. Элемент");
            return isChecked;
        }

#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        public string GetAttribute(string attributeName, IWebDriver driver = default)
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        {
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
            string resultAttrValue = default;
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.

            Execute((el, drv) =>
            {
                resultAttrValue = el.GetAttribute(attributeName);
            }, driver);

            PrintActionInfo($"Значение аттрибута {attributeName}='{resultAttrValue}'. Элемент");
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return resultAttrValue;
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expectedText"></param>
        /// <param name="failMessage"></param>
        /// <param name="driver"></param>
        /// <returns>true if expectedText present at element's innerText</returns>
#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        public bool AssertTextContains(string expectedText, string failMessage, IWebDriver driver = default)
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        {
            PrintActionInfo(nameof(AssertTextContains));
            bool result = false;

            Execute((targetElement, drv) =>
            {
                string factText = targetElement.Text;
                result = !(string.IsNullOrEmpty(factText) || !factText.Contains(expectedText));
            }, driver);

            return result;
        }

#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        public string InnerText(IWebDriver driver = default)
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        {
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
            string elementText = default;
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.

            Execute((targetElement, drv) =>
            {
                elementText = targetElement.Text;
            }, driver);

            PrintActionInfo($"Получен текст '{elementText}'. Элемент");
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return elementText;
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }

#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        public bool WaitElementDisplayed(int maxWait_s = 5, IWebDriver driver = default)
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        {
            return WaitDisplayedCommon(driver, maxWait_s, true, "Ожидание отображения элемента " + DescriptionFull);
        }

#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        public bool WaitWhileElementDisplayed(int maxWait_s = 5, IWebDriver driver = default)
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        {
            return WaitDisplayedCommon(driver, maxWait_s, false, "Ожидание пропадания элемента " + DescriptionFull);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="maxWait_s"></param>
        /// <param name="waitDirection">Если true то будет ждать пока элемент не станет отображаться, иначе будет ждать пока элемент отображается</param>
        /// <param name="waitDescription"></param>
        /// <returns></returns>
        bool WaitDisplayedCommon(IWebDriver driver, int maxWait_s, bool waitDirection, string waitDescription)
        {
            driver ??= DefaultDriver;
            var impWait = driver.Manage().Timeouts().ImplicitWait;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

            bool result = Waiters.WaitForCondition(() =>
            {
                bool expectedState = false;

                Execute((el, drv) =>
                {
                    expectedState = el.Displayed == waitDirection;
                }, driver, true);

                return expectedState;
            }, 1, maxWait_s, waitDescription);

            driver.Manage().Timeouts().ImplicitWait = impWait;
            return result;
        }

        void Execute(Action<IWebElement, IWebDriver> seleniumCode, IWebDriver driver, bool throwAtDebug = false)
        {
            driver ??= DefaultDriver;

            try
            {
                foreach (var locator in XPathLocators)
                {
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                    IWebElement targetElement = default;
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                    int staleRetryCount = 3;
                    bool interceptedHandlerFirstTry = true;

                    for (int i = 0; i < staleRetryCount; i++)
                    {
                        try
                        {
                            targetElement = driver.FindElement(By.XPath(locator));
                            seleniumCode.Invoke(targetElement, driver);
                            break;
                        }
                        catch (WebDriverException ex)
                        {
                            if (ex is NoSuchElementException)
                            {
                                if (locator == XPathLocators.Last())
                                    throw;
                            }
                            else if (ex is StaleElementReferenceException)
                            {
                                if (i == staleRetryCount - 1)
                                    throw;
                                Thread.Sleep(2000);
                                continue;
                            }
                            else if (ex is ElementClickInterceptedException)
                            {
                                if (ex.Message.Contains("helpdesk-notification-popup"))
                                {
                                    new WebItem("//div[contains(@class, 'popup-close-btn')]", "Кнопка закрытия баннера").Click(driver);
                                    if (interceptedHandlerFirstTry)
                                        i++;
                                    interceptedHandlerFirstTry = false;
                                    continue;
                                }
                                else
                                    throw;
                            }
                            else
                                throw;
                        }

                        break;
                    }

                    if (targetElement != default)
                        break;
                }
            }
            catch (Exception e)
            {
                if(throwAtDebug || !EnvironmentSettings.IsDebug)
                    throw;
                Debug.Fail(e.ToString());
            }
        }

        private void PrintActionInfo(string actionTitle)
        {
            Log.Info($"{actionTitle}: " + DescriptionFull);
        }
    }
}
