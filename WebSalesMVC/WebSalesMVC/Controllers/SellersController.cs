using Microsoft.AspNetCore.Mvc;

namespace WebSalesMVC.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
