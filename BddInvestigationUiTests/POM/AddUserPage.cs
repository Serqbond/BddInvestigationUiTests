using BddInvestigationUiTests.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BddInvestigationUiTests.POM
{
    public class AddUserPage : BasePage
    {
        private By FirstNameInput => By.Id("FirstName");
        private By LastNameInput => By.Id("LastName");
        private By EmailInput => By.Id("Email");
        private By DateOfBirthInput => By.Id("DateOfBirth");
        private By CityInput => By.Id("UserCity");
        private By CreateButton => By.XPath("//input[@type='submit']");
        private By CancelButton => By.Id("closebtn");

        public AddUserPage(IWebDriver driver) : base(driver)
        {
        }

        public AddUserPage FillUserForm(User user)
        {
            driver.FindElement(FirstNameInput).SendKeys(user.FirstName);
            driver.FindElement(LastNameInput).SendKeys(user.LastName);
            driver.FindElement(EmailInput).SendKeys(user.Email);
            driver.FindElement(DateOfBirthInput).SendKeys(user.DateOfBirth);
            var city = driver.FindElement(CityInput);
            var selectElement = new SelectElement(city);
            //selectElement.SelectByValue("Jr.High");
            selectElement.SelectByText(user.City);
            return new AddUserPage(driver);
        }

        public UserDetailsPage ClickCreateNewUserButton()
        {
            driver.FindElement(CreateButton).Click();
            return new UserDetailsPage(driver);
        }
    }
}
