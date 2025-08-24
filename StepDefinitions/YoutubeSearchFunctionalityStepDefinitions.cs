using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;

namespace ReqnRollBDD.StepDefinitions
{
    [Binding]
    public class YoutubeSearchFunctionalityStepDefinitions
    {
        IWebDriver driver;
        [Given("Open the YouTube homepage")]
        public void GivenOpenTheYouTubeHomepage()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();  
        }

        [When("Enter the URL")]
        public void WhenEnterTheURL()
        {
            driver.Navigate().GoToUrl("https://www.youtube.com");
            Thread.Sleep(5000); // Wait for 2 seconds to ensure the page loads
        }

        [Then("Search for a Testers Talk video")]
        public void ThenSearchForATestersTalkVideo()
        {
           driver.FindElement(By.Name("search_query")).SendKeys("Testers Talk");
           driver.FindElement(By.Name("search_query")).SendKeys(Keys.Enter);
           driver.Close();
           driver.Quit();
        }
    }
}
