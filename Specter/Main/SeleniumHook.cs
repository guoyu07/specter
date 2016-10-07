using NBehave.Narrator.Framework;
using NBehave.Narrator.Framework.Hooks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Specter.Main
{
    [Hooks]
    public class SeleniumHooks
    {
        private IWebDriver _driver;

        [BeforeFeature]
        public void SetupFeature()
        {
            _driver = new ChromeDriver();
            FeatureContext.Current.Add(ContextKeys.Chrome, _driver);
        }

        [AfterFeature]
        public void TearDownFeature()
        {
            _driver?.Close();
        }
    }

    public static class ContextKeys
    {
        public const string Chrome = "ChromeDriver";
    }
}
