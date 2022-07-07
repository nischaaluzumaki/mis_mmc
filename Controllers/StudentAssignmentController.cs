using Microsoft.AspNetCore.Mvc;

namespace mis_mmc.Controllers;

public class StudentAssignmentController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}