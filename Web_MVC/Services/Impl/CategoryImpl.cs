using System;
using System.Diagnostics;
using Web_MVC.Models;

namespace Web_MVC.Services.Impl;

public class CategoryImpl : CategoryService
{
	private DatabaseContext db;
	private IWebHostEnvironment environment;
	public CategoryImpl(DatabaseContext db, IWebHostEnvironment environment)
	{
		this.db = db;
		this.environment = environment;

	}
	public bool create(Category category)
	{
		try
		{
			db.Categories.Add(category);
			return db.SaveChanges() > 0;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			return false;
		}
	}

	public bool delete(int id)
	{
		try
		{
			var data = db.Categories.Find(id);
			var path = Path.Combine(environment.WebRootPath, "imagesCategory", data.Images);
			System.IO.File.Delete(path);
			db.Categories.Remove(data);
			return db.SaveChanges() > 0;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			return false;
		}
	}

	public List<Category> findAll(int page)
	{
		var pageSize = 10;
		var categoryList = db.Categories.ToList();
		var categoryCount = categoryList.Count;
		var totalPages = (int)Math.Ceiling((decimal)categoryCount / pageSize);
		var perPage = categoryList.Skip((page - 1) * pageSize).Take(pageSize).ToList();


		return perPage;
	}

	public List<Category> findAll()
	{
		return db.Categories.ToList();
	}

	public Category findById(int id)
	{
		return db.Categories.FirstOrDefault(x => x.Id == id);
	}

	public List<Category> findByString(string name)
	{
		return db.Categories.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
	}

	public bool update(Category category, int value)
	{
		var input = findById(value);
		input.UpdateAt = category.UpdateAt;
		input.CreateAt = category.CreateAt;
		input.Description = category.Description;
		input.Images = category.Images;
		input.Name = category.Name;
		try
		{
			db.Entry(input).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			return db.SaveChanges() > 0;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			return false;
		}
	}
}
