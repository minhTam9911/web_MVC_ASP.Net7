using Web_MVC.Models;

namespace Web_MVC.Services;

public interface SupplierService
{
    bool create(Supplier supplier);
    List<Supplier> findAll();
    bool update(Supplier supplier);
    bool delete(int id);
    Supplier findById(int id);
    List<Supplier> findByString(string name);
}
