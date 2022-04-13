﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mis_mmc.Models;

namespace mis_mmc.Controllers;

public class AdminHomeController : Controller
{
    private readonly ILogger<AdminHomeController> _logger;

    public AdminHomeController(ILogger<AdminHomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}