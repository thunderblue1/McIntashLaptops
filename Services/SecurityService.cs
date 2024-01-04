using McIntashLaptops.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using System.Linq;
using System.Security.AccessControl;

namespace McIntashLaptops.Services
{
    public class SecurityService
    {

        SecurityDAO securityDAO = new SecurityDAO();
        IDataProtectionProvider dpp;
        ISession session;
        public SecurityService(IDataProtectionProvider dpp, IHttpContextAccessor httpContextAccessor)
        {
            this.dpp = dpp;
            this.session = httpContextAccessor.HttpContext.Session;
        }

        public bool IsValid(UserModel user)
        {
            return securityDAO.FindUserByUsernameAndPassword(user);
        
            
        }
        public UserModel GetUser(UserModel user)
        {
            UserModel gotten = securityDAO.GetUserByUsernameAndPassword(user);
            return gotten;
        }

        public bool AlreadyExists(UserModel user)
        {
            return false;
        }
        public bool AddUser(UserModel user)
        {
            var protector = dpp.CreateProtector("user-service");
            var newPassword = protector.Protect(user.Password);
            user.Password = newPassword;
            session.SetString("encrypted",user.Password);

            return true;
        }
    }
}
