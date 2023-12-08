using EcommerceClothes.Entities;
using EcommerceClothes.Models;

namespace EcommerceClothes.Services.Interfaces
{
    public interface IUserService
    {
        public BaseResponse UserValidation(string username, string password);
        public User? GetUserByEmail(string username);
        void DeleteUser(int userId);
        int CreateUser(User user);
    }
}
