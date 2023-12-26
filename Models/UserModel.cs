using System.Collections.Generic;
using System.IO;

namespace McIntashLaptops.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Street { get; set; }

        public string Country { get; set; }
    }
}
