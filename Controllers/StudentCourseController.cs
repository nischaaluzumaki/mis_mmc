using Microsoft.AspNetCore.Mvc;

namespace mis_mmc.Controllers;

public class StudentCourseController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}