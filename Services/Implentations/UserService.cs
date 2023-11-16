using AutoMapper;
using EcommerceClothes.Entities;
using EcommerceClothes.Models;
using EcommerceClothes.Repositories.Interfaces;
using EcommerceClothes.Services.Interfaces;

namespace EcommerceClothes.Services.Implentations
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }
        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }
        public User GetByUserName(string name)
        {
            return _userRepository.GetByUserName(name);
        }
        public void AddClient(UserDTO userDTO)
        {
            var user = _mapper.Map<Client>(userDTO);
            _userRepository.AddClient(user);
        }

        public void AddAdmin(UserDTO userDTO)
        {
            var admin = _mapper.Map<Admin>(userDTO);
            _userRepository.AddAdmin(admin);
        }

        public void Update(int id, UserDTO userDTO)
        {
            var existingUser = _userRepository.GetById(id);

            if (existingUser == null)
            {
               
                throw new Exception("Usuario no encontrado");
            }

            
            existingUser.UserName = userDTO.UserName;
            existingUser.Email = userDTO.Email;
            existingUser.Password = userDTO.Password;

            
            _userRepository.Update(existingUser);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }
    }
}
