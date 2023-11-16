using EcommerceClothes.Models;
using EcommerceClothes.Repositories.Interfaces;
using EcommerceClothes.Services.Interfaces;

namespace EcommerceClothes.Services.Implentations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public BaseResponse ValidateUser(AuthenticationRequestBody authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password)) 
            {
                return null;
            }
            
            return _userRepository.ValidateUser(authenticationRequest);
        }
    }
}
