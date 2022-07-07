using Microsoft.AspNetCore.Mvc;

namespace mis_mmc.Controllers;

public class StudentResultController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}