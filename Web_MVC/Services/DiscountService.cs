using Web_MVC.Models;

namespace Web_MVC.Services;

public interface DiscountService
{

	bool create(Discount discount);
	List<Discount> findAll();
	bool update(Discount discount);
	bool delete(int id);
	Discount findById(int id);
	List<Discount> findByString(string name);

}
