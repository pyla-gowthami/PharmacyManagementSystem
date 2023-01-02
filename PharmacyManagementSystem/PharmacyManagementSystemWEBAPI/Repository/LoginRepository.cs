using PharmacyManagementSystemWEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyManagementSystemWEBAPI.Repository
{
    public class LoginRepository : ILogin
    {
        PharmacyManagementSystemEntities1 _loginentities;
        public LoginRepository(PharmacyManagementSystemEntities1 loginentities)
        {
            _loginentities = loginentities;
        }
        public UserRegistration VerifyLogin(string EmailID, string Password)
        {
            UserRegistration login = null;
            try
            {
                var checkValidUser = _loginentities.UserRegistrations.Where(m => m.EmailID == EmailID &&
            m.Password == Password).FirstOrDefault();
                if (checkValidUser != null)
                {
                    login = checkValidUser;
                }
                else
                {
                    login = null;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return login;
        }
    }
}