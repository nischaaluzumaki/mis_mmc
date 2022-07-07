using Microsoft.AspNetCore.Mvc;
using mis_mmc.Models;

namespace mis_mmc.Controllers;

public class StudentCourseController : Controller
{
    private readonly DataContext _context;

    public StudentCourseController(DataContext context)
    {
        _context = context;
       
    }
    // GET
    public IActionResult Index(int id)
    {
        var pid = _context.StudentModels.Where(d => d.s_no == id).First().pid;
        var sem = _context.StudentModels.Where(d => d.s_no == id).First().sem_year;
        var data = _context.CourseModels.Where(t => t.pid == pid && t.sem_year == sem).ToList();
        ViewBag.data = data;
        
        return View();
    }
}