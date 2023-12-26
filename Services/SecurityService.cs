using McIntashLaptops.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.AccessControl;

namespace McIntashLaptops.Services
{
    public class SecurityService
    {

        List<UserModel> knownUsers = new List<UserModel>();

        public SecurityService()
        {
            knownUsers.Add(
                new UserModel { Id = 0, Username = "John",FirstName="John",LastName="Keen", Password = "Pass", City="Redmond",State = "Oregon",Zip="97756", Country="USA",Street="123 NW Good Street", Email="johnkeenishere@gmail.com",Phone="541-548-7005"});
        }

        public bool IsValid(UserModel user)
        {
            return knownUsers.Any(x=>x.Username == user.Username && x.Password== user.Password);
        }
        public UserModel GetUser(UserModel user)
        {
            UserModel gotten = knownUsers.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password)
                ??new UserModel { };
            return gotten;
        }
    }
}
