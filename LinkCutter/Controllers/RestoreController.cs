using LinkCutter.Database.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LinkCutter.Controllers;

public class RestoreController : Controller
{
    private readonly LinkRepository _repository;

    public RestoreController(LinkRepository repository)
    {
        _repository = repository;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> RestoreLink(string? linkToRestore)
    {
        if (linkToRestore == null)
            return View("index");
        
        var cut = linkToRestore.Split('/');
        
        var linkId = CutterService.FromShort(cut.Last());

        if (linkId == 0)
        {
            ViewData["FullLink"] = "invalid link";
            return View("index");
        }
        
        var link = await _repository.GetLinkById(linkId);
        ViewData["FullLink"] = link?.FullLink;

        return View("index");
    }
}