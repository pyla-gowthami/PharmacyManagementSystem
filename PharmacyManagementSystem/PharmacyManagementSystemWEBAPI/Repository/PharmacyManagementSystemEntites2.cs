using System;
using System.Collections.Generic;
using PharmacyManagementSystemWEBAPI.Models;

namespace PharmacyManagementSystemWEBAPI.Repository
{
    public class PharmacyManagementSystemEntites3
    {
        public IEnumerable<object> UserRegistrations { get; internal set; }

        public static implicit operator PharmacyManagementSystemEntites3(PharmacyManagementSystemEntities3 v)
        {
            throw new NotImplementedException();
        }
    }
}