using Newtonsoft.Json;
using PharmacyManagementSystemWEBMVC.Models;
using PharmacyManagementSystemWEBMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PharmacyManagementSystemWEBMVC.Controllers
{
    public class UserRegistrationController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<UserViewModel> users = new List<UserViewModel>();
            var service = new UserService();
            {
                using (var response = service.GetResponse("User"))
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
                var service = new UserService();
                {
                    using (var response = service.PostResponse("user", userviewmodel))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();



                       // newUser = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                    }
                }
                return RedirectToAction("Index");
            }
            return View(userviewmodel);
        }
        public ActionResult LoginUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> LoginUser(LoginViewModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserViewModel newUser = new UserViewModel();
                    var service = new UserService();
                    {
                        using (var response = service.VerifyLogin("api/Account/Login", login))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            newUser = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                        }
                    }
                    if (newUser != null)
                    {
                        ViewBag.message = "Login Success";
                    }
                    else
                    {
                        ViewBag.message = "incorrect";
                    }
                }
            }
            catch
            {

            }
            return View("HomePage");

            
        }
        public ActionResult HomePage()
        {
            return View();
        }
        //[HttpDelete]
        //public async Task<ActionResult> Delete(int Id)
        //{
        //    UserViewModel users = new UserViewModel();
        //    var service = new UserService();
        //    {
        //        using (var response = service.DeleteResponse("api/User" + "/" + Id))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            //users = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
        //        }
        //    }
        //    return RedirectToAction("Index");
        //}

        public async Task<ActionResult> Edit(int Id)
        {
            UserViewModel users = new UserViewModel();
            var service = new UserService();
            {
                using (var response = service.GetResponse("api/User" + "/" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //users = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                }
            }
            return View(users);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(UserViewModel users)
        {
            UserViewModel update = new UserViewModel();
            var service = new UserService();
            {
                using (var response = service.PutResponse("api/User" + "/" + users.UserID, users))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //update = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Delete(int Id)
        {

            var service = new UserService();
            {
                using (var response = service.DeleteResponse( "User?id=" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //users = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}