using DSEU.Application.Common.Constants;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace DSEU.UI.Controllers.Claim
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для получение Сlaims")]
    public class ClaimController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Claims() 
        {
            return Ok(UserClaimTypes.All);
            
        }

    }
}
