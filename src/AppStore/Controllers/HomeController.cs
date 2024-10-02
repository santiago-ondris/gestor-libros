using AppStore.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Appstore.Controllers;

public class HomeController : Controller
{
    private readonly ILibroService _libroService;
    public HomeController(ILibroService libroService)
    {
        _libroService = libroService;
    }
    public IActionResult Index(string term="", int currentPage = 1)
    {
        var libroListVm = _libroService.List(term, true, currentPage);
        return View(libroListVm);
    }
    public IActionResult LibroDetail(int libroId)
    {
        var libro =_libroService.GetById(libroId);
        return View(libro);
    }
    public IActionResult About()
    {
        return View();
    }
}