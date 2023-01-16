using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc1.Models;

namespace mvc1.Controllers;

public class HomeController : Controller
{
    private readonly IRepository repository;
     private string message;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, IRepository repository, IConfiguration config)
    {
        _logger = logger;
        this.repository = repository;
        message = $"Docker - ({config["HOSTNAME"]})";
    }

   public IActionResult Index()
        {
            ViewBag.Message = message;
            return View(repository.GetProdutos);
        }
}
