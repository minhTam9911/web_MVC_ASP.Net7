using Microsoft.AspNetCore.Mvc;
using Web_MVC.Models;
using Web_MVC.Services;

namespace Web_MVC.Areas.Admin.Controllers;
[Area("admin")]
[Route("admin/discount")]
public class DiscountController : Controller
{

	private DiscountService discountService;
	public DiscountController(DiscountService discountService)
	{
		this.discountService = discountService;
	}

	[Route("")]
	[Route("index")]
	public IActionResult Index()
	{
		ViewBag.discounts = discountService.findAll();
		return View("index");
	}

	[Route("add")]
	[HttpGet]
	public IActionResult Add()
	{
		var discount = new Discount();
		discount.StartTime= DateTime.Now;
		discount.EndTime = DateTime.Now;
		return View("add",discount);
	}

	[Route("add")]
	[HttpPost]
	public IActionResult Add(Discount discount)
	{
		if(discount.Precent <= 0)
		{
			ModelState.AddModelError("Precent", "The reduced price must be greater than 0");
		}
		if (ModelState.IsValid)
		{
			if (DateTime.Compare(discount.StartTime, discount.EndTime)>0)
			{
				ModelState.AddModelError("EndTime", "Invalid end time");
				TempData["msg"] = "error";
				return View("add");
			}
			else
			{
				if (discountService.create(discount))
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
		}
		else
		{
			return View("add");
		}
		
	}

	[Route("delete/{id}")]
	[HttpGet]
	public IActionResult Delete(int id)
	{
		if (discountService.delete(id))
		{
			TempData["msg"] = "success";
			return RedirectToAction("index");
		}
		else
		{
			TempData["msg"] = "error";
			return RedirectToAction("index");
		}
	}

	[Route("update/{id}")]
	[HttpGet]
	public IActionResult Update(int id)
	{
		var discount = discountService.findById(id);
		discount.StartTime.ToString("dd/MM/yyyy HH:mm:ss");
		discount.EndTime.ToString("dd/MM/yyyy HH:mm:ss");
		return View("update", discount);
	}


	[Route("updateSave")]
	[HttpPost]
	public IActionResult UpdateSave(Discount discount)
	{
		if (discount.Precent <= 0)
		{
			ModelState.AddModelError("Precent", "The reduced price must be greater than 0");
		}
		if (ModelState.IsValid)
		{
			if (DateTime.Compare(discount.StartTime, discount.EndTime) > 0)
			{
				ModelState.AddModelError("EndTime", "Invalid end time");
				TempData["msg"] = "error";
				return RedirectToAction("update", new {Id = discount.Id});
			}
			else
			{
				if (discountService.update(discount))
				{
					TempData["msg"] = "success";
					return RedirectToAction("index");
				}
				else
				{
					TempData["msg"] = "error";
					return RedirectToAction("update", new { Id = discount.Id });
				}
			}
		}
		else
		{
			return RedirectToAction("update", new { Id = discount.Id });
		}

	}


}
