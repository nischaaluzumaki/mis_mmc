using Microsoft.AspNetCore.Mvc;
using mis_mmc.Models;

namespace mis_mmc.Controllers;

public class AdminFacultyController : Controller
{
    private readonly DataContext _context;

    public AdminFacultyController(DataContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }
    private readonly IWebHostEnvironment _webHostEnvironment;
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
        var data = _context.FacultyModels.ToList();
        ViewBag.data = data;
        return View();
    }
    public IActionResult AddFaculty()
    {
        return View();
    }

   
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddFaculty(FacultyModel facultyModel, IFormFile file)
    {
        
        string folder = "file/";
        facultyModel.file = await UploadImage(folder, file);
        _context.FacultyModels.Add(facultyModel);
        _context.SaveChanges();
        return RedirectToAction("Index");
        
    }
    public async Task<IActionResult> UpdateFaculty(int id)
    {
        var facultyModel= await _context.FacultyModels.FindAsync(id);
        ViewBag.data = facultyModel;
        return View(facultyModel);
        TempData["ID"] = id;
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateFaculty( int id, FacultyModel facultyModel, IFormFile? file, string name, string description)
    {
        if (file == null)
        {
            
            var faculty = _context.FacultyModels.Where(f => f.s_no == id).FirstOrDefault();
            faculty.name = facultyModel.name;
            faculty.description = description;
            await _context.SaveChangesAsync();
          
        }
        else
        {


            string folder = "file/";
            facultyModel.file = await UploadImage(folder, file);
            _context.FacultyModels.Update(facultyModel);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index");
    }
    public IActionResult AppointHod()
    {
        return View();
    }
     public IActionResult UpdateHod()
        {
            return View();
        }

     public IActionResult DeleteFaculty(int id)
     {
         var data = _context.FacultyModels.Find(id);
         _context.FacultyModels.Remove(data);
         return RedirectToAction("Index");
     }
    
}