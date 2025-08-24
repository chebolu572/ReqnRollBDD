using System;
using OpenQA.Selenium;
using Reqnroll;

namespace ReqnRollBDD.StepDefinitions
{
    [Binding]
    public sealed class DataDrivenTestingStepDefinitions
    {
        private IWebDriver driver;
        public DataDrivenTestingStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Then("Search for {string}")]
        public void ThenSearchFor(string searchkey)
        {
            driver.FindElement(By.Name("search_query")).SendKeys(searchkey);
            driver.FindElement(By.Name("search_query")).SendKeys(Keys.Enter);
            Thread.Sleep(5000);
        }
    }
}
