using FinallyProjectDAL.Abstract;
using FinallyProjectDATA.Models.ViewModels;
using FinallyProjectUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinallyProjectUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryDAL _categoryDAL;
        private readonly IProductDAL _productDAL;
        public HomeController(ILogger<HomeController> logger, IProductDAL productDAL, ICategoryDAL categoryDAL)
        {
            _logger = logger;
            _productDAL = productDAL;
            _categoryDAL = categoryDAL;
        }

        public IActionResult Index()
        {
            var products = _productDAL.GetAll(i => i.IsHome && i.IsApproved);
            return View(products);
        }

        public IActionResult List(int? id)
        {
            ViewBag.Id = id;
            var products = _productDAL.GetAll(i => i.IsApproved);
            if (id != null)
            {
                products = products.Where(p => p.CategoryId == id).ToList();
            }
            var models = new ListViewModel()
            {
                Categories = _categoryDAL.GetAll(),
                Products = products
            };
            return View(models);
        }
        public IActionResult Details(int id)
        {
            var product = _productDAL.Get(id);
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}