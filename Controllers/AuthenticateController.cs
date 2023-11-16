using EcommerceClothes.Entities;
using EcommerceClothes.Models;
using EcommerceClothes.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EcommerceClothes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;

        public AuthenticateController (IConfiguration configuration, IAuthenticationService authenticationService, IUserService userService)
        {
            _configuration = configuration;
            _authenticationService = authenticationService;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthenticationRequestBody authenticationRequestBody)
        {
            BaseResponse validateUserResult = _authenticationService.ValidateUser(authenticationRequestBody);
            if (validateUserResult.Message == "wrong email")
            {
                return BadRequest(validateUserResult.Message);
            }
            else if (validateUserResult.Message == "wrong password")
            {
                return Unauthorized();
            }
            if (validateUserResult.Result)
            {
                User? user = _userService.GetByUserName(authenticationRequestBody.UserName);
                var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));

                var signature = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

                var claimsForToken = new List<Claim>();
                claimsForToken.Add(new Claim("sub", user.Id.ToString()));
                claimsForToken.Add(new Claim("username", user.UserName));
                claimsForToken.Add(new Claim("usertype", user.UserType.ToString()));

                var jwtSecurityToken = new JwtSecurityToken(
                    _configuration["Authentication:Issuer"],
                    _configuration["Authentication:Audience"],
                    claimsForToken,
                    DateTime.UtcNow,
                    DateTime.UtcNow.AddHours(1),
                    signature);

                string tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                return Ok(tokenToReturn);
            }
            return BadRequest();
        }
    }
}
