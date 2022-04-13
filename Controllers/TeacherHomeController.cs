using Microsoft.AspNetCore.Mvc;

namespace mis_mmc.Controllers;

public class TeacherHomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}