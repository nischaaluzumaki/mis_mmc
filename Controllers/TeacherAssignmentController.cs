using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mis_mmc.Models;

namespace mis_mmc.Controllers;

public class TeacherAssignmentController : Controller
{
    private readonly DataContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public TeacherAssignmentController(DataContext context, IWebHostEnvironment webHostEnvironment)
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
    }// GET
    public IActionResult Index(int id)
    {
        ViewBag.data = _context.AssignmentModels.Include(c => c.CourseModel).Include(c => c.TeacherModel)
            .Where(x => x.tid.Equals(id)).OrderBy(x => x.published_date);
        ViewData["Course"] = new SelectList(_context.Set<CourseModel>().Where(c=>c.tid.Equals(id)), "s_no", "name");

         return View();

    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(int id, AssignmentModel assignmentModel, IFormFile file, string due_date )

    {
        string folder = "file/";
        assignmentModel.tid = id;
        assignmentModel.published_date = DateOnly.FromDateTime(DateTime.Today);
        assignmentModel.due_date = DateOnly.Parse(due_date);
        assignmentModel.file = await UploadImage(folder, file);
        _context.AssignmentModels.Add(assignmentModel);
        _context.SaveChanges();
        return RedirectToAction("Index");
        

    }
}