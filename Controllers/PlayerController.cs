using Microsoft.AspNetCore.Mvc;

namespace JPAP.Controllers
{
    public class PlayerController : Controller
    {
        //[HttpGet("/video/stream")]
        //public IActionResult Stream(string path)
        //{
        //    if (!System.IO.File.Exists(path))
        //        return NotFound();

        //    var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
        //    var mime = Path.GetExtension(path).ToLower() switch
        //    {
        //        ".mp4" => "video/mp4",
        //        ".mkv" => "video/x-matroska",
        //        _ => "application/octet-stream"
        //    };

        //    return File(stream, mime, enableRangeProcessing: true);
        //}

        //[HttpGet("/video/subs")]
        //public IActionResult Subs(string path)
        //{
        //    if (!System.IO.File.Exists(path))
        //        return NotFound();

        //    var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
        //    return File(stream, "application/x-subrip");
        //}

        //TODO: SUBTITLES
    }
}
