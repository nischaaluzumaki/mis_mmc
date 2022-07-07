using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
    public int Getid ()

    {

        Random r = new Random();
    
        return r.Next(10000,99999);
    
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
        facultyModel.uid = "mmcf" + Getid();
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
     public class Employee
        {
            public Employee(string name)
            {
                this.name = name;
            }
 
            public string name { get; set; }
            public List<Employee> Employees
            {
                get
                {
                    return EmployeesList;
                }
            }
 
            public void isEmployeeOf(Employee p)
            {
                EmployeesList.Add(p);
            }
 
            List<Employee> EmployeesList = new List<Employee>();
 
            public override string ToString()
            {
                return name;
            }
        }
 
        public class BreadthFirstAlgorithm
        {
            public Employee BuildEmployeeGraph()
            {
                Employee Eva = new Employee("Eva");
                Employee Sophia = new Employee("Sophia");
                Employee Brian = new Employee("Brian");
                Eva.isEmployeeOf(Sophia);
                Eva.isEmployeeOf(Brian);
 
                Employee Lisa = new Employee("Lisa");
                Employee Tina = new Employee("Tina");
                Employee John = new Employee("John");
                Employee Mike = new Employee("Mike");
                Sophia.isEmployeeOf(Lisa);
                Sophia.isEmployeeOf(John);
                Brian.isEmployeeOf(Tina);
                Brian.isEmployeeOf(Mike);
 
                return Eva;
            }
 
            public Employee Search(Employee root, string nameToSearchFor)
            {
                Queue<Employee> Q = new Queue<Employee>();
                HashSet<Employee> S = new HashSet<Employee>();
                Q.Enqueue(root);
                S.Add(root);
 
                while (Q.Count > 0)
                {
                    Employee e = Q.Dequeue();
                    if (e.name == nameToSearchFor)
                        return e;
                    foreach (Employee friend in e.Employees)
                    {
                        if (!S.Contains(friend))
                        {
                            Q.Enqueue(friend);
                            S.Add(friend);
                        }
                    }
                }
                return null;
            }
 
            public void Traverse(Employee root)
            {
                Queue<Employee> traverseOrder = new Queue<Employee>();
 
                Queue<Employee> Q = new Queue<Employee>();
                HashSet<Employee> S = new HashSet<Employee>();
                Q.Enqueue(root);
                S.Add(root);
 
                while (Q.Count > 0)
                {
                    Employee e = Q.Dequeue();
                    traverseOrder.Enqueue(e);
 
                    foreach (Employee emp in e.Employees)
                    {
                        if (!S.Contains(emp))
                        {
                            Q.Enqueue(emp);
                            S.Add(emp);
                        }
                    }
                }
 
                while (traverseOrder.Count > 0)
                {
                    Employee e = traverseOrder.Dequeue();
                    Console.WriteLine(e);
                }
            }
        }
 
        static void Main(string[] args)
        {
            BreadthFirstAlgorithm b = new BreadthFirstAlgorithm();
            Employee root = b.BuildEmployeeGraph();
            Console.WriteLine("Traverse Graph\n------");
            b.Traverse(root);
 
            Console.WriteLine("\nSearch in Graph\n------");
            Employee e = b.Search(root, "Eva");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
            e = b.Search(root, "Brian");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
            e = b.Search(root, "Soni");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
        }
    public IActionResult AppointHod()
    {
        
        return View();
    }
     public IActionResult UpdateHod()
        {
            return View();
        }
     [HttpPost]
     
     public IActionResult DeleteFaculty(int id)
     {
        var d = _context.FacultyModels.Find(id);
         _context.FacultyModels.Remove(d);
         _context.SaveChanges();
         return RedirectToAction("Index");
     }
    
}