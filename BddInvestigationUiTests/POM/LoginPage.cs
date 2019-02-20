using OpenQA.Selenium;

namespace BddInvestigationUiTests.POM
{
    public class LoginPage : BasePage
    {
        private By EmailInput => By.Id("Email");
        private By PazzwordInput => By.Id("Password");
        private By LogInButton => By.XPath("//input[@type='submit']");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public LoginPage SetUserName(string userName)
        {
            driver.FindElement(EmailInput).SendKeys(userName);
            return new LoginPage(this.driver);
        }

        public LoginPage SetUserPazzword(string userPazzword)
        {
            driver.FindElement(PazzwordInput).SendKeys(userPazzword);
            return new LoginPage(this.driver);
        }

        public AdminPage ClickLogInButton()
        {
            driver.FindElement(LogInButton).Click();
            return new AdminPage(this.driver);
        }
    }
}
