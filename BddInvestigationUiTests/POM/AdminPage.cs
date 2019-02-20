using OpenQA.Selenium;

namespace BddInvestigationUiTests.POM
{
    public class AdminPage : BasePage
    {
        private By WelcomeMessage => By.XPath("//h2");
        private By CreateUserButton => By.Id("addUser");

        public AdminPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetWelcomeMessage()
        {
            return driver.FindElement(WelcomeMessage).Text;
        }

        public AddUserPage ClickAddNewButton()
        {
            driver.FindElement(CreateUserButton).Click();
            return new AddUserPage(driver);
        }
    }
}
