using BddInvestigationUiTests.Models;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace BddInvestigationUiTests.POM
{
    public class UserDetailsPage : BasePage
    {
        private By DataTable => By.XPath("//table");

        public UserDetailsPage(IWebDriver driver) : base(driver)
        {
        }

        public List<User> GetUserList()
        {
            var users = new List<User>();
            int tableRowsCount = driver.FindElements(By.TagName("tr")).Count - 1;
            var cells = driver.FindElements(By.XPath("//tr/td"));
            for (int i = 0; i < tableRowsCount; i++)
            {
                var userRawData = cells.Skip(i * 5).Take(5);
                var user = new User()
                {
                    FirstName = userRawData.ElementAt(0).Text,
                    LastName = userRawData.ElementAt(1).Text,
                    Email = userRawData.ElementAt(2).Text,
                    DateOfBirth = userRawData.ElementAt(3).Text,
                    City = userRawData.ElementAt(4).Text
                };

                users.Add(user);
            }

            return users;
        }
    }
}
