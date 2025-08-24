using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace ReqnRollBDD.StepDefinitions
{
    [Binding]
    public sealed class DataTableDataDrivenTestingStepDefinitions
    {
        private IWebDriver driver;

       public DataTableDataDrivenTestingStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Then(@"Enter search keyword in Youtube")]
        public void ThenEnterSearchKeywordInYoutube(Table table)
        {
           var searchCriteria =  table.CreateSet<SearchKeyTestData>();

            foreach(var keyword in searchCriteria)
            {
                driver.FindElement(By.XPath("//*[@name='search_query']")).Clear();
                driver.FindElement(By.XPath("//*[@name='search_query']")).SendKeys(keyword.SearchKey);
                driver.FindElement(By.XPath("//*[@name='search_query']")).SendKeys(Keys.Enter);
                Thread.Sleep(5000);
            }

        }
    }

    public class SearchKeyTestData
    {
        public required string SearchKey { get; set; }
    }



}