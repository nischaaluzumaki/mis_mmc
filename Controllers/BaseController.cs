using Microsoft.AspNetCore.Mvc;

namespace mis_mmc.Controllers;

public class BaseController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}