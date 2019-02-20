using BddInvestigationUiTests.Models;
using BddInvestigationUiTests.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BddInvestigationUiTests.StepDefinitions
{
    [Binding]
    public sealed class AddANewUserSteps
    {
        private IWebDriver driver;
        private AdminPage adminPage;
        private AddUserPage addUserPage;
        private UserDetailsPage userDetailsPage;
        private LoginPage loginPage;
        private User testUser;

        public AddANewUserSteps(IWebDriver driver)
        {
            this.driver = driver;
            adminPage = new AdminPage(driver);
            addUserPage = new AddUserPage(driver);
            userDetailsPage = new UserDetailsPage(driver);
            loginPage = new LoginPage(driver);
        }

        [Given(@"I open Add New User Page")]
        public void GivenIOpenAddNewUserPage()
        {
            driver.Navigate().GoToUrl("http://localhost:51718/Home/Admin");
            if (driver.Url.Contains("Home/LogIn"))
            {
                loginPage.SetUserName("admin@mail.com").SetUserPazzword("Password123!")
                    .ClickLogInButton();
            }

            adminPage.ClickAddNewButton();
        }

        [When(@"I fill new user form")]
        public void WhenIFillNewUserForm(Table table)
        {
            var user = table.CreateInstance<User>();
            testUser = user;
            addUserPage.FillUserForm(user);
        }

        [When(@"click on Cancel button")]
        public void WhenClickOnCancelButton()
        {
            addUserPage.ClickCancelButton();
        }

        [Then(@"user should be in the table")]
        public void ThenUserShouldBeInTheTable()
        {
            var users = userDetailsPage.GetUserList();
            Assert.IsTrue(users.Contains(testUser));
        }

        [When(@"click on create button")]
        public void WhenClickOnButton()
        {
            addUserPage.ClickCreateNewUserButton();
        }        

        [Then(@"Add New User Page closes")]
        public void ThenAddNewUserPageCloses()
        {
            Assert.IsFalse(addUserPage.IsAddNewUserPageOpened());
        }

        [Then(@"user isn't added to the table")]
        public void ThenUserIsnTAddedToTheTable()
        {
            driver.Navigate().GoToUrl("http://localhost:51718/Home/UserDetails");
            var users = userDetailsPage.GetUserList();
            Assert.IsFalse(users.Contains(testUser));
        }
    }
}
