using System.Diagnostics;
using Web_MVC.Models;

namespace Web_MVC.Services.Impl;

public class RoleImpl : RoleService
{
	private DatabaseContext db;
	public RoleImpl(DatabaseContext db)
	{
		this.db = db;
	}

	public bool create(Role role)
	{
		try
		{
			db.Roles.Add(role);
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
			db.Roles.Remove(db.Roles.Find(id));
			return db.SaveChanges() > 0;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			return false;
		}
	}
	public List<Role> findAll()
	{
		try
		{

			return db.Roles.ToList();
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			return null;
		}
	}

	public Role findById(int id)
	{
		try
		{

			return db.Roles.FirstOrDefault(x => x.Id == id);
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			return null;
		}
	}

	public List<Role> findByString(string name)
	{
		try
		{

			return db.Roles.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			return null;
		}
	}

	public bool update(Role role)
	{
		try
		{
			db.Entry(role).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			return db.SaveChanges() > 0;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			return false;
		}
	}
}
