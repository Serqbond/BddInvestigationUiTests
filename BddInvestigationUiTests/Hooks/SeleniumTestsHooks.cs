using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace BddInvestigationUiTests.Hooks
{
    [Binding]
    public sealed class SeleniumTestsHooks
    {
        private IWebDriver driver;
        private readonly IObjectContainer objectContainer;
        private Browser browser = Browser.Chrome;

        public SeleniumTestsHooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            string ciDiver = Environment.GetEnvironmentVariable("driver");

            if (ciDiver == "ieexplorer")
            {
                browser = Browser.IeExplorer;
            }
            else if (ciDiver == "edge")
            {
                browser = Browser.Edge;
            }

            initDriver(browser);


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }

        private void initDriver(Browser browser)
        {
            switch (browser)
            {
                case Browser.Chrome:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("start-maximized");
                    driver = new ChromeDriver(chromeOptions);
                    break;
                case Browser.IeExplorer:
                    break;
                case Browser.Edge:
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
        }
    }

    enum Browser
    {
        Chrome = 1,
        IeExplorer = 2,
        Edge = 3
    }
}