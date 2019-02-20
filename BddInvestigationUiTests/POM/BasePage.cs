using OpenQA.Selenium;

namespace BddInvestigationUiTests.POM
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
