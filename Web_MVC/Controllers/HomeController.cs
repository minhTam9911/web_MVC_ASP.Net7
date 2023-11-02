using Microsoft.AspNetCore.Mvc;

namespace Web_MVC.Controllers;
[Route("")]
[Route("home")]
public class HomeController : Controller
{
    [Route("index")]
    //[Route("~/")]
    public IActionResult Index()
    {
        return View("index");
    }
}
