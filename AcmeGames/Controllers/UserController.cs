using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmeGames.Interfaces;
using AcmeGames.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var result = _userService.GetUserData(id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateUserData([FromBody] UpdateUserDataViewModel vm)
        {
            if(ModelState.IsValid)
            {
                var result = _userService.UpdateUserData(vm);
                return Ok(result);
            }else
            {
                return BadRequest();
            }
            
        }
    }
}