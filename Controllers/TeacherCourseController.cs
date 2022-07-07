using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mis_mmc.Models;

namespace mis_mmc.Controllers;

public class TeacherCourseController : Controller
{
    private readonly DataContext _context;

    public TeacherCourseController(DataContext context)
    {
        _context = context;
       
    }
    // GET
    public IActionResult Index(int id)
    {
        var data = _context.CourseModels.Include(f=>f.ProgramModel).Where(x => x.tid.Equals(id)).ToList();
        ViewBag.data = data;
        return View();
    }

    public IActionResult StudentList(int id)
    {
        var sem = (_context.CourseModels.Where(x => x.s_no.Equals(id)).FirstOrDefault()
            .sem_year);
        /*var data = _context.CourseModels.Include(f => f.ProgramModel).Where(x => x.s_no.Equals(id)).FirstOrDefault()
            .ProgramModel.StudentModels.Where(x => x.sem_year.Equals(sem)).ToList();*/
        var pid = _context.CourseModels.Where(x => x.s_no.Equals(id)).FirstOrDefault()
            .pid;
        var data = _context.StudentModels.Where(x => x.pid == pid && x.sem_year == sem).ToList();
        ViewBag.data = data;
        ViewBag.coursename=_context.CourseModels.Where(x => x.s_no.Equals(id)).FirstOrDefault().name;
            
        return View();
    }
}