using Microsoft.AspNetCore.Mvc;

namespace mis_mmc.Controllers;

public class AdminNtStaffsController : Controller
{
    
    // GET
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult AddNtStaffs()
    {
        return View();
    }
    public IActionResult UpdateNtStaffs()
    {
        return View();
    }
}