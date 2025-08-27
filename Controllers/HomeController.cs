using System.Diagnostics;
using JPAP.Models;
using Microsoft.AspNetCore.Mvc;
using JPAP.Services;

namespace JPAP.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly FilePathLocator _service;

        public HomeController(FilePathLocator service)
        {
            _service = service;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            var allSeries = _service.GetAllSeries();
            return View(allSeries);
        }

        //public Task<IActionResult> GetAnime()
        //{

        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
