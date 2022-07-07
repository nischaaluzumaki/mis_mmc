using Microsoft.AspNetCore.Mvc;

namespace mis_mmc.Controllers;

public class TeacherAssignmentController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}