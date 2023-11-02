using Microsoft.AspNetCore.Mvc;

namespace Web_MVC.Areas.Admin.Controllers;
[Area("admin")]
[Route("admin/dashboard")]
[Route("admin")]
public class DashboardController : Controller
{
    [Route("~/")]
    [Route("index")]
    public IActionResult Index()
    {
        return View("index");
    }
}
