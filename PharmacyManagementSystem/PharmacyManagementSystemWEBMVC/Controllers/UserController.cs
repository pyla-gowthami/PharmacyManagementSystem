using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PharmacyManagementSystemWEBMVC.Models;
using PharmacyManagementSystemWEBMVC.Repository;

namespace PharmacyManagementSystemWEBMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public async Task<ActionResult> Index()
        {
            List<UserViewModel> users = new List<UserViewModel>();
            var service = new UserServiceRepository();
            {
                using (var response = service.GetResponse("api/User"))
                {
                    string apiResponse
                        = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject
                  <List<UserViewModel>>(apiResponse);
                }
            }
            return View(users);
        }
        
      

         public async Task<ActionResult> Create(UserViewModel userviewmodel)
        {
            if (ModelState.IsValid)
            {
                UserViewModel newUser = new UserViewModel();
                var service = new UserServiceRepository();
                {
                    using (var response = service.PostResponse("api/User", userviewmodel))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        //newUser = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                    }
                }
                return RedirectToAction("Index");
            }
            return View(userviewmodel);
        }
        
    }
}




