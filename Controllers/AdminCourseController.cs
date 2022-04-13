using Microsoft.AspNetCore.Mvc;

namespace mis_mmc.Controllers;

public class AdminCourseController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
     public IActionResult AddCourse()
        {
            return View();
        }
     public IActionResult UpdateCourse()
     {
         return View();
     }
     public IActionResult AppointLecturer()
     {
         return View();
     }
     public IActionResult UpdateLecturer()
     {
         return View();
     }
     
}