using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using OpenQA.Selenium;
using System;
using System.IO;

namespace ReqnRollBDD.Utility
{
    public class ExtentReport
    {
        // Mark the static fields as nullable to resolve CS8618
        public static ExtentReports? _extentReports;
        public static ExtentTest? _feature;
        public static ExtentTest? _scenario;

        // Use Path.Combine for cross-platform safety and reliability
        public static readonly string TestResultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestResults");

        static ExtentReport()
        {
            EnsureTestResultDirectoryExists();
        }

        private static void EnsureTestResultDirectoryExists()
        {
            if (!Directory.Exists(TestResultPath))
            {
                Directory.CreateDirectory(TestResultPath);
            }
        }

        public static void ExtentReportInit()
        {
            EnsureTestResultDirectoryExists();

            var htmlReporter = new ExtentSparkReporter(TestResultPath)
            {
                Config =
                {
                    ReportName = "Automation Status Report",
                    DocumentTitle = "Automation Status Report",
                    Theme = Theme.Standard,
                    Encoding = "utf-8"
                }
            };

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Application", "Youtube");
            _extentReports.AddSystemInfo("Browser", "Chrome");
            _extentReports.AddSystemInfo("OS", "Windows");
        }

        public static void ExtentReportTearDown()
        {
            EnsureTestResultDirectoryExists();
            _extentReports?.Flush();
        }

        public string AddScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            EnsureTestResultDirectoryExists();

            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();

            string fileName = $"{scenarioContext.ScenarioInfo.Title}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            string screenshotLocation = Path.Combine(TestResultPath, fileName);

            screenshot.SaveAsFile(screenshotLocation);

            return screenshotLocation;
        }
    }
}