using EcommerceClothes.Models;

namespace EcommerceClothes.Services.Interfaces
{
    public interface IAuthenticationService
    {
        BaseResponse ValidateUser(AuthenticationRequestBody authenticationRequestBody);
    }
}
