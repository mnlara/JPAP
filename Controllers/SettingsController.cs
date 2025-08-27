using Microsoft.AspNetCore.Mvc;

namespace JPAP.Controllers
{
    public class SettingsController : Controller
    {
        private readonly string _filepath;

        public SettingsController(IWebHostEnvironment env)
        {
            _filepath = Path.Combine(env.ContentRootPath, "Data", "value.txt");

            if (!System.IO.File.Exists(_filepath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_filepath)!);
                System.IO.File.WriteAllText(_filepath, "");
            }
        }

        public IActionResult Index()
        {
            string savedValue = System.IO.File.ReadAllText(_filepath);
            //ViewBag.SavedValue = savedValue;
            ViewData["SavedValue"] = savedValue;
            return View();
        }

        public IActionResult Save(string inputValue)
        {
            System.IO.File.WriteAllText(_filepath, inputValue ?? "");
            return RedirectToAction("Index");
        }
    }
}
