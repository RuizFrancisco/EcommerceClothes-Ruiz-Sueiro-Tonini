using EcommerceClothes.Entities;

namespace EcommerceClothes.Services.Interfaces
{
    public interface IAdminService
    {
        List<User> GetAdmins();
        Admin GetAdminById(int id);
        Admin UpdateAdmin(Admin admin);
    }
}
