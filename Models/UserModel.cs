using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace McIntashLaptops.Models
{
    public class UserModel
    {
        [DisplayName("Employees Id")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Username")]
        [StringLength(255,MinimumLength = 1)]
        public string Username { get; set; }
        [StringLength(255, MinimumLength = 8)]
        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Managers's First Name")]
        [StringLength(255, MinimumLength = 1)]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Manager's Last Name")]
        [StringLength(255, MinimumLength = 1)]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Email")]
        [StringLength(255, MinimumLength = 1)]
        public string Email { get; set; }
        [Required]
        [DisplayName("Phone")]
        [StringLength(255, MinimumLength = 1)]
        public string Phone { get; set; }
        [DisplayName("City")]
        [StringLength(255, MinimumLength = 1)]
        public string City { get; set; }
        [DisplayName("State")]
        [StringLength(255, MinimumLength = 1)]
        public string State { get; set; }
        [DisplayName("Zip Code")]
        [StringLength(255, MinimumLength = 1)]
        public string Zip { get; set; }
        [DisplayName("Street Address")]
        [StringLength(255, MinimumLength = 1)]
        public string Street { get; set; }
        [DisplayName("Country")]
        [StringLength(255, MinimumLength = 1)]
        public string Country { get; set; }
        public UserModel()
        {
        }

        public UserModel(int id, string username, string password, string firstName, string lastName, string email,
            string phone, string city, string state, string zip, string street, string country)
        {
            Id = id;
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            City = city;
            State = state;
            Zip = zip;
            Street = street;
            Country = country;
        }
    }
}
