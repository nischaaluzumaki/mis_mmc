using Microsoft.AspNetCore.Mvc;
using mis_mmc.Models;

namespace mis_mmc.Controllers;

public class BaseController : Controller
{


    public BaseController()
    {
        DataContext dal = new DataContext();
       

            if (HttpContext.Session.GetString("Logged") != null && HttpContext.Session.GetString("id")!= null)
            {
                string id=HttpContext.Session.GetString("id").ToString();
                if (HttpContext.Session.GetString("role") == "student")
                {
                    var user = dal.StudentModels.Find(id);
                    ViewBag.user = user;
                }
            }
           
        }
} 

