using Web_MVC.Models;

namespace Web_MVC.Services;

public interface CategoryService
{
	bool create(Category category);
	List<Category> findAll();
	bool update(Category category, int value);
	bool delete(int id);
	Category findById(int id);
	List<Category> findByString(string name);

}
