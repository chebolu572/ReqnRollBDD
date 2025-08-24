using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using ReqnRollBDD.Pages;
using System;

namespace ReqnRollBDD.StepDefinitions
{
    [Binding]
    public class PageObjectModelStepDefinitions(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;
        private SearchPage? searchPage;
        private ResultPage? resultPage;
        private ChannelPage? channelPage;

        [Given(@"Enter the youtube URL")]
        public void GivenEnterTheYoutubeURL()
        {
            driver.Url = "https://www.youtube.com/";
            Thread.Sleep(4000);
        }

        [When(@"Search for the testers talk in youtube")]
        public void WhenSearchForTheTestersTalkInYoutube()
        {
            searchPage = new SearchPage(driver);

            resultPage = searchPage.searchText("testers talk");
            Thread.Sleep(4000);
        }

        [When(@"Navigate to channel")]
        public void WhenNavigateToChannel()
        {
            if (resultPage == null)
                throw new InvalidOperationException("ResultPage is not initialized.");
            channelPage = resultPage.clickOnChannel();
            Thread.Sleep(4000);
        }

        [Then(@"Verify title of the page")]
        public void ThenVerifyTitleOfThePage()
        {
            if (channelPage == null)
                throw new InvalidOperationException("ChannelPage is not initialized.");
            Assert.AreEqual("Testers Talk - ", channelPage.getTitle());
        }
    }
}
