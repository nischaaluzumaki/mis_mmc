using Microsoft.AspNetCore.Mvc;

namespace mis_mmc.Controllers;

public class TeacherLmsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}