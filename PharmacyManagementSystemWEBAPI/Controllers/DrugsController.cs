using PharmacyManagementSystemWEBAPI.Models;
using PharmacyManagementSystemWEBAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmacyManagementSystemWEBAPI.Controllers
{
    [RoutePrefix("api/Drugs")]
    public class DrugsController : ApiController
    {
        IDataRepository<Drug> _dataRepository;
        public DrugsController()
        {
            this._dataRepository = new DrugsRepository(new PharmacyManagementSystemDBEntities2());
        }
        [HttpGet]
        [Route("")]
        public IEnumerable<Drug> GetAllusers()
        {
            var users = _dataRepository.GetAll();
            return users;
        }
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateDrug(Drug user)
        {
            Drug drugObj = null;
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");
                _dataRepository.Add(user);




            }
            catch (Exception)
            {



                throw;
            }
            return Ok("Data Saved!");
        }


    }

}

