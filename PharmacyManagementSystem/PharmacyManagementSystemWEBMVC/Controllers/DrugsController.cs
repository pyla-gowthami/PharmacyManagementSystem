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
    public class DrugsController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<DrugViewModel> Drug = new List<DrugViewModel>();
            var service = new UserService();
            {
                using (var response = service.GetResponse("Drugs"))
                {
                    string apiResponse
                        = await response.Content.ReadAsStringAsync();
                    Drug = JsonConvert.DeserializeObject
                                    <List<DrugViewModel>>(apiResponse);
                }
            }
            return View(Drug);
        }
    }
}
       