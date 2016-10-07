using NBehave.Narrator.Framework;
using NUnit.Framework;
using OpenQA.Selenium;
using Specter.Main;

namespace Specter.Steps
{
    [ActionSteps]
    public class LandToAgodaStep
    {
        [Given("Land to Agoda")]
        public void WithoutParameter()
        {
            Chrome.Navigate().GoToUrl("http://www.agoda.com");
        }

        [Given("Land to Agoda with $querystring")]
        public void WithParameter(string querystring)
        {
            Chrome.Navigate().GoToUrl("http://www.agoda.com?" + querystring);
        }

        [Then("Agoda title should be $title")]
        public void TitleShouldBe(string title)
        {
            Assert.AreEqual(title, Chrome.Title);
        }

        [Then("Agoda title should contain $title")]
        public void TitleShouldContain(string title)
        {
            Assert.IsTrue(Chrome.Title.Contains(title));
        }

        private static IWebDriver Chrome => (IWebDriver)FeatureContext.Current[ContextKeys.Chrome];
    }
}
