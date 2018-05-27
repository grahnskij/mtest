using System;
using AcmeGames.Interfaces;
using AcmeGames.ViewModels;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace AcmeGames.Services
{
    public class LoginService : ILoginService
    {
        private readonly IDatabase _db;
        private readonly SigningCredentials mySigningCredentials;

        public LoginService(IDatabase db, IConfiguration aConfiguration)
        {
            _db = db;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(aConfiguration["JWTKey"]));
            mySigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        }

        public LoginDataViewModel Login(AuthRequestViewModel aAuthRequest)
        {
            var user = _db.FindUser(aAuthRequest.EmailAddress, aAuthRequest.Password);
            if(user != null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier,    user.UserAccountId),
                    new Claim(ClaimTypes.Name,              user.FullName),
                    new Claim(ClaimTypes.GivenName,         user.FirstName),
                    new Claim(ClaimTypes.Surname,           user.LastName),
                    new Claim(ClaimTypes.DateOfBirth,       user.DateOfBirth.ToString("yyyy-MM-dd")),
                    new Claim(ClaimTypes.Email,             user.EmailAddress),
                    new Claim(ClaimTypes.Role,              user.IsAdmin ? "Admin" : "User")
                };
                var securityToken = new JwtSecurityToken(
                        "localhost:56653",
                        "localhost:56653",
                        claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: mySigningCredentials);

                var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

                return new LoginDataViewModel(token, user.UserAccountId);
            }
            else
            {
                return null;
            }
        }
    }
}
