using EcommerceClothes.DBContext;
using EcommerceClothes.Entities;
using EcommerceClothes.Services.Interfaces;

namespace EcommerceClothes.Services.Implentations
{
    public class AdminService : IAdminService
    {
        private readonly EcommerceContext _context;

        public AdminService(EcommerceContext context)
        {
            _context = context;
        }

        public List<User> GetAdmins()
        {
            return _context.Users.Where(p => p.UserType == "Admin").ToList();
        }

        public Admin? GetAdminById(int id)
        {
            return _context.Admins.FirstOrDefault(p => p.Id == id);
        }

        public Admin UpdateAdmin(Admin admin)
        {
            _context.Update(admin);
            _context.SaveChanges();
            return admin;
        }
    }
}
