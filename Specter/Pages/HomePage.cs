using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Specter.Pages
{
    internal class HomePage
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public ReadOnlyCollection<IWebElement> GetTabs => _driver
            .FindElements(By.CssSelector("#hero-banner-tab-nav li"));

        public IWebElement GetActiveTab => _driver
            .FindElement(By.Id("hero-banner-tab-nav"))
            .FindElement(By.ClassName("active"));
    }
}
