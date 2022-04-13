using Microsoft.AspNetCore.Mvc;

namespace mis_mmc.Controllers;

public class AdminLibraryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult AddBook()
    {
        return View();
    }
    public IActionResult UpdateBook()
    {
        return View();
    }
}