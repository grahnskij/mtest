using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmeGames.Interfaces;
using AcmeGames.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcmeGames.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/code")]
    public class CodeController : Controller
    {
        private readonly ICodeService _codeService;

        public CodeController(ICodeService codeService)
        {
            _codeService = codeService;
        }

        [HttpPost]
        public IActionResult RedeemCode([FromBody] CodeRedeemViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (_codeService.RedeemCode(vm))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Either your code is incorrect, already redeemed or you already own that game!");
                }
            }
            else
            {
                return BadRequest("You need to enter a code!");
            }

        }
    }
}
