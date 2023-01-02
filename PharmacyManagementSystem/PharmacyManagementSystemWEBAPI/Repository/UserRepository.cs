using PharmacyManagementSystemWEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyManagementSystemWEBAPI.Repository
{


    public class UserRepository : IDataRepository<UserRegistration>
    {
        PharmacyManagementSystemEntities1 _userdbcontext;
        public UserRepository(PharmacyManagementSystemEntities1 userdbcontext)
        {
            _userdbcontext = userdbcontext;
        }

        public void Add(UserRegistration newUser)
        {
            var users = _userdbcontext.UserRegistrations.Add(newUser);
            _userdbcontext.SaveChanges();

        }

        public void Delete(int entity)
        {
            var users = _userdbcontext.UserRegistrations.Remove(_userdbcontext.UserRegistrations.FirstOrDefault(e => e.UserID == entity));
            _userdbcontext.SaveChanges();
        }

        public IEnumerable<UserRegistration> GetAll()
        {
            return _userdbcontext.UserRegistrations.ToList();
        }

        public void Update(int id, UserRegistration entity)
        {

            _userdbcontext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _userdbcontext.SaveChanges();
        }


    }
}

