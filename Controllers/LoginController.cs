using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mis_mmc.Models;
using Newtonsoft.Json;

namespace mis_mmc.Controllers;

public class LoginController : Controller
{
    private readonly DataContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public LoginController(DataContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    // GET
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult LoginCheck(String email, String password)
    {

        var user_List = _context.LoginModels.Where(x => x.email.Equals(email)).Where(y => y.password.Equals(password))
            .ToList();



        if (user_List.Count() == 1 && user_List[0].password.Equals(password) && user_List[0].role.Equals("admin"))
        {
            //admin role
            //setting session using HttpContext

            HttpContext.Session.SetString("User",
                JsonConvert.SerializeObject(user_List[0])); //note argument should be in strings only.
            HttpContext.Session.SetString("Logged", "true");
            HttpContext.Session.SetString("password", password);
            HttpContext.Session.SetString("email", email);
            HttpContext.Session.SetString("role",user_List[0].role );

            return RedirectToAction("Index", "AdminHome");
        }
        else if (user_List.Count() == 1 && user_List[0].password.Equals(password) &&
                 user_List[0].role.Equals("student"))
        {

            HttpContext.Session.SetString("User",
                JsonConvert.SerializeObject(user_List[0])); //note argument should be in strings only.
            String id = _context.StudentModels.Where(x => x.email.Equals(user_List[0].email)).First().s_no.ToString();
            HttpContext.Session.SetString("id", id);
            HttpContext.Session.SetString("Logged", "true");
            HttpContext.Session.SetString("password", password);
            HttpContext.Session.SetString("email", email);
            HttpContext.Session.SetString("role",user_List[0].role );
            return RedirectToAction("Index", "StudentHome");
        }
        else if (user_List.Count() == 1 && user_List[0].password.Equals(password) &&
                 user_List[0].role.Equals("Teacher"))
        {

            HttpContext.Session.SetString("User",
                JsonConvert.SerializeObject(user_List[0])); //note argument should be in strings only.
            String id = _context.TeacherModels.Where(x => x.email.Equals(user_List[0].email)).First().s_no.ToString();
            HttpContext.Session.SetString("id", id);
            HttpContext.Session.SetString("Logged", "true");
            HttpContext.Session.SetString("password", password);
            HttpContext.Session.SetString("email", email);
            HttpContext.Session.SetString("role",user_List[0].role );
            return RedirectToAction("Index", "TeacherHome");
        }
         else if (user_List.Count() == 1 && user_List[0].password.Equals(password) &&
                         user_List[0].role.Equals("librarian"))
                {
        
                    HttpContext.Session.SetString("User",
                        JsonConvert.SerializeObject(user_List[0])); //note argument should be in strings only.
          
                    HttpContext.Session.SetString("Logged", "true");
                    HttpContext.Session.SetString("password", password);
                    HttpContext.Session.SetString("email", email);
                    HttpContext.Session.SetString("role",user_List[0].role );
                    return RedirectToAction("Index", "AdminLibrary");
                }




        else
        {
            TempData["error"] = "invalid credentials";
            return RedirectToAction("Login", "Login");   
        }
        

    }
    public IActionResult Logout()
    {
        HttpContext.Session.SetString("User", "null");
        HttpContext.Session.SetString("Logged", "null");
        return RedirectToAction("Login", "Login");
    }

}
