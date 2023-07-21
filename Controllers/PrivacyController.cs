using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP_Learning_1.Models;

namespace ASP_Learning_1.Controllers;

[ApiController]
[Route("[controller]")]

public class PrivacyController : Controller
{
    private readonly ILogger<PrivacyController> _logger;

    public PrivacyController(ILogger<PrivacyController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult Privacy()
    {
        return View();
    }
}