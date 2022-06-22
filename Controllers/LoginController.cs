using Microsoft.AspNetCore.Mvc;

namespace mis_mmc.Controllers;

public class LoginController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}