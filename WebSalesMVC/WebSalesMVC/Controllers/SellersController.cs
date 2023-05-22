using Microsoft.AspNetCore.Mvc;
using WebSalesMVC.Models;
using WebSalesMVC.Services;

namespace WebSalesMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellersService _service;

        public SellersController(SellersService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var list = _service.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Email,BirthDate")] Seller seller)
        {
            _service.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
