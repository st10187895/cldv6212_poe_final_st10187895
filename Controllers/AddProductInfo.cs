using cldv6212_poe_final_st10187895.Models;
using Microsoft.AspNetCore.Mvc;

namespace cldv6212_poe_final_st10187895.Controllers
{
    public class AddProductInfo : Controller
    {
        public ProductInfo info = new ProductInfo();
        [HttpPost]
        public ActionResult prodInfo(ProductInfo pInfo)
        {
            var result = info.Add_ProductInfo(pInfo);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult UploadProductInfo()
        {
            return View();
        }
    }
}
