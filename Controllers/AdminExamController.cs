using Microsoft.AspNetCore.Mvc;

namespace mis_mmc.Controllers;

public class AdminExamController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult AddExam()
    {
        return View();
    }
    public IActionResult UpdateExam()
    {
        return View();
    }
}