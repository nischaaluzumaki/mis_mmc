using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mis_mmc.Migrations;
using mis_mmc.Models;

namespace mis_mmc.Controllers;

public class TeacherLmsController : Controller
{

        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public TeacherLmsController(DataContext context, IWebHostEnvironment webHostEnvironment)
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
        }
    // GET
    public IActionResult Index(int id)
    {
        ViewData["Course"] = new SelectList(_context.Set<CourseModel>().Where(c=>c.tid.Equals(id)), "s_no", "name");
        ViewBag.data = _context.LmsModels.Include(x=>x.CourseModel).Where(x => x.tid.Equals(id)).OrderBy(x=>x.published_date).ToList();
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(int id, LmsModel lmsModel, IFormFile file )

    {
        string folder = "file/";
        lmsModel.tid = id;
        lmsModel.published_date=DateTime.Today;
        lmsModel.file = await UploadImage(folder, file);
        _context.LmsModels.Add(lmsModel);
        _context.SaveChanges();
        return RedirectToAction("Index");

    }
}