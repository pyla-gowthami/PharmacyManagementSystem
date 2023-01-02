using PharmacyManagementSystemWEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystemWEBAPI.Repository
{
    internal interface ILogin
    {
        UserRegistration VerifyLogin(string EmailID, string Password);
    }
}
