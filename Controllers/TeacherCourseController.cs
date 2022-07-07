using Microsoft.AspNetCore.Mvc;

namespace mis_mmc.Controllers;

public class TeacherCourseController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}