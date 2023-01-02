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
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {


        IDataRepository<UserRegistration> _dataRepository;
        public UserController()
        {
            this._dataRepository = new UserRepository(new PharmacyManagementSystemDBEntities2());
        }
        [HttpGet]
        [Route("")]
        public IEnumerable<UserRegistration> GetAllusers()
        {
            var users = _dataRepository.GetAll();
            return users;
        }
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateUser(UserRegistration user)
        {
            UserRegistration userObj = null;
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
        [HttpPut]
        [Route("{id}")]
        //[Route("")]
        public IHttpActionResult Updateuser(int id, [FromBody] UserRegistration userobj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (userobj == null)
            {
                return BadRequest("user id is Not found");
            }
            if (id != userobj.UserID)
            {
                return BadRequest();
            }
            _dataRepository.Update(id, userobj);

            return Ok("Updated Successfully");
        }

        [HttpDelete]
        [Route("")]
        public IHttpActionResult DeleteUser(int id)
        {
            

            try
            {

                if (id <= 0)
                    return BadRequest("please enter the userid");
                _dataRepository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok("Deleted Successfully");
        }
    }
}





    

