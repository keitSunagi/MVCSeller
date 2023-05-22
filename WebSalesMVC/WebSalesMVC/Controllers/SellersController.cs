using Microsoft.AspNetCore.Mvc;
using WebSalesMVC.Services;

namespace WebSalesMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellersService _service;

        public SellersController (SellersService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var list = _service.FindAll();
            return View(list);
        }
    }
}
