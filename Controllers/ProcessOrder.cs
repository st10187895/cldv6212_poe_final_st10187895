using cldv6212_poe_final_st10187895.Models;
using Microsoft.AspNetCore.Mvc;

namespace cldv6212_poe_final_st10187895.Controllers
{
    public class ProcessOrder : Controller
    {
        public OrderInfo info = new OrderInfo();
        [HttpPost]
        public ActionResult OrderInfo(OrderInfo oInfo)
        {
            var result = info.Add_OrderInfo(oInfo);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult ProcessOrderInfo()
        {
            return View();
        }
        
    }
}
