using JPAP.Services;
using Microsoft.AspNetCore.Mvc;

namespace JPAP.Controllers
{
    public class AnimeController : Controller
    {
        //private readonly ParserService _service;

        //public AnimeController(ParserService service)
        //{
        //    _service = service;
        //}

        public IActionResult Index()
        {
            //var allSeries = _service.Parse(filename);
            return View();
        }

        //public IActionResult Player(string filePath, string? subtitlePath)
        //{
        //    ViewBag.VideoPath = "/video/stream?path=" + Uri.EscapeDataString(filePath);
        //    ViewBag.SubtitlePath = subtitlePath != null
        //        ? "/video/subs?path=" + Uri.EscapeDataString(subtitlePath)
        //        : null;

        //    return View();
        //}
    }
}
