using DocumentFormat.OpenXml.Office2010.Excel;
using System.Diagnostics;
using Web_MVC.Models;

namespace Web_MVC.Services.Impl;

public class DiscountImpl : DiscountService
{
	private DatabaseContext db;
	public DiscountImpl(DatabaseContext db)
	{
		this.db = db;
	}

	public bool create(Discount discount)
	{
		try
		{
			db.Discounts.Add(discount);
			return db.SaveChanges() > 0;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			return false;
		}
	}

	public bool delete(int id)
	{
		try
		{
			db.Discounts.Remove(db.Discounts.Find(id));
			return db.SaveChanges() > 0;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			return false;
		}
	}

	public List<Discount> findAll()
	{
		try
		{
			return db.Discounts.ToList();
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			return null;
		}
	}

	public Discount findById(int id)
	{
		try
		{
			return db.Discounts.FirstOrDefault(x => x.Id==id);
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			return null;
		}
	}

	public List<Discount> findByString(string name)
	{
		try
		{
			return db.Discounts.Where(x => x.Description.ToLower().Contains(name.ToLower())).ToList();
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			return null;
		}
	}

	public bool update(Discount discount)
	{
		try
		{
			db.Entry(discount).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			return db.SaveChanges() > 0;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			return false;
		}
	}
}
