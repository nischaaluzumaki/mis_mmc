using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mis_mmc.Models;

namespace mis_mmc.Controllers;

public class AdminLibraryController : Controller
{
    private readonly DataContext _context;

    public AdminLibraryController(DataContext context)
    {
        _context = context;
       
    }
    public int Getid ()

    {

        Random r = new Random();
    
        return r.Next(10000,99999);
    
    }
    // GET
    public IActionResult Index()
    {
        var data = _context.BookModels.ToList();
        ViewBag.data = data;
        return View();
        
    }
    public IActionResult AddBook()
    {
        var data = _context.ProgramModels.ToList();
        ViewBag.data = data;
        ViewData["Program"] = new SelectList(_context.Set<ProgramModel>(), "s_no", "name");

        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddBook(BookModel bookModel)
    {


        _context.BookModels.Add(bookModel);
        _context.SaveChanges();
        return RedirectToAction("Index");

    }
    public IActionResult UpdateBook()
    {
        return View();
    }
    public IActionResult IssueBook()
    {
        var data = _context.StudentModels.ToList();
        ViewBag.data = data;
        var book = _context.BookModels.ToList();
        ViewBag.book = book;
      
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> IssueBook(string student, string book, string expiry_date, string uid)
    {
        string sid = _context.StudentModels.Where(x => x.email.Equals(student)).First().s_no.ToString();
        string bid = _context.BookModels.Where(x => x.name.Equals(book)).First().s_no.ToString();
        
        var bk = _context.BookModels.Where(p => p.s_no.ToString() == bid).FirstOrDefault();
        bk.is_issued=true;
        bk.stock-=1;
       
        BookIssueModel issue = new BookIssueModel()
        {
            sid = int.Parse(sid),
            bid=int.Parse(bid),
            issued_date = DateOnly.FromDateTime(DateTime.Now),
            uid=uid, 
            expiry_date=DateOnly.Parse(expiry_date),
            is_returned=false


        };
         _context.BookIssueModels.Add(issue);
        
        await _context.SaveChangesAsync();
        return RedirectToAction(("Index"));
    }
    public IActionResult IssueDetails()
    {
        var data = _context.BookIssueModels.Include(f=>f.BookModel).Include(f=>f.StudentModel).ToList();
        ViewBag.data = data;
        return View();
    }

    public IActionResult IssueStudents(int id)
    {
        return View();
    }
}