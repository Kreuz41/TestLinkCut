using LinkCutter.Database;
using LinkCutter.Database.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LinkCutter.Controllers;

public class CutterController : Controller
{
    private readonly LinkRepository _repository;

    public CutterController(LinkRepository repository)
    {
        _repository = repository;
    }
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> CutLink(string linkToCut)
    {
        var link = await _repository.GetLinkByUrl(linkToCut) ?? await _repository.InsertLink(linkToCut);
        ViewData["ShortLink"] = CutterService.ToShort(link.Id);

        return View("index");
    }
}