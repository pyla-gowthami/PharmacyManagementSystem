using PharmacyManagementSystemWEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyManagementSystemWEBAPI.Repository
{
    public class DrugsRepository : IDataRepository<Drug>
    {
        PharmacyManagementSystemDBEntities2 _drugdbcontext;
        public DrugsRepository(PharmacyManagementSystemDBEntities2 drugdbcontext)
        {
            _drugdbcontext = drugdbcontext;
        }

        public void Add(Drug newdrug)
        {
            var drugs = _drugdbcontext.Drugs.Add(newdrug);
            _drugdbcontext.SaveChanges();

        }

        public void Delete(int entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Drug> GetAll()
        {
            return _drugdbcontext.Drugs.ToList();
        }

        public void Update(int id, Drug entity)
        {
            throw new NotImplementedException();
        }
    }
}


    
