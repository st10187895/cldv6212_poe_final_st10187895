using cldv6212_poe_final_st10187895.Models;
using Microsoft.AspNetCore.Mvc;

namespace cldv6212_poe_final_st10187895.Controllers
{
    public class AddCustomerProfile : Controller
    {

        public CustomerProfile profile = new CustomerProfile();
        [HttpPost]
        public ActionResult CustProfile(CustomerProfile custProf)
        {
            var result = profile.Add_CustomerInfo(custProf);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult AddCustomerInfo()
        {
            return View();
        }
    }
}
