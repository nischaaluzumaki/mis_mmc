using Microsoft.AspNetCore.Mvc;

namespace mis_mmc.Controllers;

public class AdminStudentController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult AddStudent()
    {
        return View();
    }
    public IActionResult UpdateStudent()
    {
        return View();
    }
}