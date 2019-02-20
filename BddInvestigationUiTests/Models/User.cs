using System;

namespace BddInvestigationUiTests.Models
{
    public class User : IEquatable<User>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string City { get; set; }

        public bool Equals(User other)
        {
            if (other == null) return false;

            if (other.FirstName == this.FirstName && other.LastName == this.LastName
                //&& other.DateOfBirth == this.DateOfBirth 
                && other.Email == this.Email
                && other.City == this.City) return true;

            return false;
        }
    }
}
