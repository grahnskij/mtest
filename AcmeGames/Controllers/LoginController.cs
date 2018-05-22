using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using AcmeGames.Interfaces;
using AcmeGames.ViewModels;

namespace AcmeGames.Controllers
{
    [Produces("application/json")]
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly SigningCredentials mySigningCredentials;
        private readonly ILoginService _loginService;

        public LoginController(IConfiguration aConfiguration, IGameService gameService, ILoginService loginService){
            if (aConfiguration == null)
            {
                throw new ArgumentNullException(nameof(aConfiguration));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(aConfiguration["JWTKey"]));
            mySigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthRequestViewModel  aAuthRequest){
            if(ModelState.IsValid)
            {
                var user = _loginService.Login(aAuthRequest.EmailAddress, aAuthRequest.Password);

                if (user != null)
                {
                    var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier,    user.UserAccountId),
                new Claim(ClaimTypes.Name,              user.FullName),
                new Claim(ClaimTypes.GivenName,         user.Firstname),
                new Claim(ClaimTypes.Surname,           user.Lastname),
                new Claim(ClaimTypes.DateOfBirth,       user.Birth),
                new Claim(ClaimTypes.Email,             user.Email),
                new Claim(ClaimTypes.Role,              user.Role) };
                

                    var token = new JwtSecurityToken(
                        "localhost:56653",
                        "localhost:56653",
                        claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: mySigningCredentials);

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        id = user.UserAccountId
                    });
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return BadRequest();
            }
            
        }
    }
}