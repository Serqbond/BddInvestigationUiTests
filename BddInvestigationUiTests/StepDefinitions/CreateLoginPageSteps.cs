using BddInvestigationUiTests.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BddInvestigationUiTests.StepDefinitions
{
    [Binding]
    public sealed class CreateLoginPageSteps
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private AdminPage adminPage;

        public CreateLoginPageSteps(IWebDriver driver)
        {
            this.driver = driver;
            loginPage = new LoginPage(driver);
            adminPage = new AdminPage(driver);
        }

        [Given(@"I open a login page")]
        public void GivenIOpenALoginPage()
        {
            driver.Navigate().GoToUrl("http://localhost:51718/Home/LogIn");
        }

        [When(@"I enter correct user name and password")]
        public void WhenIEnterCorrectUserNameAndPassword()
        {
            loginPage.SetUserName("admin@mail.com").SetUserPazzword("Password123!");
        }

        [When(@"I use exisiting user login and password")]
        public void WhenIUseExisitingUserLoginAndPassword()
        {
            loginPage.ClickLogInButton();
        }

        [Then(@"The user is logged in")]
        public void ThenTheUserIsLoggedIn()
        {
            Assert.AreEqual("You're logged in as admin", adminPage.GetWelcomeMessage());
        }
    }
}
