using AcmeGames.Interfaces;
using AcmeGames.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AcmeGames.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUserData(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }
            var result = _userService.GetUserData(id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateUserData([FromBody] UpdateUserDataViewModel vm)
        {
            if(ModelState.IsValid)
            {
                if(_userService.UpdateUserData(vm))
                {
                    return Ok();
                }else
                {
                    return BadRequest();
                } 
            }else
            {
                return BadRequest();
            }
            
        }
    }
}