using System;
using Specter.Pages;
using NBehave.Narrator.Framework;
using NUnit.Framework;
using OpenQA.Selenium;
using Specter.Main;

namespace Specter.Steps
{
    [ActionSteps]
    public class HomeStep
    {
        private readonly Lazy<HomePage> _home;

        private HomePage Home => _home.Value;

        public HomeStep()
        {
            _home = new Lazy<HomePage>(() => new HomePage((IWebDriver)FeatureContext.Current[ContextKeys.Chrome]));
        }

        [Then("Home tab size should be $count")]
        public void TabSizeShouldBe(int count)
        {
            Assert.AreEqual(count, Home.GetTabs.Count);
        }
    }
}
