using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystemWEBAPI.Repository
{
   
    
        public interface IDataRepository<TEntity>
        {
            IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(int id,TEntity entity);
        void Delete(int entity);
    }
    }


