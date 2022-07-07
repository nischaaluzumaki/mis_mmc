using Microsoft.AspNetCore.Mvc;
using mis_mmc.Models;

namespace mis_mmc.Controllers;

public class StudentResultController : Controller
{
    
    private readonly DataContext _context;

    public StudentResultController(DataContext context)
    {
        _context = context;
       
    }
    // GET
    public IActionResult Index(int id)
    {
        var sem = _context.StudentModels.Where(c => c.s_no == id).First().sem_year;
        var pid = _context.StudentModels.Where(c => c.s_no == id).First().pid;
        ViewBag.data = _context.ExamModels.ToList();
        return View();
    }

    public IActionResult Result(int id)
    {
        return View();
    }
}