using Microsoft.AspNetCore.Mvc;

namespace mis_mmc.Controllers;

public class AdminTeacherController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult AddTeacher()
    {
        return View();
    }
    public IActionResult UpdateTeacher()
    {
        return View();
    }
}