using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PlantNestBackEnd.Helpers;
using Web_MVC.Models;
using Web_MVC.Services;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;


namespace Web_MVC.Areas.Admin.Controllers;
[Area("admin")]
[Route("admin/category")]
public class CategoryController : Controller
{
	private CategoryService categoryService;
	private IWebHostEnvironment environment;

	public CategoryController(IWebHostEnvironment environment, CategoryService categoryService)
	{
		this.environment = environment;
		this.categoryService = categoryService;
	}
	[Route("")]
	[Route("index")]
	public IActionResult Index()
	{
        //int pageSize = 5;
        ViewBag.categories = categoryService.findAll();
		return View("index");
	}


	[Route("add")]
	[HttpGet]
	public IActionResult IndexAdd()
	{
		var category = new Category();
		return View("add", category);
	}

	[Route("add")]
	[HttpPost]
	public IActionResult Add(Category category, IFormFile Images)
	{

		if (Images == null)
		{
			TempData["error-image"] = "The Image is required";
			TempData["msg"] = "error";
			return RedirectToAction("add");


		}
		else if (category.Name == null || category.Name.Length > 255)
		{
			TempData["error-name"] = "The name is required and length";
			TempData["msg"] = "error";
			return RedirectToAction("add");
		}
		else
		{
			string[] fileExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
			var check = fileExtensions.Contains(Path.GetExtension(Images.FileName).ToLowerInvariant());
			if (check)
			{
				var fileName = FileHelper.generateFileName(Images.FileName);
				var path = Path.Combine(environment.WebRootPath, "imagesCategory", fileName);
				using (var fileStream = new FileStream(path, FileMode.Create))
				{
					Images.CopyTo(fileStream);
				}
				category.Images = fileName;
				category.CreateAt = DateTime.Now;
				category.UpdateAt = DateTime.Now;
				if (categoryService.create(category))
				{
					TempData["msg"] = "success";
					return RedirectToAction("add");
				}
				else
				{
					TempData["msg"] = "error";
					return RedirectToAction("add");
				}
			}
			else
			{
				TempData["error-image"] = "The Image extension is not allowed";
				TempData["msg"] = "error";

				return RedirectToAction("add");
			}
		}


	}
	[Route("delete/{id}")]
	[HttpGet]
	public IActionResult Delete(int id)
	{

		if (categoryService.delete(id))
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
		var categoryDB = categoryService.findById(id);
		ViewBag.value = categoryDB.Id;
		var category = new Category();
		category.Name = categoryDB.Name;
		category.UpdateAt = categoryDB.UpdateAt;
		category.CreateAt = categoryDB.CreateAt;
		category.Images = categoryDB.Images;
		category.Description = categoryDB.Description;
		ViewBag.category = category;
		return View("update", category);
	}
	[Route("updatesave")]
	[HttpPost]
	public IActionResult UpdateSave(Category category, int value, IFormFile Images)
	{
		var categoryCheck = categoryService.findById(value);
		if (category.Name == null || category.Name.Length > 255)
		{
			TempData["error-name"] = "The name is required and length under 255 char";
			TempData["msg"] = "error";
			return RedirectToAction("update", new { id = value });
		}
		else if (Images != null)
		{
			string[] fileExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
			var check = fileExtensions.Contains(Path.GetExtension(Images.FileName).ToLowerInvariant());
			if (check)
			{

				var fileName = FileHelper.generateFileName(Images.FileName);
				var path = Path.Combine(environment.WebRootPath, "imagesCategory", fileName);
				using (var fileStream = new FileStream(path, FileMode.Create))
				{
					Images.CopyTo(fileStream);

				}
				var path2 = Path.Combine(environment.WebRootPath, "imagesCategory", categoryCheck.Images);
				System.IO.File.Delete(path2);
				category.Images = fileName;
			}
			else
			{
				TempData["error-image"] = "The Image extension is not allowed";
				TempData["msg"] = "error";

				return RedirectToAction("update", new { id = value });
			}
		}
		else if (Images == null)
		{
			category.Images = categoryCheck.Images;
		}
		category.UpdateAt = DateTime.Now;
		if (categoryService.update(category, value))
		{
			TempData["msg"] = "success";
			return RedirectToAction("index");
		}
		else
		{
			TempData["msg"] = "error";
			return RedirectToAction("update", new { id = value });
		}
	}

}
