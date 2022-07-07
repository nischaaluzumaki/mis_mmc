using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mis_mmc.Models;

namespace mis_mmc.Controllers;

public class AdminExamController : Controller
{
    private readonly DataContext _context;

    public AdminExamController(DataContext context)
    {
        _context = context;
       
    }
    // GET
    public IActionResult Index()
    {
        var data = _context.ExamModels.Include(f=> f.ProgramModel).ToList();
        ViewBag.data = data;
        
        return View();
        
    }
    public IActionResult AddExam()
    {
        ViewData["Program"] = new SelectList(_context.Set<ProgramModel>(), "s_no", "name");
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddExam(ExamModel examModel, string start_date, string end_date)
    {

        examModel.start_date = DateOnly.Parse(start_date);
        examModel.end_date = DateOnly.Parse(end_date);
        _context.ExamModels.Add(examModel);
        _context.SaveChanges();
        return RedirectToAction("Index");

    }
    public IActionResult ExamDetails(int id)
    {
        var sem = int.Parse(_context.ExamModels.FirstOrDefault(f => f.s_no == id).sem_year);
        var startdate=_context.ExamModels.FirstOrDefault(f => f.s_no == id).start_date;
        var enddate = _context.ExamModels.FirstOrDefault(f => f.s_no == id).end_date;
        var program = _context.ExamModels.FirstOrDefault(f => f.s_no == id).pid;
        ViewBag.start = startdate;
        ViewBag.end = enddate;
        var data = _context.ExamDetailsModels.Include(f=> f.ExamModel).Include(f=>f.CourseModel).ToList();
        ViewBag.data = data;
        ViewData["Course"] = new SelectList(_context.Set<CourseModel>().Where(f=>f.sem_year==sem && f.pid==program ), "s_no", "name");
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult>ExamDetails(int id, ExamDetailsModel examDetailsModel, string exam_date, string time)
    {
        examDetailsModel.exam_date = DateOnly.Parse(exam_date);
        examDetailsModel.time = TimeOnly.Parse(time);
        examDetailsModel.eid = id;
        _context.ExamDetailsModels.Add(examDetailsModel);
        _context.SaveChanges();
        return RedirectToAction("ExamDetails");

    }
    public IActionResult UpdateExam()
    {
        return View();
    }

    public IActionResult PublishRoutine()
    {
        return View();
    }
}