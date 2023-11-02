using Microsoft.AspNetCore.Mvc;
using Web_MVC.Models;
using Web_MVC.Services;

namespace Web_MVC.Areas.Admin.Controllers;
[Area("admin")]
[Route("admin/role")]
public class RoleController : Controller
{
	private RoleService roleService;
	public RoleController(RoleService roleService)
	{
		this.roleService = roleService;
	}

	[Route("")]
	[Route("index")]
	public IActionResult Index()
	{
		ViewBag.roles = roleService.findAll();
		return View("index");
	}


	[Route("add")]
	[HttpGet]
	public IActionResult Add()
	{
		var role = new Role();
		return View("index",role);
	}

	[Route("add")]
	[HttpPost]
	public IActionResult Add(Role role)
	{
		if (ModelState.IsValid)
		{
			if(roleService.create(role))
			{
				TempData["msg"] = "success";
				return RedirectToAction("index");
			}
			else
			{
				TempData["msg"] = "error";
				return RedirectToAction("add");
			}
		}
		else
		{
			return View("index");
		}
	}

}
