using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
    public int Getid ()

    {

        Random r = new Random();
    
        return r.Next(10000,99999);
    
    }
    public IActionResult Index()
    {
        var data = _context.ProgramModels.Include(f=>f.FacultyModel).ToList();
        ViewBag.data = data;
        return View();
    }
    public IActionResult AddProgram()
    {
        var data = _context.FacultyModels.ToList();
        ViewBag.data = data;
        ViewData["Faculty"] = new SelectList(_context.Set<FacultyModel>(), "s_no", "name");
        
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddProgram(ProgramModel programModel, IFormFile file)
    {
        
        string folder = "file/";
        programModel.file = await UploadImage(folder, file);
        programModel.uid = "mmcp" + Getid();
        _context.ProgramModels.Add(programModel);
        _context.SaveChanges();
        return RedirectToAction("Index");
        
    }
    public async Task<IActionResult> UpdateProgram(int id)
    {
        var programModel= await _context.ProgramModels.FindAsync(id);
        ViewBag.data = programModel;
        ViewData["Faculty"] = new SelectList(_context.Set<FacultyModel>(), "s_no", "name");
        return View(programModel);
        
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateProgram(int id, ProgramModel programModel, IFormFile? file)
    {
        if (file == null)
        {
            
            var program = _context.ProgramModels.Where(p => p.s_no == id).FirstOrDefault();
            program.name = programModel.name;
            program.description = programModel.description;
            program.sem_year = programModel.sem_year;
            program.type = programModel.type;
            program.FacultyModel = programModel.FacultyModel;
           
            await _context.SaveChangesAsync();
          
        }
        else
        {


            string folder = "file/";
            programModel.file = await UploadImage(folder, file);
            _context.ProgramModels.Update(programModel);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index"); 
    }

    public IActionResult DeleteProgram(int id)
    {
        var data = _context.ProgramModels.Find(id);
        _context.ProgramModels.Remove(data);
        _context.SaveChanges();
        return RedirectToAction("Index");
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