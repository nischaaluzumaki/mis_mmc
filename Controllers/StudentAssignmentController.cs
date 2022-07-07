using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mis_mmc.Models;

namespace mis_mmc.Controllers;

public class StudentAssignmentController : Controller
{
    private readonly DataContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public StudentAssignmentController(DataContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<string> UploadImage(string folderpath, IFormFile file)
    {
        folderpath += file.FileName;
        string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderpath);
        await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
        return "/" + folderpath;
    } // GET // GET

    public IActionResult Index(int? id)
    {


        var uid = int.Parse(HttpContext.Session.GetString("id"));
        var sem = _context.StudentModels.Where(d => d.s_no == uid).First().sem_year;
        var pid = _context.StudentModels.Where(d => d.s_no == uid).First().sem_year;
        var data = _context.AssignmentModels.Include(c => c.CourseModel).Include(c => c.TeacherModel).Where(c =>
            c.cid == id).ToList();
        ViewBag.data = data;
       
        var dataf = _context.AssignmentReturnModels.Include(c => c.AssignmentModel).Include(c => c.TeacherModel).Where(c =>
            c.cid == id).ToList();
        ViewBag.dataf = dataf;
        return View();
    }

    public IActionResult ReturnAssignment(int id)
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ReturnAssignment(int id, AssignmentReturnModel assignmentReturnModel,
        IFormFile file)

    {
        var tid = _context.AssignmentModels.Include(p => p.TeacherModel).Where(p => p.s_no == id).First()
            .tid;
        var cid = _context.AssignmentModels.Include(p => p.TeacherModel).Where(p => p.s_no == id).First()
            .cid;
        string folder = "file/";
        assignmentReturnModel.aid = id;
        assignmentReturnModel.return_date = DateOnly.FromDateTime(DateTime.Today);
        assignmentReturnModel.tid = tid;
        assignmentReturnModel.cid = cid;
        assignmentReturnModel.sid = int.Parse(HttpContext.Session.GetString("id"));
        assignmentReturnModel.file = await UploadImage(folder, file);
        assignmentReturnModel.is_checked = false;
        
        /*if (tid != null)
        {
            assignmentReturnModel.tid = tid;
        }*/

        _context.AssignmentReturnModels.Add(assignmentReturnModel);
        _context.SaveChanges();
        return RedirectToAction("Index", new { id = cid});
    
    }

}