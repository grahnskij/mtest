using Microsoft.AspNetCore.Mvc;
using AcmeGames.Interfaces;
using AcmeGames.ViewModels;

namespace AcmeGames.Controllers
{
    [Produces("application/json")]
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService){
            _loginService = loginService;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(LoginDataViewModel))]
        [ProducesResponseType(400)]
        public IActionResult Authenticate([FromBody] AuthRequestViewModel  aAuthRequest){
            if(ModelState.IsValid)
            {
                var authenticated = _loginService.Login(aAuthRequest);

                if (authenticated != null)
                {
                    return Ok(authenticated);
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