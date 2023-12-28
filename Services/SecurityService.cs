using McIntashLaptops.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.AccessControl;

namespace McIntashLaptops.Services
{
    public class SecurityService
    {

        SecurityDAO securityDAO = new SecurityDAO();

        public bool IsValid(UserModel user)
        {
            return securityDAO.FindUserByUsernameAndPassword(user);
        }
        public UserModel GetUser(UserModel user)
        {
            UserModel gotten = securityDAO.GetUserByUsernameAndPassword(user);
            return gotten;
        }
    }
}
