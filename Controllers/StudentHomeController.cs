using Microsoft.AspNetCore.Mvc;

namespace mis_mmc.Controllers;

public class StudentHomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}