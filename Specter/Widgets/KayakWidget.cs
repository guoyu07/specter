using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Specter.Widgets
{
    public class KayakWidget
    {
        private const string KayakWidgetLayout = "kayakWidgetLayout";
        private const string KayakWidgetAutoCompletion = "kayakWidgetAutoCompletion";
        private const string KayakWidgetDatePicker = "kayakWidgetDatePicker";

        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public KayakWidget(IWebDriver driver)
        {
            this._driver = driver;
            this._wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void SwitchToKayakWidget(string iframeId)
        {
            _wait.Until(d => _driver.SwitchTo().Frame(d.FindElement(By.Id(iframeId))));
        }

        public void SendOriginCode(string keys, string id)
        {
            SendKeysToTextboxId("flightsOrigin", keys, id);
        }

        public void SendDestinationCode(string keys, string id)
        {
            SendKeysToTextboxId("flightsDestination", keys, id);
        }

        public void ClickKayakCalendarId(DateTime startDate, DateTime endDate)
        {
            var today = DateTime.Now;

            var startCalendar = (startDate.Month - today.Month) == 0 ? "firstCalendar" : "secondCalendar";
            ClickStartDate("flightsStartDate", startCalendar, startDate.Day);

            var endCalendar = (endDate.Month - today.Month) == 0 ? "firstCalendar" : "secondCalendar";
            ClickStartDate("flightsEndDate", endCalendar, endDate.Day);
        }

        public void ClickSearch()
        {
            SwitchToKayakWidget(KayakWidgetLayout);

            var search = _driver.FindElement(By.ClassName("flightsSearch"));
            search.Click();

            _driver.SwitchTo().ParentFrame();
        }

        private void SendKeysToTextboxId(string boxid, string keys, string id)
        {
            SwitchToKayakWidget(KayakWidgetLayout);

            var origin = _driver.FindElement(By.ClassName(boxid));
            origin.Clear();
            Thread.Sleep(1000);
            origin.SendKeys(keys);
            Thread.Sleep(1000);
            _driver.SwitchTo().ParentFrame();
            SwitchToKayakWidget(KayakWidgetAutoCompletion);
            _driver.FindElement(By.Id(id)).Click();

            _driver.SwitchTo().ParentFrame();
        }

        private void ClickStartDate(string box, string calendar, int day)
        {
            SwitchToKayakWidget(KayakWidgetLayout);
            var origin = _driver.FindElement(By.ClassName(box));
            Thread.Sleep(1000);
            origin.Click();
            Thread.Sleep(1000);
            _driver.SwitchTo().ParentFrame();
            SwitchToKayakWidget(KayakWidgetDatePicker);
            var startBtn = _driver.FindElement(By.ClassName(calendar)).FindElement(By.XPath("//button[@data-pika-day='" + day + "']"));
            startBtn.Click();

            _driver.SwitchTo().ParentFrame();
        }
    }
}
