using Web_MVC.Models;

namespace Web_MVC.Services;

public interface RoleService
{
	bool create(Role role);
	List<Role> findAll();
	bool update(Role role);
	bool delete(int id);
	Role findById(int id);
	List<Role> findByString(string name);
}
