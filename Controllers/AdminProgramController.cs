using Microsoft.AspNetCore.Mvc;
using mis_mmc.Models;

namespace mis_mmc.Controllers;

public class AdminProgramController : Controller
{
    private readonly DataContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public AdminProgramController(DataContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }
    // GET
    public async Task<string> UploadImage(string folderpath, IFormFile file)
    {
        folderpath += file.FileName;
        string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderpath);
        await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
        return "/" + folderpath;
    }
    public IActionResult Index()
    {
        var data = _context.ProgramModels.ToList();
        ViewBag.data = data;
        return View();
    }
    public IActionResult AddProgram()
    {
        var data = _context.FacultyModels.ToList();
        ViewBag.data = data;
        
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddProgram(ProgramModel programModel, IFormFile file)
    {
        
        string folder = "file/";
        programModel.file = await UploadImage(folder, file);
        _context.ProgramModels.Add(programModel);
        _context.SaveChanges();
        return RedirectToAction("Index");
        
    }
    public IActionResult UpdateProgram()
    {
        return View();
    }
    public IActionResult AppointDirector()
    {
        return View();
    }
    public IActionResult UpdateDirector()
    {
        return View();
    }
}