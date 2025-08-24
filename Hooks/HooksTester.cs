using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using Reqnroll.BoDi;

namespace ReqnRollBDD.Hooks
{
    [Binding]
    public sealed class HooksTester
    {
        private readonly IObjectContainer _objectContainer;
        public HooksTester(IObjectContainer container)
        {
            _objectContainer = container;
        }
        [BeforeScenario("@TestersTalk")]
        public void BeforeScenarioWithTag()
        {
            Console.WriteLine("This will run before the scenario with @TestersTalk tag");
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
           var driver= _objectContainer.Resolve<IWebDriver>();
            if(driver != null)
            {
                driver.Quit();
            }
        }
    }
}