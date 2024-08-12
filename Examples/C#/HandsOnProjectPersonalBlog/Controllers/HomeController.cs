using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HandsOnProjectPersonalBlog.Models;
using HandsOnProjectPersonalBlog.Interfaces;
using HandsOnProjectPersonalBlog.Attributes;

namespace HandsOnProjectPersonalBlog.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPostRepository _postRepository;

    public HomeController(ILogger<HomeController> logger, IPostRepository postRepository)
    {
        _logger = logger;
        _postRepository = postRepository;
    }

    public async Task<IActionResult> Index()
    {
        _logger.Log(LogLevel.Error, "Something went wrong...");
        
        var allRows = await _postRepository.GetAll();
        return View(allRows);
    }

    [HttpGet]
    [ServiceFilter(typeof(ProtectorAttribute))]
    public async Task<IActionResult> CreatePost(Post post)
    {
        return View(post);
    }

    [HttpPost]
    [ServiceFilter(typeof(ProtectorAttribute))]
    public async Task<IActionResult> Post(Post post)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("Validation", "Please provide all values");
            return View(post);
        }

        await _postRepository.Create(post);
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
