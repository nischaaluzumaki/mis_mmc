using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Diagnostics;
using mis_mmc.Models;

namespace mis_mmc.Controllers;

public class AdminStudentController : Controller
{
    private readonly DataContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public AdminStudentController(DataContext context, IWebHostEnvironment webHostEnvironment)
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
    }

    // GET
    public IActionResult Index()
    {
        var data = _context.StudentModels.ToList();
        ViewBag.data = data;
        return View();
    }

    public IActionResult AddStudent()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddStudent(StudentModel studentModel, IFormFile file, string password)
    {

        string folder = "file/";
        int num = Getid();
        string uid = "mmcs" + num.ToString();
       
        LoginModel login = new LoginModel()
        {

            email = studentModel.email,
            password = password,
            role = "student",

        };
        if (_context.StudentModels.Any(o => o.uid == uid))
        {
            int n = Getid();
            string newid = "mmcs" + n.ToString(); 
        }
        else
        {
            string newid = uid;
        }

        
        StudentModel student = new StudentModel()
        {
            name = studentModel.name,
            email = studentModel.email,
            address = studentModel.address,
            dob = studentModel.dob,
            gender = studentModel.gender,
            phone = studentModel.phone,
            uid="mmcs" + Getid().ToString(), 
            file = await UploadImage(folder, file),
            is_admitted = false

        };
        _context.LoginModels.Add(login);
        _context.StudentModels.Add(student);
        _context.SaveChanges();
        return RedirectToAction("Index");

    }

    public IActionResult UpdateStudent()
    {
        return View();
    }

    public IActionResult Admission()
    {
        var data = _context.StudentModels.ToList();
        ViewBag.data = data;
        var program = _context.ProgramModels.ToList();
        ViewBag.program = program;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Admission(string student, string program, int sem_year)
    {
        string sid = _context.StudentModels.Where(x => x.email.Equals(student)).First().s_no.ToString();
        string pid = _context.ProgramModels.Where(x => x.name.Equals(program)).First().s_no.ToString();
        var st = _context.StudentModels.Where(p => p.s_no.ToString() == sid).FirstOrDefault();
        st.is_admitted = true;
        st.pid = int.Parse(pid);
        st.sem_year = sem_year;
        await _context.SaveChangesAsync();
        return RedirectToAction(("Index"));
    }
}

