﻿using EcommerceClothes.Entities;
using EcommerceClothes.Models;

namespace EcommerceClothes.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAll();
        public User GetById(int id);
        public User GetByUserName(string name);
        public void AddClient(User user);
        public void AddAdmin(User admin);
        public void Update(User user);
        public void Delete(int id);
        BaseResponse ValidateUser(AuthenticationRequestBody authenticationRequestBody);
    }
}
