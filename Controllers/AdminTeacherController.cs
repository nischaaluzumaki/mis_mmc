using Microsoft.AspNetCore.Mvc;
using mis_mmc.Models;

namespace mis_mmc.Controllers;

public class AdminTeacherController : Controller
{
    private readonly DataContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public AdminTeacherController(DataContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }
    public int Getid ()

    {

        Random r = new Random();
    
        return r.Next(10000,99999);
    
    }
    // GET
    public async Task<string> UploadImage(string folderpath, IFormFile file)
    {
        folderpath += file.FileName;
        string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderpath);
        await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
        return "/" + folderpath;
    } // GET
    public IActionResult Index()
    {
        var data = _context.TeacherModels.ToList();
        ViewBag.data = data;
        return View();
    }
    public IActionResult AddTeacher()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddTeacher(TeacherModel teacherModel, IFormFile file, string password)
    {

        string folder = "file/";
        LoginModel login = new LoginModel()
        {

            email = teacherModel.email,
            password = password,
            role = "Teacher",
            
        };
        TeacherModel teacher = new TeacherModel()
        {
            name = teacherModel.name,
            email = teacherModel.email,
            address = teacherModel.address,
            dob = teacherModel.dob,
            gender = teacherModel.gender,
            phone = teacherModel.phone,
            uid="mmct" + Getid().ToString(), 
            file = await UploadImage(folder, file)

        };
        _context.LoginModels.Add(login);
        _context.TeacherModels.Add(teacher);
        _context.SaveChanges();
        return RedirectToAction("Index");

    }
    
    public IActionResult UpdateTeacher()
    {
        return View();
    }
}