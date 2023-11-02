using System.Diagnostics;
using Web_MVC.Models;

namespace Web_MVC.Services.Impl;

public class SupplierImpl : SupplierService
{

    private DatabaseContext db;
    public SupplierImpl(DatabaseContext db)
    {
        this.db = db;
    }

    public bool create(Supplier supplier)
    {
        try
        {
            
            db.Suppliers.Add(supplier);
            return db.SaveChanges() > 0;
        }catch(Exception ex)
        {
            Debug.WriteLine(ex.Message); return false;
        }
    }

    public bool delete(int id)
    {
        try
        {
            db.Suppliers.Remove(db.Suppliers.Find(id));
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message); 
            return false;
        }
    }

    public List<Supplier> findAll()
    {
        try
        {
            return db.Suppliers.ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message); return null;
        }
    }
        public Supplier findById(int id)
    {
        try
        {
            return db.Suppliers.FirstOrDefault(x=>x.Id == id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message); return null;
        }
    }

    public List<Supplier> findByString(string name)
    {
        try
        {
            return db.Suppliers.Where(x=>x.Name.ToLower().Contains(name)).ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message); return null;
        }
    }

    public bool update(Supplier supplier)
    {
        try
        {
            db.Entry(supplier).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges()>0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message); 
            return false;
        }
    }
}
