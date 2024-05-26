using McIntashLaptops.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using System.Linq;
using System.Security.AccessControl;

namespace McIntashLaptops.Services
{
    public class SecurityService: ISecurity
    {
        IDataProtectionProvider dpp;

        public SecurityService(IDataProtectionProvider dpp)
        {
            this.dpp = dpp;
        }

        //This is for encrypting information if required
        public string EncryptCard(string data)
        {
            string encryptedData = "";
            IDataProtector dataProtector = dpp.CreateProtector("credit_card");
            if(!string.IsNullOrEmpty(data)) { 
                encryptedData = dataProtector.Protect(data);
            }
            return encryptedData;
        }
        
    }
}
