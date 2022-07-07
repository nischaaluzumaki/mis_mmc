using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mis_mmc.Models;

using Microsoft.AspNetCore.Mvc;

namespace mis_mmc.Controllers;

public class AdminCourseController : Controller
{
    private readonly DataContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public AdminCourseController(DataContext context, IWebHostEnvironment webHostEnvironment)
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
    public int Getid ()

    {

        Random r = new Random();
    
        return r.Next(10000,99999);
    
    }
    public IActionResult Index()
    {
        var data = _context.CourseModels.Include(f=>f.ProgramModel).ToList();
        ViewBag.data = data;
       
        return View();
    }
     public IActionResult AddCourse()
        {
            var data = _context.ProgramModels.ToList();
            ViewBag.data = data;
            ViewData["Program"] = new SelectList(_context.Set<ProgramModel>(), "s_no", "name");
        
            return View();
           
        }

     [HttpPost]
     [ValidateAntiForgeryToken]
     public async Task<IActionResult> AddCourse(CourseModel courseModel, IFormFile file)
     {
         string folder = "file/";
         courseModel.uid = "mmcs" + Getid().ToString();
         _context.CourseModels.Add(courseModel);
         _context.SaveChanges();
         return RedirectToAction("Index");
     }
     public async  Task<IActionResult> UpdateCourse( int id)
     {
         var courseModel= await _context.CourseModels.FindAsync(id);
         ViewBag.data = courseModel;
         ViewData["Program"] = new SelectList(_context.Set<ProgramModel>(), "s_no", "name");
         return View(courseModel);
         
     }
     [HttpPost]
     [ValidateAntiForgeryToken]
     public async Task<IActionResult> UpdateCourse(int id, CourseModel courseModel, IFormFile file)
     {
         if (file == null)
         {
            
             var course = _context.CourseModels.Where(p => p.s_no == id).FirstOrDefault();
             course.name = courseModel.name;
             course.description = courseModel.description;
             course.sem_year = courseModel.sem_year;
             course.ProgramModel = courseModel.ProgramModel;
           
             await _context.SaveChangesAsync();
          
         }
         else
         {


             string folder = "file/";
             courseModel.file = await UploadImage(folder, file);
             _context.CourseModels.Update(courseModel);
             await _context.SaveChangesAsync();
         }

         return RedirectToAction("Index"); 
     }

     public IActionResult DeleteCourse(int id)
     {
         var data = _context.CourseModels.Find(id);
         _context.CourseModels.Remove(data);
         _context.SaveChanges();
         return RedirectToAction("Index");
     }
     public IActionResult AppointLecturer()
     {
         return View();
     }

     [HttpPost]
     [ValidateAntiForgeryToken]
     public async Task<IActionResult> AppointLecturer(string course, string teacher)
     {
         string tid = _context.TeacherModels.Where(x => x.uid.Equals(teacher)).First().s_no.ToString();
         string tname = _context.TeacherModels.Where(x => x.uid.Equals(teacher)).First().name.ToString();
         string cid = _context.CourseModels.Where(x => x.uid.Equals(course)).First().s_no.ToString();
         var c = _context.CourseModels.Where(p => p.s_no.ToString() == cid).FirstOrDefault();
         c.tid = int.Parse(tid);
         c.lecturer = tname;
         await _context.SaveChangesAsync();
         return RedirectToAction("Index"); 
     }
     public IActionResult UpdateLecturer()
     {
         return View();
     }
     
}